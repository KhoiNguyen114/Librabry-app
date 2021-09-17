using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnQuanLyThuVien
{
    class XuLyTaiKhoan
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_TK;
        SqlDataAdapter da_NV;
        SqlDataAdapter da_LoaiTK;
        SqlDataAdapter da_TK_Edit;

        public XuLyTaiKhoan()
        {
            loadTaiKhoan_Edit();
        }

        public DataTable loadTaiKhoan() //Load dữ liệu tài khoản lên datagridview
        {
            da_TK = new SqlDataAdapter("select MATK,TENDN,MALOAI,MANV from TAIKHOAN", cnn);
            da_TK.Fill(ds, "TaiKhoan");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["TaiKhoan"].Columns[0];
            ds.Tables["TaiKhoan"].PrimaryKey = kc;
            return ds.Tables["TaiKhoan"];
        }

        public DataTable loadLoaiTaiKhoan() //Load dữ liệu loại tài khoản lên combobox
        {
            da_LoaiTK = new SqlDataAdapter("Select * from LOAITAIKHOAN", cnn);
            da_LoaiTK.Fill(ds, "LoaiTaiKhoan");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["LoaiTaiKhoan"].Columns[0];
            ds.Tables["LoaiTaiKhoan"].PrimaryKey = kc;
            return ds.Tables["LoaiTaiKhoan"];
        }

        public DataTable loadNhanVien() //Load dữ liệu nhân viên lên combobox
        {
            da_NV = new SqlDataAdapter("Select * from NHANVIEN", cnn);
            da_NV.Fill(ds, "NhanVien");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["NhanVien"].Columns[0];
            ds.Tables["NhanVien"].PrimaryKey = kc;
            return ds.Tables["NhanVien"];
        }

        public DataTable loadTaiKhoan_Edit() //Load dữ liệu tài khoản lên datagridview
        {
            da_TK_Edit = new SqlDataAdapter("Select * from TAIKHOAN", cnn);
            da_TK_Edit.Fill(ds, "TK");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["TK"].Columns[0];
            ds.Tables["TK"].PrimaryKey = kc;
            return ds.Tables["TK"];
        }

        public void loadThemTatCaCombobox(DataTable dt, string ma, string ten, ComboBox cbo, string display, string value)
        {
            DataRow dr = dt.NewRow();
            dr[0] = ma;
            dr[1] = ten;
            dt.Rows.InsertAt(dr, 0);
            cbo.DataSource = dt;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
        }


        public string traVeTenNhanVien(string maNV)
        {
            try
            {
                DataRow dr = ds.Tables["NhanVien"].Rows.Find(maNV);
                string kq = "";
                if (dr != null)
                {
                    kq = dr["HOTEN"].ToString();
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public string traVeTenLoaiTK(string maLoai)
        {
            try
            {
                DataRow dr = ds.Tables["LoaiTaiKhoan"].Rows.Find(maLoai);
                string kq = "";
                if (dr != null)
                {
                    kq = dr["TENLOAI"].ToString();
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(string maTK)    //Kiểm tra khóa chính
        {
            try
            {
                DataRow dr = ds.Tables["TK"].Rows.Find(maTK);
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

        public bool themTK(string maTK, string tenDN, string matKhau, int maLoai, string maNV)  //Thêm 1 tài khoản mới
        {
            try
            {
                DataRow dr = ds.Tables["TK"].NewRow();
                dr["MATK"] = maTK;
                dr["TENDN"] = tenDN;
                dr["MATKHAU"] = matKhau;
                dr["MALOAI"] = maLoai;
                dr["MANV"] = maNV;
                ds.Tables["TK"].Rows.Add(dr);
                if (luuVaoCSDL(da_TK_Edit,"TK"))
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

        public bool suaTK(string maTK, string tenDN, string matKhau, int maLoai)  //Sửa 1 tài khoản
        {
            try
            {
                DataRow dr = ds.Tables["TK"].Rows.Find(maTK);
                if (dr != null)
                {
                    dr["TENDN"] = tenDN;
                    dr["MATKHAU"] = matKhau;
                    dr["MALOAI"] = maLoai;
                }
                if (luuVaoCSDL(da_TK_Edit, "TK"))
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

        public bool demSoTaiKhoan(string maNV)  //Đếm số tài khoản của 1 nhân viên. Mỗi nhân viên chỉ được cấp 1 tài khoản
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cauLenh = "select count(*) from TAIKHOAN where MANV = '"+maNV+"'";
                SqlCommand cmd = new SqlCommand(cauLenh, cnn);
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
    }
}
