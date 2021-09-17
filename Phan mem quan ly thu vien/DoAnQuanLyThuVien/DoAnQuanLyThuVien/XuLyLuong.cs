using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    class XuLyLuong
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_Luong;
        SqlDataAdapter da_NhanVien;

        public XuLyLuong()
        {

        }

        public DataTable loadLuong()    //Load lương lên datagridview
        {
            da_Luong = new SqlDataAdapter("Select * from LUONG", cnn);
            da_Luong.Fill(ds, "Luong");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["Luong"].Columns[0];
            ds.Tables["Luong"].PrimaryKey = kc;
            return ds.Tables["Luong"];
        }

        public DataTable loadNhanVien()    //Load nhân viên lên combobox
        {
            da_NhanVien = new SqlDataAdapter("Select * from NHANVIEN", cnn);
            da_NhanVien.Fill(ds, "NhanVien");
            DataColumn[] kc = new DataColumn[1];
            kc[0] = ds.Tables["NhanVien"].Columns[0];
            ds.Tables["NhanVien"].PrimaryKey = kc;
            return ds.Tables["NhanVien"];
        }

        public string traVeTenNhanVien(string maNV)
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["NhanVien"].Rows.Find(maNV);
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

        public bool ktKhoaChinh(string maPhat)
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["Luong"].Rows.Find(maPhat);
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

        public bool luuVaoCSDL(SqlDataAdapter da, string tenTB)
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

        public bool themLuong(string maPhat, string maNV, DateTime ngayPhat, int luongDM, int soNgayLam, int luongThuc)
        {
            try
            {
                DataRow dr = ds.Tables["Luong"].NewRow();
                dr["MAPHAT"] = maPhat;
                dr["MANV"] = maNV;
                dr["NGAYPHAT"] = ngayPhat;
                dr["LUONGDM"] = luongDM;
                dr["SONGAYLAM"] = soNgayLam;
                dr["LUONG"] = luongThuc;
                ds.Tables["Luong"].Rows.Add(dr);
                if (luuVaoCSDL(da_Luong, "Luong"))
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

        public bool suaLuong(string maPhat, string maNV, DateTime ngayPhat, int luongDM, int soNgayLam, int luongThuc)
        {
            try
            {
                DataRow dr = ds.Tables["Luong"].Rows.Find(maPhat);
                if (dr != null)
                {
                    dr["MANV"] = maNV;
                    dr["NGAYPHAT"] = ngayPhat;
                    dr["LUONGDM"] = luongDM;
                    dr["SONGAYLAM"] = soNgayLam;
                    dr["LUONG"] = luongThuc;
                }
                if (luuVaoCSDL(da_Luong, "Luong"))
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

        public bool xoaLuong(string maPhat)
        {
            try
            {
                DataRow dr = ds.Tables["Luong"].Rows.Find(maPhat);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_Luong, "Luong"))
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
