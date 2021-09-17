using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DoAnQuanLyThuVien
{
    class XuLyMuonSach
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_MS;
        SqlDataAdapter da_S;
        SqlDataAdapter da_DG;
        SqlDataAdapter da_PMS;
        SqlDataAdapter da_PMS_Edit;
        SqlDataAdapter da_TS;
        SqlDataAdapter da_STS;

        public XuLyMuonSach()
        {
            
        }

        public DataTable loadPhieuMuonSach() //Load dữ liệu phiếu mượn sách lên datagridview
        {
            da_PMS = new SqlDataAdapter("SELECT * FROM PHIEUMUONSACH", cnn);
            da_PMS.Fill(ds, "PhieuMuonSach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["PhieuMuonSach"].Columns[0];
            ds.Tables["PhieuMuonSach"].PrimaryKey = kc;
            return ds.Tables["PhieuMuonSach"];
        }

        public DataTable loadPhieuMuonSach_Edit() //Load dữ liệu phiếu mượn sách để edit
        {
            da_PMS_Edit = new SqlDataAdapter("SELECT * FROM PHIEUMUONSACH", cnn);
            da_PMS_Edit.Fill(ds, "PMS");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["PMS"].Columns[0];
            ds.Tables["PMS"].PrimaryKey = kc;
            return ds.Tables["PMS"];
        }

        public DataTable loadChiTietMuonSach() //Load dữ liệu mượn sách lên datagridview
        {
            da_MS = new SqlDataAdapter("select * from CHITIETMUONSACH", cnn);
            da_MS.Fill(ds, "ChiTietMuonSach");
            DataColumn[] kc = new DataColumn[2];    //1 trường làm khóa chính
            kc[0] = ds.Tables["ChiTietMuonSach"].Columns[0];
            kc[1] = ds.Tables["ChiTietMuonSach"].Columns[1];
            ds.Tables["ChiTietMuonSach"].PrimaryKey = kc;
            return ds.Tables["ChiTietMuonSach"];
        }

        public DataTable loadDocGiaCombobox() //Load dữ liệu đọc giả lên combobox
        {
            da_DG = new SqlDataAdapter("select * from DOCGIA", cnn);
            da_DG.Fill(ds, "DocGia");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["DocGia"].Columns[0];
            ds.Tables["DocGia"].PrimaryKey = kc;
            return ds.Tables["DocGia"];
        }

        public DataTable loadSachCombobox() //Load dữ liệu sách lên combobox mượn sách
        {
            da_S = new SqlDataAdapter("select * from SACH", cnn);
            da_S.Fill(ds, "Sach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["Sach"].Columns[0];
            ds.Tables["Sach"].PrimaryKey = kc;
            return ds.Tables["Sach"];
        }

        public DataTable loadSachComboboxTraSach() //Load dữ liệu sách lên combobox trả sách
        {
            da_STS = new SqlDataAdapter("select * from SACH", cnn);
            da_STS.Fill(ds, "SachTra");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["SachTra"].Columns[0];
            ds.Tables["SachTra"].PrimaryKey = kc;
            return ds.Tables["SachTra"];
        }

        public DataTable loadTraSach()  //Load dữ liệu trả sách lên datagridview
        {
            da_TS = new SqlDataAdapter("Select * from TRASACH", cnn);
            da_TS.Fill(ds, "TraSach");
            DataColumn[] kc = new DataColumn[2];    //2 trường làm khóa chính
            kc[0] = ds.Tables["TraSach"].Columns[0];
            kc[1] = ds.Tables["TraSach"].Columns[1];
            ds.Tables["TraSach"].PrimaryKey = kc;
            return ds.Tables["TraSach"];
        }

        public int traVeSoLuongSach(string maSach)  //Trả về số lượng sách
        {
            try
            {
                int kq = -1;
                DataRow dr = ds.Tables["Sach"].Rows.Find(maSach);
                if (dr != null)
                {
                    kq = int.Parse(dr["SOLUONG"].ToString());
                }
                return kq;
            }
            catch
            {
                return -1;
            }
        }

        public string traVeTenDG(string maDG)   //Trả về tên đọc giả
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["DocGia"].Rows.Find(maDG);
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

        public string traVeTenSach(string maSach)   //Trả về tên sách
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["Sach"].Rows.Find(maSach);
                if (dr != null)
                {
                    kq = dr["TENSACH"].ToString();
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinhCTMS(string maMuon, string maSach)    //Kiểm tra khóa chính trong bảng chi tiết mượn sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["ChiTietMuonSach"].Rows.Find(mang);
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

        public bool ktKhoaChinhPhieuMS(string maMuon)    //Kiểm tra khóa chính trong bảng phiếu mượn sách
        {
            try
            {
                DataRow dr = ds.Tables["PMS"].Rows.Find(maMuon);
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

        public bool ktKhoaNgoai(string maMuon, string maSach)   //Kiểm tra khóa ngoại trong bảng chi tiết mượn sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["ChiTietMuonSach"].Rows.Find(mang);
                if (dr != null)
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

        public bool ktKhoaNgoaiPMS(string maMuon)
        {
            try
            {
                DataRow dr = ds.Tables["PMS"].Rows.Find(maMuon);
                if (dr != null)
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

        

        public bool themCTMuonSach(string maMuon, string maSach, DateTime ngayMuon, DateTime ngaySeTra) //Thêm 1 chi tiết mượn sách
        {
            try
            {
                DataRow dr = ds.Tables["ChiTietMuonSach"].NewRow();
                dr["MAMUON"] = maMuon;
                dr["MASACH"] = maSach;
                dr["NGAYMUON"] = ngayMuon;
                dr["NGAYSETRA"] = ngaySeTra;
                ds.Tables["ChiTietMuonSach"].Rows.Add(dr);
                if (luuVaoCSDL(da_MS, "ChiTietMuonSach"))
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

        public bool suaCTMuonSach(string maMuon, string maSach, DateTime ngayMuon, DateTime ngaySeTra)  //Sửa thông tin 1 chi tiết mượn sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["ChiTietMuonSach"].Rows.Find(mang);
                if (dr != null)
                {
                    dr["NGAYMUON"] = ngayMuon;
                    dr["NGAYSETRA"] = ngaySeTra;
                }
                if (luuVaoCSDL(da_MS, "ChiTietMuonSach"))
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

        public bool xoaCTMuonSach(string maMuon, string maSach) //Xóa 1 chi tiết mượn sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["ChiTietMuonSach"].Rows.Find(mang);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_MS, "ChiTietMuonSach"))
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

        public bool luuXuongCSDL(SqlDataAdapter da, DataTable dt)
        {
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            da.Update(dt);
            return true;
        }

        public bool themPhieuMuonSach(string maMS, string maDG) //Thêm 1 phiếu mượn sách
        {
            try
            {
                DataRow dr = ds.Tables["PMS"].NewRow();
                dr["MAMUON"] = maMS;
                dr["MADG"] = maDG;
                ds.Tables["PMS"].Rows.Add(dr);
                if (luuVaoCSDL(da_PMS_Edit, "PMS"))
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

        public bool suaPhieuMuonSach(string maMS, string maDG, string tinhTrang, float tienPhat)    //Sửa thông tin 1 phiếu mượn sách
        {
            try
            {
                DataRow dr = ds.Tables["PMS"].Rows.Find(maMS);
                if (dr != null)
                {
                    dr["MADG"] = maDG;
                    dr["TINHTRANG"] = tinhTrang;
                    dr["TIENPHAT"] = tienPhat;
                }
                if (luuVaoCSDL(da_PMS_Edit, "PMS"))
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

        public bool xoaPhieuMuonSach(string maMS)   //Xóa 1 phiếu mượn sách
        {
            try
            {
                DataRow dr = ds.Tables["PMS"].Rows.Find(maMS);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_PMS_Edit, "PMS"))
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

        public bool ktKhoaChinh(string maMuon, string maSach)   //Kiểm tra khóa chính trong bảng trả sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["TraSach"].Rows.Find(mang);
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

        public bool themTraSach(string maMuon, string maSach, DateTime ngayTra) //Thêm 1 dòng trả sách trong bảng trả sách
        {
            try
            {
                DataRow dr = ds.Tables["TraSach"].NewRow();
                dr["MAMUON"] = maMuon;
                dr["MASACH"] = maSach;
                dr["NGAYTRA"] = ngayTra;
                ds.Tables["TraSach"].Rows.Add(dr);
                if (luuVaoCSDL(da_TS, "TraSach"))
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

        public bool suaTraSach(string maMuon, string maSach, DateTime ngayTra)  //Sửa 1 dòng trả sách trong bảng trả sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["TraSach"].Rows.Find(mang);
                if (dr != null)
                {
                    dr["NGAYTRA"] = ngayTra;
                }
                if (luuVaoCSDL(da_TS, "TraSach"))
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

        public bool xoaTraSach(string maMuon, string maSach)    //Xóa 1 dòng trả sách trong bảng trả sách
        {
            try
            {
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["TraSach"].Rows.Find(mang);
                if (dr != null)
                {
                    dr.Delete();
                }
                if (luuVaoCSDL(da_TS, "TraSach"))
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

        public string traVeMaDG(string maMuon)  //Trả về mã đọc giả
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["PMS"].Rows.Find(maMuon);
                if (dr != null)
                {
                    kq = dr["MADG"].ToString();
                }
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public DateTime traVeNgaySeTra(string maMuon, string maSach)
        {
            try
            {
                DateTime kq = DateTime.Now;
                string[] mang = new string[2];
                mang[0] = maMuon;
                mang[1] = maSach;
                DataRow dr = ds.Tables["ChiTietMuonSach"].Rows.Find(mang);
                if (dr != null)
                {
                    kq = DateTime.Parse(dr["NGAYSETRA"].ToString());
                }
                return kq;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public double tinhNgayTre(DateTime ngaySeTra, DateTime ngayTra)
        {
            TimeSpan kq = ngayTra - ngaySeTra;
            double ngay = kq.TotalDays;
            if (ngay > 0)
            {
                return ngay;
            }
            return 0;
        }

        public bool ktPhieuMuonSachChuaTra(string maPM)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }

                string cauLenh = "select count(*) from PHIEUMUONSACH, CHITIETMUONSACH where PHIEUMUONSACH.MAMUON = '" + maPM + "' and PHIEUMUONSACH.MAMUON = CHITIETMUONSACH.MAMUON and CHITIETMUONSACH.MASACH not in (select MASACH from TRASACH where CHITIETMUONSACH.MAMUON = TRASACH.MAMUON)";
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


        public bool ktChiTietMuonSachChuaTra(string maPM)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }

                string cauLenh = "select Count(*) from CHITIETMUONSACH where CHITIETMUONSACH.MAMUON = '" + maPM + "' and CHITIETMUONSACH.MASACH not in (select MASACH from TRASACH where CHITIETMUONSACH.MAMUON = TRASACH.MAMUON)";
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
