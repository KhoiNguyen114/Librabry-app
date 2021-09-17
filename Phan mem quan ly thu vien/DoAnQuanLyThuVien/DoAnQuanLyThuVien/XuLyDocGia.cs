using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DoAnQuanLyThuVien
{
    class XuLyDocGia
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_DG;

        public XuLyDocGia()
        {

        }

        public DataTable loadDocGia()   //Load dữ liệu đọc giả lên datagridview
        {
            da_DG = new SqlDataAdapter("select * from DOCGIA", cnn);
            da_DG.Fill(ds, "DocGia");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["DocGia"].Columns[0];
            ds.Tables["DocGia"].PrimaryKey = kc;
            return ds.Tables["DocGia"];
        }

        public DataTable loadDocGiaTheoTen(string ten)  //Load dữ liệu đọc giả lên datagridview theo tên tìm kiếm
        {
            SqlDataAdapter da_LoadDGTen = new SqlDataAdapter("select * from DOCGIA where HOTEN LIKE N'%"+ten+"%'", cnn);
            da_LoadDGTen.Fill(ds, "LoadDocGiaTen");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["LoadDocGiaTen"].Columns[0];
            ds.Tables["LoadDocGiaTen"].PrimaryKey = kc;
            return ds.Tables["LoadDocGiaTen"];
        }

        public bool ktKhoaChinh(string maDG)    //Kiểm tra khóa chính trong bảng đọc giả
        {
            try
            {
                DataRow dr = ds.Tables["DocGia"].Rows.Find(maDG);
                if (dr != null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool luuVaoCSDL(SqlDataAdapter da, string tenTB) //Lưu cập nhật vào cơ sở dữ liệu
        {
            try
            {
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                da.Update(ds, tenTB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themDG(string maDG, string tenDG, string diaChi, string gioiTinh, DateTime ngaySinh, string SDT, string hinh)   //Thêm thông tin 1 đọc giả 
        {
            try
            {
                DataRow dr = ds.Tables["DocGia"].NewRow();
                dr["MADG"] = maDG;
                dr["HOTEN"] = tenDG;
                dr["DIACHI"] = diaChi;
                dr["GIOITINH"] = gioiTinh;
                dr["NGAYSINH"] = ngaySinh;
                dr["SDT"] = SDT;
                dr["HINH"] = hinh;
                ds.Tables["DocGia"].Rows.Add(dr);
                if (luuVaoCSDL(da_DG, "DocGia"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool suaDG(string maDG, string tenDG, string diaChi, string gioiTinh, DateTime ngaySinh, string SDT, string hinh)   //Sửa thông tin 1 đọc giả 
        {
            try
            {
                DataRow dr = ds.Tables["DocGia"].Rows.Find(maDG);
                if (dr != null)
                {
                    dr["HOTEN"] = tenDG;
                    dr["DIACHI"] = diaChi;
                    dr["GIOITINH"] = gioiTinh;
                    dr["NGAYSINH"] = ngaySinh;
                    dr["SDT"] = SDT;
                    dr["HINH"] = hinh;
                }
                if (luuVaoCSDL(da_DG, "DocGia"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDG(string maDG)  //Xóa thông tin 1 đọc giả
        {
            try
            {
                DataRow dr = ds.Tables["DocGia"].Rows.Find(maDG);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_DG, "DocGia"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktDocGiaMuonSach(string maDG)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }

                string cauLenh = "select count(*) from DOCGIA where MADG = '"+maDG+"' and MADG in (select MADG from PHIEUMUONSACH, CHITIETMUONSACH where PHIEUMUONSACH.MAMUON = CHITIETMUONSACH.MAMUON and CHITIETMUONSACH.MAMUON not in (select MAMUON from TRASACH))";
                SqlCommand cmd = new SqlCommand(cauLenh,cnn);
                int kq = (int)cmd.ExecuteScalar();
                
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }

                if (kq > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Image LoadHinh(string duongDan)
        {
            return Image.FromFile(duongDan);
        }
    }
}
