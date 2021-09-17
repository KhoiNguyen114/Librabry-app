using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQuanLyThuVien
{
    public class KetNoiCoSoDuLieu
    {
        private static SqlConnection cnn = new SqlConnection("Data source = LAPTOP-1LO8U7LN\\SQLEXPRESS; Initial Catalog = QUANLYTHUVIEN_DOAN_NET; User ID = sa; Password = nguyen114814");

        public static SqlConnection Cnn
        {
            get { return KetNoiCoSoDuLieu.cnn; }
            set { KetNoiCoSoDuLieu.cnn = value; }
        }
    }
}
