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
    public partial class frmThemTaiKhoan : Form
    {
        XuLyTaiKhoan xuLy = new XuLyTaiKhoan();
        public frmThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmThemTaiKhoan_Load(object sender, EventArgs e)
        {
            dtgv_TaiKhoan.DataSource = xuLy.loadTaiKhoan(); //Load dữ liệu tài khoản lên datagridview

            cboMaLoaiTaiKhoan.DataSource = xuLy.loadLoaiTaiKhoan();
            cboMaLoaiTaiKhoan.DisplayMember = "TENLOAI";
            cboMaLoaiTaiKhoan.ValueMember = "MALOAI";

            xuLy.loadThemTatCaCombobox(xuLy.loadNhanVien(), "All", "Tất cả nhân viên", cboMaNhanVien, "HOTEN", "MANV");

            txtMatKhau.UseSystemPasswordChar = true;
            
        }

        private void dtgv_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_TaiKhoan.CurrentRow != null)
            {
                txtMaTaiKhoan.Text = dtgv_TaiKhoan.CurrentRow.Cells[0].Value.ToString();
                txtTenDN.Text = dtgv_TaiKhoan.CurrentRow.Cells[1].Value.ToString();
                cboMaNhanVien.Text = xuLy.traVeTenNhanVien(dtgv_TaiKhoan.CurrentRow.Cells[3].Value.ToString());
                cboMaLoaiTaiKhoan.Text = xuLy.traVeTenLoaiTK(dtgv_TaiKhoan.CurrentRow.Cells[2].Value.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Length == 0 || txtMatKhau.Text.Length == 0 || txtTenDN.Text.Length == 0)
            {
                MessageBox.Show("Mã tài khoản, tên đăng nhập, mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtMaTaiKhoan.Text.Length > 10)
                {
                    MessageBox.Show("Mã tài khoản không được vượt quá 10 kí tự!","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        if (cboMaNhanVien.SelectedValue.ToString() == "All")
                        {
                            MessageBox.Show("Xin vui lòng chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (xuLy.demSoTaiKhoan(cboMaNhanVien.SelectedValue.ToString()))
                            {
                                if (xuLy.ktKhoaChinh(txtMaTaiKhoan.Text))
                                {
                                    int maLoai = int.Parse(cboMaLoaiTaiKhoan.SelectedValue.ToString());
                                    if (xuLy.themTK(txtMaTaiKhoan.Text, txtTenDN.Text, txtMatKhau.Text, maLoai, cboMaNhanVien.SelectedValue.ToString()))
                                    {
                                        MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        DataTable dt = (DataTable)dtgv_TaiKhoan.DataSource;
                                        dt.Clear();
                                        dt = xuLy.loadTaiKhoan();
                                        dtgv_TaiKhoan.DataSource = dt;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mã tài khoản này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mỗi nhân viên chỉ được tạo 1 tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Xin vui lòng chọn nhân viên và loại tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Length == 0 || txtMatKhau.Text.Length == 0 || txtTenDN.Text.Length == 0)
            {
                MessageBox.Show("Mã tài khoản, tên đăng nhập, mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (!xuLy.ktKhoaChinh(txtMaTaiKhoan.Text))
                    {
                        int maLoai = int.Parse(cboMaLoaiTaiKhoan.SelectedValue.ToString());
                        if (xuLy.suaTK(txtMaTaiKhoan.Text, txtTenDN.Text, txtMatKhau.Text, maLoai))
                        {
                            MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_TaiKhoan.DataSource;
                            dt.Clear();
                            dt = xuLy.loadTaiKhoan();
                            dtgv_TaiKhoan.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã tài khoản này không tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }  
                }
                catch
                {
                    MessageBox.Show("Xin vui lòng chọn nhân viên và loại tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_TaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
