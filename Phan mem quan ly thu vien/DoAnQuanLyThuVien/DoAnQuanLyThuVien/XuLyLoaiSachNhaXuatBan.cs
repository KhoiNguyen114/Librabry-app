using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    class XuLyLoaiSachNhaXuatBan
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_LS;
        SqlDataAdapter da_NXB;

        public DataTable loadLoaiSach() //Load dữ liệu loại sách lên datagridview
        {
            da_LS = new SqlDataAdapter("select * from LOAISACH", cnn);
            da_LS.Fill(ds, "LoaiSach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["LoaiSach"].Columns[0];
            ds.Tables["LoaiSach"].PrimaryKey = kc;
            return ds.Tables["LoaiSach"];
        }

        public DataTable loadNhaXuatBan() //Load dữ liệu nhà xuất bản lên datagridview
        {
            da_NXB = new SqlDataAdapter("select * from NHAXUATBAN", cnn);
            da_NXB.Fill(ds, "NhaXuatBan");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["NhaXuatBan"].Columns[0];
            ds.Tables["NhaXuatBan"].PrimaryKey = kc;
            return ds.Tables["NhaXuatBan"];
        }

        public bool ktKhoaChinhLoaiSach(string maLS)    //Kiểm tra khóa chính trong bảng loại sách
        {
            try
            {
                DataRow dr = ds.Tables["LoaiSach"].Rows.Find(maLS);
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

        public bool ktKhoaChinhNhaXuatBan(string maNXB) //Kiểm tra khóa chính trong bảng nhà xuất bản
        {
            try
            {
                DataRow dr = ds.Tables["NhaXuatBan"].Rows.Find(maNXB);
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

        public bool luuVaoCSDL(SqlDataAdapter da, string tenTB) //Lưu vào cơ sở dữ liệu
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

        public bool themLoaiSach(string maLoaiSach, string tenLoaiSach) //Thêm loại sách
        {
            try
            {
                DataRow dr = ds.Tables["LoaiSach"].NewRow();
                dr["MALS"] = maLoaiSach;
                dr["TENLOAI"] = tenLoaiSach;
                ds.Tables["LoaiSach"].Rows.Add(dr);
                if (luuVaoCSDL(da_LS, "LoaiSach"))
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

        public bool suaLoaiSach(string maLoaiSach, string tenLoaiSach) //Sửa loại sách
        {
            try
            {
                DataRow dr = ds.Tables["LoaiSach"].Rows.Find(maLoaiSach);
                if (dr != null)
                {
                    dr["TENLOAI"] = tenLoaiSach;
                }
                if (luuVaoCSDL(da_LS, "LoaiSach"))
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

        public bool xoaLoaiSach(string maLoaiSach) //Xóa loại sách
        {
            try
            {
                DataRow dr = ds.Tables["LoaiSach"].Rows.Find(maLoaiSach);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_LS, "LoaiSach"))
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

        public bool themNXB(string maNXB, string tenNXB, string diaChi, string dienThoai) //Thêm nhà xuất bản
        {
            try
            {
                DataRow dr = ds.Tables["NhaXuatBan"].NewRow();
                dr["MANXB"] = maNXB;
                dr["TENNXB"] = tenNXB;
                dr["DIACHI"] = diaChi;
                dr["DIENTHOAI"] = dienThoai;
                ds.Tables["NhaXuatBan"].Rows.Add(dr);
                if (luuVaoCSDL(da_NXB, "NhaXuatBan"))
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

        public bool suaNXB(string maNXB, string tenNXB, string diaChi, string dienThoai) //Sửa nhà xuất bản
        {
            try
            {
                DataRow dr = ds.Tables["NhaXuatBan"].Rows.Find(maNXB);
                if (dr != null)
                {
                    dr["TENNXB"] = tenNXB;
                    dr["DIACHI"] = diaChi;
                    dr["DIENTHOAI"] = dienThoai;
                }
                if (luuVaoCSDL(da_NXB, "NhaXuatBan"))
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

        public bool xoaNXB(string maNXB) //Xóa nhà xuất bản
        {
            try
            {
                DataRow dr = ds.Tables["NhaXuatBan"].Rows.Find(maNXB);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_NXB, "NhaXuatBan"))
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
    }
}
