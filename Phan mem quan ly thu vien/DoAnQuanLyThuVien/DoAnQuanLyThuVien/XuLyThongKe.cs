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
    class XuLyThongKe
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_TK_DangChoMuon;
        SqlDataAdapter da_TK_ChuaChoMuon;
        SqlDataAdapter da_TK_MuonChuaTra;
        public XuLyThongKe()
        {

        }

        public DataTable loadSachDangChoMuon()  //Load sách cho mượn
        {
            da_TK_DangChoMuon = new SqlDataAdapter("select Sach.*, NGAYMUON, NGAYTRA, HOTEN from SACH, CHITIETMUONSACH, PHIEUMUONSACH, DOCGIA, TRASACH where DOCGIA.MADG = PHIEUMUONSACH.MADG and CHITIETMUONSACH.MAMUON = PHIEUMUONSACH.MAMUON and CHITIETMUONSACH.MAMUON = TRASACH.MAMUON and CHITIETMUONSACH.MASACH = TRASACH.MASACH and CHITIETMUONSACH.MASACH = SACH.MASACH and SACH.MASACH in (Select MASACH from CHITIETMUONSACH) and SACH.MASACH in (Select MASACH from TRASACH)", cnn);
            da_TK_DangChoMuon.Fill(ds, "ThongKeChoMuon");
            return ds.Tables["ThongKeChoMuon"];
        }

        public DataGridView thietLapHeaderText(DataGridView dtgv, string maSach, string tenSach, string maNXB, string maLS, string soLuong, string donGia, string hinh)
        {
            dtgv.Columns[0].HeaderText = maSach;
            dtgv.Columns[1].HeaderText = tenSach;
            dtgv.Columns[2].HeaderText = maNXB;
            dtgv.Columns[3].HeaderText = maLS;
            dtgv.Columns[4].HeaderText = soLuong;
            dtgv.Columns[5].HeaderText = donGia;
            dtgv.Columns[6].HeaderText = hinh;
            return dtgv;
        }

        public DataTable loadSachChuaChoMuon()  //Load sách chưa cho mượn
        {
            da_TK_ChuaChoMuon = new SqlDataAdapter("select Sach.* from SACH where SACH.MASACH not in (Select MASACH from CHITIETMUONSACH)", cnn);
            da_TK_ChuaChoMuon.Fill(ds, "ThongKeChuaChoMuon");
            return ds.Tables["ThongKeChuaChoMuon"];
        }

        public DataTable loadSachMuonChuaTra()  //Load sách đang cho mượn nhưng chưa trả
        {
            string cauLenh = "select Sach.*, NGAYMUON, NGAYSETRA, HOTEN from SACH, CHITIETMUONSACH, PHIEUMUONSACH, DOCGIA where DOCGIA.MADG = PHIEUMUONSACH.MADG and CHITIETMUONSACH.MAMUON = PHIEUMUONSACH.MAMUON and CHITIETMUONSACH.MASACH = SACH.MASACH and SACH.MASACH in (Select MASACH from CHITIETMUONSACH) and SACH.MASACH not in (Select MASACH from TRASACH)";
            da_TK_MuonChuaTra = new SqlDataAdapter(cauLenh, cnn);
            da_TK_MuonChuaTra.Fill(ds, "ThongKeMuonChuaTra");
            return ds.Tables["ThongKeMuonChuaTra"];
        }

        public DataGridView thietLapHeaderText(DataGridView dtgv, string maSach, string tenSach, string maNXB, string maLS, string soLuong, string donGia, string hinh, string ngayMuon, string ngaySeTra, string tenDG)
        {
            dtgv.Columns[0].HeaderText = maSach;
            dtgv.Columns[1].HeaderText = tenSach;
            dtgv.Columns[2].HeaderText = maNXB;
            dtgv.Columns[3].HeaderText = maLS;
            dtgv.Columns[4].HeaderText = soLuong;
            dtgv.Columns[5].HeaderText = donGia;
            dtgv.Columns[6].HeaderText = hinh;
            dtgv.Columns[7].HeaderText = ngayMuon;
            dtgv.Columns[8].HeaderText = ngaySeTra;
            dtgv.Columns[9].HeaderText = tenDG;
            return dtgv;
        }
    }
}
