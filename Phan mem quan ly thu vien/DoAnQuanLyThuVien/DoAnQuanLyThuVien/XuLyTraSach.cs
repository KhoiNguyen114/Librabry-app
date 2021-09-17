using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    class XuLyTraSach
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_MS;
        SqlDataAdapter da_TS;
        SqlDataAdapter da_PMS;

        public XuLyTraSach()
        {
            loadChiTietMuonSach();
        }     

        

        public DataTable loadPhieuMuonSach()
        {
            da_PMS = new SqlDataAdapter("SELECT * FROM PHIEUMUONSACH", cnn);
            da_PMS.Fill(ds, "PhieuMuonSach");
            DataColumn[] kc = new DataColumn[1];    //1 trường làm khóa chính
            kc[0] = ds.Tables["PhieuMuonSach"].Columns[0];
            ds.Tables["PhieuMuonSach"].PrimaryKey = kc;
            return ds.Tables["PhieuMuonSach"];
        }

        public string traVeTenSach(string maSach)   //Trả về tên sách
        {
            try
            {
                string kq = "";
                DataRow dr = ds.Tables["SachTra"].Rows.Find(maSach);
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

        public DataTable loadChiTietMuonSach() //Load dữ liệu dữ liệu chi tiết mượn sách để kiểm tra khóa ngoại
        {
            da_MS = new SqlDataAdapter("select * from CHITIETMUONSACH", cnn);
            da_MS.Fill(ds, "ChiTietMuonSach");
            DataColumn[] kc = new DataColumn[2];    //1 trường làm khóa chính
            kc[0] = ds.Tables["ChiTietMuonSach"].Columns[0];
            kc[1] = ds.Tables["ChiTietMuonSach"].Columns[1];
            ds.Tables["ChiTietMuonSach"].PrimaryKey = kc;
            return ds.Tables["ChiTietMuonSach"];
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

        


    }
}
