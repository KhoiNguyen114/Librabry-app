using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    class XuLyReport
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_MS;
        SqlDataAdapter da_PMS;
        SqlDataAdapter da_DG;
        SqlDataAdapter da_TK_DangChoMuon;
        SqlDataAdapter da_TK_ChuaChoMuon;
        SqlDataAdapter da_TK_MuonChuaTra;

        public XuLyReport()
        {
            loadDocGia();
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

        public DataTable loadChiTietMuonSach(string maMuon) //Load dữ liệu mượn sách lên datagridview
        {
            da_MS = new SqlDataAdapter("select * from CHITIETMUONSACH where MAMUON = '" + maMuon + "'", cnn);
            da_MS.Fill(ds, "ChiTietMuonSach");
            DataColumn[] kc = new DataColumn[2];    //1 trường làm khóa chính
            kc[0] = ds.Tables["ChiTietMuonSach"].Columns[0];
            kc[1] = ds.Tables["ChiTietMuonSach"].Columns[1];
            ds.Tables["ChiTietMuonSach"].PrimaryKey = kc;
            return ds.Tables["ChiTietMuonSach"];
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

        public string traVeTenDG(string maDG)    //trả về tên loại sách lên combobox
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

        public DataTable loadSachChoMuonDaTra()  //Load sách cho mượn
        {
            da_TK_DangChoMuon = new SqlDataAdapter("select Sach.*, CHITIETMUONSACH.MAMUON, NGAYMUON, NGAYTRA, HOTEN from SACH, CHITIETMUONSACH, PHIEUMUONSACH, DOCGIA, TRASACH where DOCGIA.MADG = PHIEUMUONSACH.MADG and CHITIETMUONSACH.MAMUON = PHIEUMUONSACH.MAMUON and CHITIETMUONSACH.MAMUON = TRASACH.MAMUON and CHITIETMUONSACH.MASACH = TRASACH.MASACH and CHITIETMUONSACH.MASACH = SACH.MASACH and SACH.MASACH in (Select MASACH from CHITIETMUONSACH) and SACH.MASACH in (Select MASACH from TRASACH)", cnn);
            da_TK_DangChoMuon.Fill(ds, "ThongKeChoMuon");
            return ds.Tables["ThongKeChoMuon"];
        }

        public DataTable loadSachChuaChoMuon()  //Load sách chưa cho mượn
        {
            da_TK_ChuaChoMuon = new SqlDataAdapter("select Sach.* from SACH where SACH.MASACH not in (Select MASACH from CHITIETMUONSACH)", cnn);
            da_TK_ChuaChoMuon.Fill(ds, "ThongKeChuaChoMuon");
            return ds.Tables["ThongKeChuaChoMuon"];
        }

        public DataTable loadSachMuonChuaTra()  //Load sách đang cho mượn nhưng chưa trả
        {
            da_TK_MuonChuaTra = new SqlDataAdapter("select Sach.*, CHITIETMUONSACH.MAMUON, NGAYMUON, NGAYSETRA, HOTEN from SACH, CHITIETMUONSACH, PHIEUMUONSACH, DOCGIA where DOCGIA.MADG = PHIEUMUONSACH.MADG and CHITIETMUONSACH.MAMUON = PHIEUMUONSACH.MAMUON and CHITIETMUONSACH.MASACH = SACH.MASACH and SACH.MASACH in (Select MASACH from CHITIETMUONSACH) and SACH.MASACH not in (Select MASACH from TRASACH)", cnn);
            da_TK_MuonChuaTra.Fill(ds, "ThongKeMuonChuaTra");
            return ds.Tables["ThongKeMuonChuaTra"];
        }
    }
}
