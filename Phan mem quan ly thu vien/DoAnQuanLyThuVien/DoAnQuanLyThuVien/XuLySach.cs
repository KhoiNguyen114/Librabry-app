using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnQuanLyThuVien
{
    class XuLySach
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_Sach;
        SqlDataAdapter da_NXB;
        SqlDataAdapter da_LoaiSach;
        SqlDataAdapter da_Sach_edit;



        public XuLySach()
        {
            loadSach_Edit();
        }

        //load dữ liệu từ bảng sách lên
        public DataTable loadSach()
        {
            da_Sach = new SqlDataAdapter("Select * from SACH", cnn);
            da_Sach.Fill(ds, "Sach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính bảng sách
            kc[0] = ds.Tables["Sach"].Columns[0];
            ds.Tables["Sach"].PrimaryKey = kc;
            return ds.Tables["Sach"];
        }

        //load dữ liệu từ bảng nhà xuất bản lên
        public DataTable loadNXB()
        {
            da_NXB = new SqlDataAdapter("Select * from NHAXUATBAN", cnn);
            da_NXB.Fill(ds, "NhaXuatBan");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính bảng nhà xuất bản
            kc[0] = ds.Tables["NhaXuatBan"].Columns[0];
            ds.Tables["NhaXuatBan"].PrimaryKey = kc;
            return ds.Tables["NhaXuatBan"];
        }

        //load dữ liệu từ bảng loại sách lên
        public DataTable loadLoaiSach()
        {
            da_LoaiSach = new SqlDataAdapter("Select * from LOAISACH", cnn);
            da_LoaiSach.Fill(ds, "LoaiSach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính bảng loại sách
            kc[0] = ds.Tables["LoaiSach"].Columns[0];
            ds.Tables["LoaiSach"].PrimaryKey = kc;
            return ds.Tables["LoaiSach"];
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

        public string traVeNXB(string maNXB)    //trả về tên nxb lên combobox
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["NhaXuatBan"].Rows.Find(maNXB);
                if (dr != null)
                {
                    kq = dr["TENNXB"].ToString();
                }
                return kq + " ";
            }
            catch
            {
                return null;
            }
        }

        public string traVeLoaiSach(string maLoai)    //trả về tên loại sách lên combobox
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["LoaiSach"].Rows.Find(maLoai);
                if (dr != null)
                {
                    kq = dr["TENLOAI"].ToString();
                }
                return kq + " ";
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinhSach(string maSach)  //Kiểm tra khóa chính trong bảng sách
        {
            try
            {
                DataRow dr = ds.Tables["SachEdit"].Rows.Find(maSach);
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

        public DataTable loadSach_Edit()    //load bảng sách lên để thêm, xóa, sửa
        {
            da_Sach_edit = new SqlDataAdapter("Select * from SACH", cnn);
            da_Sach_edit.Fill(ds, "SachEdit");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["SachEdit"].Columns[0];
            ds.Tables["SachEdit"].PrimaryKey = kc;
            return ds.Tables["SachEdit"];
        }

        public bool themSach(string maSach, string tenSach, string mnxb, string mls, int soLuong, int donGia, string hinh)  //thêm 1 sách
        {
            try
            {
                DataRow dr = ds.Tables["SachEdit"].NewRow();
                dr["MASACH"] = maSach;
                dr["TENSACH"] = tenSach;
                dr["MANXB"] = mnxb;
                dr["MALS"] = mls;
                dr["SOLUONG"] = soLuong;
                dr["DONGIA"] = donGia;
                dr["HINH"] = hinh;
                ds.Tables["SachEdit"].Rows.Add(dr);
                if (luuVaoCSDL(da_Sach_edit, "SachEdit"))
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

        public bool xoaSach(string maSach)  //Xóa 1 sách
        {
            try
            {
                DataRow dr = ds.Tables["SachEdit"].Rows.Find(maSach);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_Sach_edit, "SachEdit"))
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

        public bool suaSach(string maSach, string tenSach, string mnxb, string mls, int soLuong, int donGia, string hinh)   //Sửa thông tin 1 sách
        {
            try
            {
                DataRow dr = ds.Tables["SachEdit"].Rows.Find(maSach);
                if (dr != null)
                {
                    dr["TENSACH"] = tenSach;
                    dr["MANXB"] = mnxb;
                    dr["MALS"] = mls;
                    dr["SOLUONG"] = soLuong;
                    dr["DONGIA"] = donGia;
                    dr["HINH"] = hinh;
                }
                if (luuVaoCSDL(da_Sach_edit, "SachEdit"))
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

        //Tìm kiếm sách theo tên
        public DataTable timKiemSach(string tenSach)    //Tìm kiếm theo tên sách
        {
            SqlDataAdapter da_tk = new SqlDataAdapter("select * from SACH where TENSACH like N'%" + tenSach + "%'", cnn);
            da_tk.Fill(ds, "SachTK");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["SachTK"].Columns[0];
            ds.Tables["SachTK"].PrimaryKey = kc;
            return ds.Tables["SachTK"];
        }

        //Load sách theo combobox nxb được chọn
        public DataTable loadSachNXB(string mnxb)   //Load datagridview theo nhà xuất bản được chọn
        {
            SqlDataAdapter da_LoadNXB = new SqlDataAdapter("Select * from SACH Where MANXB = '" + mnxb + "'", cnn);
            da_LoadNXB.Fill(ds, "LoadNXBS");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["LoadNXBS"].Columns[0];
            ds.Tables["LoadNXBS"].PrimaryKey = kc;
            return ds.Tables["LoadNXBS"];
        }

        //Load sách theo combobox loại sách được chọn
        public DataTable loadSachLoaiSach(string ml)    //Load datagridview theo loại sách được chọn
        {
            SqlDataAdapter da_LoadLoaiSach = new SqlDataAdapter("Select * from SACH Where MALS = '" + ml + "'", cnn);
            da_LoadLoaiSach.Fill(ds, "LoadLSS");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["LoadLSS"].Columns[0];
            ds.Tables["LoadLSS"].PrimaryKey = kc;
            return ds.Tables["LoadLSS"];               
        }

        public Image LoadHinh(string duongDan)
        {
            return Image.FromFile(duongDan);
        }
    }
}
