using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnQuanLyThuVien
{
    class XuLyNhanVien
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_NV;
        SqlDataAdapter da_ChucVu;
        SqlDataAdapter da_LoadNV_Edit;

        public XuLyNhanVien()
        {
            loadNV_Edit();
        }

        public DataTable loadNhanVien() //Load dữ liệu nhân viên
        {
            da_NV = new SqlDataAdapter("Select * from NHANVIEN", cnn);
            da_NV.Fill(ds, "NhanVien");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["NhanVien"].Columns[0];
            ds.Tables["NhanVien"].PrimaryKey = kc;
            return ds.Tables["NhanVien"];
        }

        public DataTable loadChucVu()   //Load dữ liệu chức vụ
        {
            da_ChucVu = new SqlDataAdapter("Select * from CHUCVU", cnn);
            da_ChucVu.Fill(ds, "ChucVu");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["ChucVu"].Columns[0];
            ds.Tables["ChucVu"].PrimaryKey = kc;
            return ds.Tables["ChucVu"];
        }

        public DataTable loadDLChoTreeView(string cauLenh) //Load chức vụ lên bằng datatable
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da_loadTree = new SqlDataAdapter(cauLenh, cnn);
            da_loadTree.Fill(dt);
            return dt;
        }

        public void hienThiChucVu(TreeView trv) //Hiển thị lên treeview
        {
            DataTable dt = loadDLChoTreeView("Select * from CHUCVU");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trv.Nodes.Add(dt.Rows[i][1].ToString());
                trv.Tag = "1";
                DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
                kc[0] = dt.Columns[0];
                dt.PrimaryKey = kc;
            }
        }

        public DataTable loadNhanVienTheoChucVu(string tenCV)   //Load dữ liệu nhân viên lên datagridview theo treeview
        {
            SqlDataAdapter da_LoadNVCV = new SqlDataAdapter("select NHANVIEN.* from NHANVIEN, CHUCVU where NHANVIEN.MACV = CHUCVU.MACV and TENCV = N'"+tenCV+"'", cnn);
            da_LoadNVCV.Fill(ds, "LoadNhanVien");
            DataColumn[] kc = new DataColumn[1]; //1 trường làm khóa chính
            kc[0] = ds.Tables["LoadNhanVien"].Columns[0];
            ds.Tables["LoadNhanVien"].PrimaryKey = kc;
            return ds.Tables["LoadNhanVien"];
        }

        public string traVeChucVu(int mcv)  //Trả về tên chức vụ
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["ChucVu"].Rows.Find(mcv);
                if (dr != null)
                {
                    kq = dr["TENCV"].ToString();
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public DataTable loadNV_Edit()
        {
            da_LoadNV_Edit = new SqlDataAdapter("Select * from NHANVIEN", cnn);
            da_LoadNV_Edit.Fill(ds, "NV");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["NV"].Columns[0];
            ds.Tables["NV"].PrimaryKey = kc;
            return ds.Tables["NV"];
        }

        public bool ktKhoaChinh(string maNV)    //Kiểm tra khóa chính bảng nhân viên
        {
            try
            {
                DataRow dr = ds.Tables["NV"].Rows.Find(maNV);
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

        public bool luuVaoCSDL(SqlDataAdapter da, string tenTB) //lưu thông tin thao tác vào cơ sở dữ liệu
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

        //Thêm 1 nhân viên
        public bool themNV(string maNV, string tenNV, string diaChi, string gioiTinh, DateTime ngaySinh, string sdt, DateTime nvl, string hinh, int maCV)
        {
            try
            {
                int soTuoi = nvl.Year - ngaySinh.Year;
                if (nvl < ngaySinh.AddYears(soTuoi))
                {
                    soTuoi--;
                }
                if (soTuoi < 18)
                {
                    return false;
                }
                DataRow dr = ds.Tables["NV"].NewRow();
                dr["MANV"] = maNV;
                dr["HOTEN"] = tenNV;
                dr["DIACHI"] = diaChi;
                dr["GIOITINH"] = gioiTinh;
                dr["NGAYSINH"] = ngaySinh;
                dr["SDT"] = sdt;
                dr["NGAYVAOLAM"] = nvl;
                dr["HINH"] = hinh;
                dr["MACV"] = maCV;
                ds.Tables["NV"].Rows.Add(dr);
                if (luuVaoCSDL(da_LoadNV_Edit, "NV"))
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

        //Sửa thông tin 1 nhân viên
        public bool suaNV(string maNV, string tenNV, string diaChi, string gioiTinh, DateTime ngaySinh, string sdt, DateTime nvl, string hinh, int maCV)
        {
            try
            {
                int soTuoi = nvl.Year - ngaySinh.Year;
                if (nvl < ngaySinh.AddYears(soTuoi))
                {
                    soTuoi--;
                }
                if (soTuoi < 18)
                {
                    return false;
                }
                DataRow dr = ds.Tables["NV"].Rows.Find(maNV);
                if (dr != null)
                {
                    dr["HOTEN"] = tenNV;
                    dr["DIACHI"] = diaChi;
                    dr["GIOITINH"] = gioiTinh;
                    dr["NGAYSINH"] = ngaySinh;
                    dr["SDT"] = sdt;
                    dr["NGAYVAOLAM"] = nvl;
                    dr["HINH"] = hinh;
                    dr["MACV"] = maCV;
                }
                if (luuVaoCSDL(da_LoadNV_Edit, "NV"))
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

        //Xóa 1 nhân viên
        public bool xoaNV(string maNV)
        {
            try
            {
                DataRow dr = ds.Tables["NV"].Rows.Find(maNV);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_LoadNV_Edit, "NV"))
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

        public bool themChucVu(string tenCV)    //Thêm 1 chức vụ mới
        {
            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cauLenh = "insert into CHUCVU values (N'"+tenCV+"')";
                SqlCommand cmd = new SqlCommand(cauLenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaChucVu(string tenCV)    //Xóa 1 chức vụ 
        {
            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cauLenh = "delete CHUCVU where TENCV = N'"+tenCV+"'";
                SqlCommand cmd = new SqlCommand(cauLenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
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
