using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    class XuLyDangNhap
    {
        SqlConnection cnn = KetNoiCoSoDuLieu.Cnn;
        
        public bool ktDangNhap(string tenDN, string mk, int maLoai) //Kiểm tra thông tin đăng nhập đúng hay không
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cauLenh = "select count(*) from TAIKHOAN where TENDN = N'"+tenDN+"' and MATKHAU ='"+mk+"' and MALOAI = " + maLoai + "";
                SqlCommand cmd = new SqlCommand(cauLenh, cnn);
                int kq = (int)cmd.ExecuteScalar();             
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }

                if (kq > 0)
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
