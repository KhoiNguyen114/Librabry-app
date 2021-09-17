using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLyThuVien
{
    public partial class frmDangNhap : Form
    {
        XuLyDangNhap xuLy = new XuLyDangNhap();
        public string quyenDN;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public bool ktCheckRadiobutton(Panel p)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                RadioButton rd = (RadioButton)p.Controls[i];
                if (rd.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length == 0 || txtTenDN.Text.Length == 0)
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ktCheckRadiobutton(panel1))
                {
                    int maLoaiTK = 0;
                    for (int i = 0; i < panel1.Controls.Count; i++)
                    {
                        RadioButton rd = (RadioButton)panel1.Controls[i];
                        if (rd.Checked)
                        {
                            quyenDN = rd.Text;
                            switch (quyenDN)
                            {
                                case "User":
                                    maLoaiTK = 1;
                                    break;
                                case "Admin":
                                    maLoaiTK = 2;
                                    break;
                            }
                        }
                    }
                    if (xuLy.ktDangNhap(txtTenDN.Text, txtMatKhau.Text,maLoaiTK))
                    {
                        Program.frmQL = new frmQuanLy();
                        Program.frmQL.quyenDN = quyenDN;
                        Program.frmQL.Show();
                        Program.frmDN.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn quyền muốn đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan frm = new frmThemTaiKhoan();
            frm.ShowDialog();

        }
    }
}
