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
    public partial class frmQuanLy : Form
    {
        XuLySach xuLyS = new XuLySach();
        XuLyNhanVien xuLyNV = new XuLyNhanVien();
        XuLyDocGia xuLyDG = new XuLyDocGia();
        XuLyMuonSach xuLyMS = new XuLyMuonSach();
        XuLyThongKe xuLyTK = new XuLyThongKe();
        XuLyLoaiSachNhaXuatBan xuLyLSNXB = new XuLyLoaiSachNhaXuatBan();
        XuLyLuong xuLyL = new XuLyLuong();
        XuLyReport xuLyRP = new XuLyReport();
        public string quyenDN;
        public frmQuanLy()
        {
            InitializeComponent();
        }        

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            
            xuLyS.loadThemTatCaCombobox(xuLyS.loadLoaiSach(), "LSALL", "Tất cả loại sách", cboLoaiSach, "TENLOAI", "MALS"); //Load dữ liệu lên combobox loại sách                        
            xuLyS.loadThemTatCaCombobox(xuLyS.loadNXB(), "NXBALL", "Tất cả nhà xuất bản", cboNXB, "TENNXB", "MANXB"); //Load dữ liệu lên combobox nhà xuất bản
            dtgv_Sach.DataSource = xuLyS.loadSach(); //Load dữ liệu sách lên datagridview     

            xuLyNV.hienThiChucVu(trvChucVu);    //Hiển thị chức vụ lên treeview
            trvChucVu.ImageList = imageList1;
            dtgv_NhanVien.DataSource = xuLyNV.loadNhanVien();   //Load dữ liệu nhân viên lên datagridview


            //dateTimeNgaySinhNV.CustomFormat = "dd/MM/yyyy"; //Thiết lập kiểu dd/MM/yyyy cho ngày sinh nhân viên
            //dateTimeNgayVaoLamNV.CustomFormat = "dd/MM/yyyy"; //Thiết lập kiểu dd/MM/yyyy cho ngày vào làm nhân viên

            cboChucVu.DataSource = xuLyNV.loadChucVu(); //Load chức vụ lên combobox
            cboChucVu.DisplayMember = "TENCV";
            cboChucVu.ValueMember = "MACV";

            dtgv_DocGia.DataSource = xuLyDG.loadDocGia();   //Load dữ liệu cho datagridvew đọc giả

            dtgv_MuonSach.DataSource = xuLyMS.loadChiTietMuonSach();   //Load dữ liệu cho datagridvew chi tiết mượn sách
            dtgv_PhieuMuonSach.DataSource = xuLyMS.loadPhieuMuonSach(); //Load dữ liệu cho datagridview phiếu mượn sách

            cboSachMuon.DataSource = xuLyMS.loadSachCombobox(); //Load dữ liệu sách mượn lên combobox
            cboSachMuon.DisplayMember = "TENSACH";
            cboSachMuon.ValueMember = "MASACH";            

            cboDocGiaMuon.DataSource = xuLyMS.loadDocGiaCombobox(); //Load dữ liệu đọc giả mượn sách lên combobox
            cboDocGiaMuon.DisplayMember = "HOTEN";
            cboDocGiaMuon.ValueMember = "MADG";
            txtSoLuongSachHienCo.Text = 0.ToString();


            dtgv_TraSach.DataSource = xuLyMS.loadTraSach(); //Load dữ liệu bảng trả sách lên datagridview

            cboTraSach.DataSource = xuLyMS.loadSachComboboxTraSach();  //Load sách lên combobox trả sách
            cboTraSach.DisplayMember = "TENSACH";
            cboTraSach.ValueMember = "MASACH";

            cboMaMuonCapNhatLai.DataSource = xuLyMS.loadPhieuMuonSach_Edit();    //Load mã phiếu mượn sách lên combobox trả sách
            cboMaMuonCapNhatLai.DisplayMember = "MAMUON";
            cboMaMuonCapNhatLai.ValueMember = "MAMUON";

            dtgv_LoaiSach.DataSource = xuLyLSNXB.loadLoaiSach();    //Load dữ liệu loại sách lên datagridview
            dtgv_NhaXuatBan.DataSource = xuLyLSNXB.loadNhaXuatBan();    //Load dữ liệu nhà xuất bản lên datagridview

            dtgv_Luong.DataSource = xuLyL.loadLuong();  //Load dữ liệu lương lên datagridview

            cboMaNV_Luong.DataSource = xuLyL.loadNhanVien();    //Load tên nhân viên lên combobox
            cboMaNV_Luong.DisplayMember = "HOTEN";
            cboMaNV_Luong.ValueMember = "MANV";

            if (quyenDN == "User")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage7);
            }

            lblThongBaoMS.Visible = false;
            GbCapNhatPhieuMuon.Visible = false;
            txtSoNgayTre.Enabled = false;
            txtLuongThucNhan.Enabled = false;
            btnXoaTraSach.Visible = false;
        }

        public bool ktRadiobuttonGT(Panel p)
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

        public bool ktGroupBoxRadioButton(GroupBox gb)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rd = (RadioButton)gb.Controls[i];
                if (rd.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ktTreeViewChucVu(TreeView trv)
        {
            for (int i = 0; i < trv.Nodes.Count; i++)
            {
                if (trv.Nodes[i].IsSelected)
                {
                    return true;
                }
            }
            return false;
        }

        public void clearTreeView(TreeView trv)
        {
            trv.Nodes.Clear();
        }
       
        private void dtgv_Sach_SelectionChanged(object sender, EventArgs e)
        {
            
        }


        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Mã sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaSach.Text.Length > 10)
            {
                MessageBox.Show("Mã sách không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyS.ktKhoaChinhSach(txtMaSach.Text.Trim()))
                {
                    try
                    {
                        if (cboLoaiSach.SelectedValue.ToString() == "LSALL" || cboNXB.SelectedValue.ToString() == "NXBALL")
                        {
                            MessageBox.Show("Xin vui lòng chọn nhà xuất bản và loại sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string a = cboNXB.SelectedValue.ToString();
                            string b = cboLoaiSach.SelectedValue.ToString();
                            int sl, dg;
                            if (!Int32.TryParse(txtSoLuong.Text, out sl) || !Int32.TryParse(txtDonGia.Text, out dg))
                            {
                                MessageBox.Show("Số lượng và đơn giá phải là kiểu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string str = txtAnhSach.Text;
                                //string[] ten = str.Split('\\');
                                if (xuLyS.themSach(txtMaSach.Text, txtTenSach.Text, a, b, sl, dg, str))
                                {
                                    MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DataTable dt = (DataTable)dtgv_Sach.DataSource;
                                    dt.Clear();
                                    dt = xuLyS.loadSach();
                                    dtgv_Sach.DataSource = dt;

                                    DataTable dt1 = (DataTable)cboSachMuon.DataSource;
                                    dt1.Clear();
                                    dt1 = xuLyMS.loadSachCombobox();
                                    cboSachMuon.DataSource = dt1;

                                    DataTable dt2 = (DataTable)cboTraSach.DataSource;
                                    dt2.Clear();
                                    dt2 = xuLyMS.loadSachComboboxTraSach();
                                    cboTraSach.DataSource = dt2;
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Xin vui lòng chọn nhà xuất bản và loại sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã sách này đã tồn tại! Xin vui lòng nhập mã sách khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Thông tin về sách và thông tin mượn trả của quyển sách này cũng sẽ bị xóa!!", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaSach.Text.Length == 0)
                {
                    MessageBox.Show("Mã sách không được để trống! Xin vui lòng nhập mã sách muốn xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyS.ktKhoaChinhSach(txtMaSach.Text))
                    {
                        if (xuLyS.xoaSach(txtMaSach.Text))
                        {
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_Sach.DataSource;
                            dt.Clear();
                            dt = xuLyS.loadSach();
                            dtgv_Sach.DataSource = dt;

                            DataTable dt1 = (DataTable)cboSachMuon.DataSource;
                            dt1.Clear();
                            dt1 = xuLyMS.loadSachCombobox();
                            cboSachMuon.DataSource = dt1;

                            DataTable dt2 = (DataTable)cboTraSach.DataSource;
                            dt2.Clear();
                            dt2 = xuLyMS.loadSachComboboxTraSach();
                            cboTraSach.DataSource = dt2;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã sách này không tồn tại! Xin vui lòng nhập mã sách khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Mã sách không được để trống! Xin vui lòng mã sách muốn sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!xuLyS.ktKhoaChinhSach(txtMaSach.Text))
                {
                    if (cboLoaiSach.SelectedValue.ToString() == "LSALL" || cboNXB.SelectedValue.ToString() == "NXBALL")
                    {
                        MessageBox.Show("Xin vui lòng chọn nhà xuất bản và loại sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string a = cboNXB.SelectedValue.ToString();
                        string b = cboLoaiSach.SelectedValue.ToString();
                        int sl, dg;
                        if (!Int32.TryParse(txtSoLuong.Text, out sl) || !Int32.TryParse(txtDonGia.Text, out dg))
                        {
                            MessageBox.Show("Số lượng và đơn giá phải là kiểu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string str = txtAnhSach.Text;
                            //string[] ten = str.Split('\\');
                            if (xuLyS.suaSach(txtMaSach.Text, txtTenSach.Text, a, b, sl, dg, str))
                            {
                                MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_Sach.DataSource;
                                dt.Clear();
                                dt = xuLyS.loadSach();
                                dtgv_Sach.DataSource = dt;

                                DataTable dt1 = (DataTable)cboSachMuon.DataSource;
                                dt1.Clear();
                                dt1 = xuLyMS.loadSachCombobox();
                                cboSachMuon.DataSource = dt1;

                                DataTable dt2 = (DataTable)cboTraSach.DataSource;
                                dt2.Clear();
                                dt2 = xuLyMS.loadSachComboboxTraSach();
                                cboTraSach.DataSource = dt2;
                            }
                            else
                            {
                                MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã sách này không tồn tại! Xin vui lòng nhập mã sách khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void cboLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dtgv_Sach.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
            if (cboLoaiSach.SelectedIndex == 0)
            {
                dt = xuLyS.loadSach();
                dtgv_Sach.DataSource = dt;
            }
            if (cboLoaiSach.SelectedIndex > 0)
            {
                dt = xuLyS.loadSachLoaiSach(cboLoaiSach.SelectedValue.ToString());
                dtgv_Sach.DataSource = dt;
            }
        }

        private void cboNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dtgv_Sach.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
            if (cboNXB.SelectedIndex == 0)
            {
                dt = xuLyS.loadSach();
                dtgv_Sach.DataSource = dt;
            }
            if (cboNXB.SelectedIndex > 0)
            {
                dt = xuLyS.loadSachNXB(cboNXB.SelectedValue.ToString());
                dtgv_Sach.DataSource = dt;
            }
        }

        private void dtgv_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_Sach.CurrentRow != null)
            {
                txtMaSach.Text = dtgv_Sach.CurrentRow.Cells[0].Value.ToString();
                txtTenSach.Text = dtgv_Sach.CurrentRow.Cells[1].Value.ToString();
                txtDonGia.Text = dtgv_Sach.CurrentRow.Cells[5].Value.ToString();
                txtSoLuong.Text = dtgv_Sach.CurrentRow.Cells[4].Value.ToString();
                txtAnhSach.Text = dtgv_Sach.CurrentRow.Cells[6].Value.ToString();
                
                pictureBox1.Image = xuLyS.LoadHinh(txtAnhSach.Text);    //dùng image được đặt trong folder trong máy
                //Nếu sử dụng image đặt sẵn trong project thì ta dùng như sau:
                //Vị trí xuất phát của file thực thi debug (Application.StartupPath)
                //Các image được để trong file Resources sau đó copy file Resource vào -> bin -> debug 

                string maNXB = dtgv_Sach.CurrentRow.Cells[2].Value.ToString();
                string maLS = dtgv_Sach.CurrentRow.Cells[3].Value.ToString();
                cboLoaiSach.Text = xuLyS.traVeLoaiSach(maLS);
                cboNXB.Text = xuLyS.traVeNXB(maNXB);
            }
        }

        private void trvChucVu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < trvChucVu.Nodes.Count; i++)
            {
                TreeNode tn = trvChucVu.Nodes[i];
                if (tn.IsSelected)
                {
                    DataTable dt = (DataTable)dtgv_NhanVien.DataSource;
                    if (dt != null)
                    {
                        dt.Clear();
                    }
                    dt = xuLyNV.loadNhanVienTheoChucVu(tn.Text);
                    dtgv_NhanVien.DataSource = dt;
                }
            }
        }

        private void dtgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_NhanVien.CurrentRow != null)
            {
                txtMaNV.Text = dtgv_NhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dtgv_NhanVien.CurrentRow.Cells[1].Value.ToString();
                txtDiaChiNV.Text = dtgv_NhanVien.CurrentRow.Cells[2].Value.ToString();
                txtSDTNhanVien.Text = dtgv_NhanVien.CurrentRow.Cells[5].Value.ToString();
                dateTimeNgaySinhNV.Text = dtgv_NhanVien.CurrentRow.Cells[4].Value.ToString();
                dateTimeNgayVaoLamNV.Text = dtgv_NhanVien.CurrentRow.Cells[6].Value.ToString();
                txtAnhNV.Text = dtgv_NhanVien.CurrentRow.Cells[7].Value.ToString();
                int a = int.Parse(dtgv_NhanVien.CurrentRow.Cells[8].Value.ToString());
                cboChucVu.Text = xuLyNV.traVeChucVu(a);
                string gt = dtgv_NhanVien.CurrentRow.Cells[3].Value.ToString();
                for (int i = 0; i < panelGT.Controls.Count; i++)
                {
                    RadioButton rd = (RadioButton)panelGT.Controls[i];
                    if (rd.Text == gt)
                    {
                        rd.Checked = true;
                    }
                }

                pictureBox2.Image = xuLyNV.LoadHinh(txtAnhNV.Text);    //dùng image được đặt trong folder trong máy
            }
        }

        private void btnMoFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            openFileDialog1.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;   
             
                try
                {
                    pictureBox1.Image = xuLyS.LoadHinh(fileName);
                    txtAnhSach.Text = fileName;
                }
                catch
                {
                    MessageBox.Show("Ảnh này không tồn tại! Vui lòng kiểm tra lại đường dẫn hoặc loại file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMoFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            openFileDialog2.Filter = "Images files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                
                try
                {
                    pictureBox2.Image = xuLyNV.LoadHinh(fileName);
                    txtAnhNV.Text = fileName;
                }
                catch
                {
                    MessageBox.Show("Ảnh này không tồn tại! Vui lòng kiểm tra lại đường dẫn hoặc loại file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaNV.Text.Length > 10)
            {
                MessageBox.Show("Mã nhân viên không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtSDTNhanVien.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (xuLyNV.ktKhoaChinh(txtMaNV.Text))
                    {
                        if (ktRadiobuttonGT(panelGT))
                        {
                            string gt = "";
                            for (int i = 0; i < panelGT.Controls.Count; i++)
                            {
                                RadioButton rd = (RadioButton)panelGT.Controls[i];
                                if (rd.Checked)
                                {
                                    gt = rd.Text;
                                }
                            }
                            string str = txtAnhNV.Text;
                            int maCV = int.Parse(cboChucVu.SelectedValue.ToString());
                            DateTime ns = DateTime.Parse(dateTimeNgaySinhNV.Text);
                            DateTime nvl = DateTime.Parse(dateTimeNgayVaoLamNV.Text);
                            if (xuLyNV.themNV(txtMaNV.Text, txtTenNV.Text, txtDiaChiNV.Text, gt, ns, txtSDTNhanVien.Text, nvl, str, maCV))
                            {
                                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearTreeView(trvChucVu);
                                xuLyNV.hienThiChucVu(trvChucVu);

                                DataTable dt = (DataTable)dtgv_NhanVien.DataSource;
                                dt.Clear();
                                dt = xuLyNV.loadNhanVien();
                                dtgv_NhanVien.DataSource = dt;

                                DataTable dt1 = (DataTable)cboMaNV_Luong.DataSource;
                                dt1.Clear();
                                dt1 = xuLyL.loadNhanVien();
                                cboMaNV_Luong.DataSource = dt1;

                                DataTable dt2 = (DataTable)dtgv_Luong.DataSource;
                                dt2.Clear();
                                dt2 = xuLyL.loadLuong();
                                dtgv_Luong.DataSource = dt2;
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại! Xin vui lòng kiểm tra lại độ tuổi của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xin vui lòng chọn giới tính!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại! Xin vui lòng nhập mã nhân viên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Thông tin và tài khoản được cấp, lương của nhân viên này cũng sẽ bị xóa!", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyNV.ktKhoaChinh(txtMaNV.Text))
                    {
                        if (xuLyNV.xoaNV(txtMaNV.Text))
                        {
                            MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearTreeView(trvChucVu);
                            xuLyNV.hienThiChucVu(trvChucVu);

                            DataTable dt = (DataTable)dtgv_NhanVien.DataSource;
                            dt.Clear();
                            dt = xuLyNV.loadNhanVien();
                            dtgv_NhanVien.DataSource = dt;

                            DataTable dt1 = (DataTable)cboMaNV_Luong.DataSource;
                            dt1.Clear();
                            dt1 = xuLyL.loadNhanVien();
                            cboMaNV_Luong.DataSource = dt1;

                            DataTable dt2 = (DataTable)dtgv_Luong.DataSource;
                            dt2.Clear();
                            dt2 = xuLyL.loadLuong();
                            dtgv_Luong.DataSource = dt2;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên này không tồn tại! Xin vui lòng nhập lại mã nhân viên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bntSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtSDTNhanVien.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyNV.ktKhoaChinh(txtMaNV.Text))
                    {
                        if (ktRadiobuttonGT(panelGT))
                        {
                            string gt = "";
                            for (int i = 0; i < panelGT.Controls.Count; i++)
                            {
                                RadioButton rd = (RadioButton)panelGT.Controls[i];
                                if (rd.Checked)
                                {
                                    gt = rd.Text;
                                }
                            }
                            string str = txtAnhNV.Text;
                            int maCV = int.Parse(cboChucVu.SelectedValue.ToString());
                            DateTime ns = DateTime.Parse(dateTimeNgaySinhNV.Text);
                            DateTime nvl = DateTime.Parse(dateTimeNgayVaoLamNV.Text);
                            if (xuLyNV.suaNV(txtMaNV.Text, txtTenNV.Text, txtDiaChiNV.Text, gt, ns, txtSDTNhanVien.Text, nvl, str, maCV))
                            {
                                MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearTreeView(trvChucVu);
                                xuLyNV.hienThiChucVu(trvChucVu);
                                DataTable dt = (DataTable)dtgv_NhanVien.DataSource;
                                dt.Clear();
                                dt = xuLyNV.loadNhanVien();
                                dtgv_NhanVien.DataSource = dt;

                                DataTable dt1 = (DataTable)cboMaNV_Luong.DataSource;
                                dt1.Clear();
                                dt1 = xuLyL.loadNhanVien();
                                cboMaNV_Luong.DataSource = dt1;

                                DataTable dt2 = (DataTable)dtgv_Luong.DataSource;
                                dt2.Clear();
                                dt2 = xuLyL.loadLuong();
                                dtgv_Luong.DataSource = dt2;
                            }
                            else
                            {
                                MessageBox.Show("Sửa thất bại! Xin vui lòng kiểm tra lại độ tuổi của nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xin vui lòng chọn giới tính!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên này không tồn tại! Xin vui lòng nhập mã nhân viên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemChucVu_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Length == 0)
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyNV.themChucVu(txtChucVu.Text))
                {
                    MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTreeView(trvChucVu);
                    xuLyNV.hienThiChucVu(trvChucVu);
                    DataTable dt = (DataTable)cboChucVu.DataSource;
                    dt.Clear();
                    dt = xuLyNV.loadChucVu();
                    cboChucVu.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaChucVu_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (ktTreeViewChucVu(trvChucVu))
                {
                    string tenCV = "";
                    for (int i = 0; i < trvChucVu.Nodes.Count; i++)
                    {
                        if (trvChucVu.Nodes[i].IsSelected)
                        {
                            tenCV = trvChucVu.Nodes[i].Text;
                        }
                    }
                    if (xuLyNV.xoaChucVu(tenCV))
                    {
                        MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearTreeView(trvChucVu);
                        xuLyNV.hienThiChucVu(trvChucVu);
                        DataTable dt = (DataTable)cboChucVu.DataSource;
                        dt.Clear();
                        dt = xuLyNV.loadChucVu();
                        cboChucVu.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa chức vụ này vì chức vụ này có nhân viên đang đảm nhiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 chức vụ để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmDN.Show();
        }

        private void dtgv_DocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DocGia.CurrentRow != null)
            {
                txtMaDG.Text = dtgv_DocGia.CurrentRow.Cells[0].Value.ToString();
                txtTenDG.Text = dtgv_DocGia.CurrentRow.Cells[1].Value.ToString();
                txtDiaChiDG.Text = dtgv_DocGia.CurrentRow.Cells[2].Value.ToString();
                dateTimeNgaySinhDG.Text = dtgv_DocGia.CurrentRow.Cells[4].Value.ToString();
                txtSDTDocGia.Text = dtgv_DocGia.CurrentRow.Cells[5].Value.ToString();
                txtAnhDG.Text = dtgv_DocGia.CurrentRow.Cells[6].Value.ToString();
                string gt = dtgv_DocGia.CurrentRow.Cells[3].Value.ToString();
                for (int i = 0; i < panelGTDG.Controls.Count; i++)
                {
                    RadioButton rd = (RadioButton)panelGTDG.Controls[i];
                    if (rd.Text == gt)
                    {
                        rd.Checked = true;
                    }
                }

                pictureBox3.Image = xuLyDG.LoadHinh(txtAnhDG.Text);
            }
        }

        private void btnSearchTenDG_Click(object sender, EventArgs e)
        {
            if (txtSearchTenDG.Text.Length > 0)
            {
                DataTable dt = (DataTable)dtgv_DocGia.DataSource;
                if (dt != null)
                {
                    dt.Clear();
                }
                dt = xuLyDG.loadDocGiaTheoTen(txtSearchTenDG.Text);
                dtgv_DocGia.DataSource = dt;
            }
            else
            {
                dtgv_DocGia.DataSource = xuLyDG.loadDocGia();
            }
        }

        private void btnMoFile3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            openFileDialog3.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog3.FilterIndex = 1;
            openFileDialog3.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
              
                try
                {
                    pictureBox3.Image = xuLyDG.LoadHinh(fileName);
                    txtAnhDG.Text = fileName;
                }
                catch
                {
                    MessageBox.Show("Ảnh này không tồn tại! Vui lòng kiểm tra lại đường dẫn hoặc loại file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text.Length == 0)
            {
                MessageBox.Show("Mã đọc giả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaDG.Text.Length > 10)
            {
                MessageBox.Show("Mã đọc giả không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtSDTDocGia.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (xuLyDG.ktKhoaChinh(txtMaDG.Text))
                    {
                        if (ktRadiobuttonGT(panelGTDG))
                        {
                            string gt = "";
                            for (int i = 0; i < panelGTDG.Controls.Count; i++)
                            {
                                RadioButton rd = (RadioButton)panelGTDG.Controls[i];
                                if (rd.Checked)
                                {
                                    gt = rd.Text;
                                }
                            }
                            DateTime ns = DateTime.Parse(dateTimeNgaySinhDG.Text);
                            if (xuLyDG.themDG(txtMaDG.Text, txtTenDG.Text, txtDiaChiDG.Text, gt, ns, txtSDTDocGia.Text, txtAnhDG.Text))
                            {
                                MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_DocGia.DataSource;
                                dt.Clear();
                                dt = xuLyDG.loadDocGia();
                                dtgv_DocGia.DataSource = dt;

                                DataTable dt1 = (DataTable)cboDocGiaMuon.DataSource;
                                dt1.Clear();
                                dt1 = xuLyMS.loadDocGiaCombobox();
                                cboDocGiaMuon.DataSource = dt1;
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn giới tính của đọc giả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã đọc giả này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSuaDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text.Length == 0)
            {
                MessageBox.Show("Mã đọc giả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtSDTDocGia.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyDG.ktKhoaChinh(txtMaDG.Text))
                    {
                        if (ktRadiobuttonGT(panelGTDG))
                        {
                            string gt = "";
                            for (int i = 0; i < panelGTDG.Controls.Count; i++)
                            {
                                RadioButton rd = (RadioButton)panelGTDG.Controls[i];
                                if (rd.Checked)
                                {
                                    gt = rd.Text;
                                }
                            }
                            DateTime ns = DateTime.Parse(dateTimeNgaySinhDG.Text);
                            if (xuLyDG.suaDG(txtMaDG.Text, txtTenDG.Text, txtDiaChiDG.Text, gt, ns, txtSDTDocGia.Text, txtAnhDG.Text))
                            {
                                MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_DocGia.DataSource;
                                dt.Clear();
                                dt = xuLyDG.loadDocGia();
                                dtgv_DocGia.DataSource = dt;

                                DataTable dt1 = (DataTable)cboDocGiaMuon.DataSource;
                                dt1.Clear();
                                dt1 = xuLyMS.loadDocGiaCombobox();
                                cboDocGiaMuon.DataSource = dt1;
                            }
                            else
                            {
                                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn giới tính của đọc giả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã đọc giả này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Mọi thông tin về mượn và trả sách của đọc giả này cũng sẽ bị xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaDG.Text.Length == 0)
                {
                    MessageBox.Show("Mã đọc giả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyDG.ktKhoaChinh(txtMaDG.Text))
                    {
                        if (xuLyDG.ktDocGiaMuonSach(txtMaDG.Text))
                        {
                            if (xuLyDG.xoaDG(txtMaDG.Text))
                            {
                                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_DocGia.DataSource;
                                dt.Clear();
                                dt = xuLyDG.loadDocGia();
                                dtgv_DocGia.DataSource = dt;

                                DataTable dt1 = (DataTable)cboDocGiaMuon.DataSource;
                                dt1.Clear();
                                dt1 = xuLyMS.loadDocGiaCombobox();
                                cboDocGiaMuon.DataSource = dt1;
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa đọc giả này! Đọc giả này hiện đang mượn sách và chưa trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã đọc giả này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgv_MuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_MuonSach.CurrentRow != null)
            {
                txtMaMS.Text = dtgv_MuonSach.CurrentRow.Cells[0].Value.ToString();
                cboSachMuon.Text = xuLyMS.traVeTenSach(dtgv_MuonSach.CurrentRow.Cells[1].Value.ToString());
                dateTimeNgayMuonSach.Text = dtgv_MuonSach.CurrentRow.Cells[2].Value.ToString();
                dateTimeNgaySeTraSach.Text = dtgv_MuonSach.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void cboKTSoLuongSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThemMS_Click(object sender, EventArgs e)
        {
            if (txtMaMS.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaMS.Text.Length > 10)
            {
                MessageBox.Show("Mã mượn sách không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int sl = int.Parse(txtSoLuongSachHienCo.Text);
                if (sl <= 1)
                {
                    MessageBox.Show("Thư viện đã hết sách này! Không thể cho mượn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (xuLyMS.ktKhoaNgoaiPMS(txtMaMS.Text))
                    {                        
                        if (xuLyMS.ktKhoaChinhCTMS(txtMaMS.Text, cboSachMuon.SelectedValue.ToString()))
                        {
                            DateTime ngayMuon = DateTime.Now;
                            DateTime ngaySeTra = ngayMuon.AddDays(7);
                            if (xuLyMS.themCTMuonSach(txtMaMS.Text, cboSachMuon.SelectedValue.ToString(), ngayMuon, ngaySeTra))
                            {
                                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_MuonSach.DataSource;
                                dt.Clear();
                                dt = xuLyMS.loadChiTietMuonSach();
                                dtgv_MuonSach.DataSource = dt;

                                DataTable dt2 = (DataTable)cboSachMuon.DataSource;
                                dt2.Clear();
                                dt2 = xuLyMS.loadSachCombobox();
                                cboSachMuon.DataSource = dt2;

                                DataTable dt3 = (DataTable)dtgv_PhieuMuonSach.DataSource;
                                dt3.Clear();
                                dt3 = xuLyMS.loadPhieuMuonSach_Edit();
                                dtgv_PhieuMuonSach.DataSource = dt3;
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chi tiết mượn sách này đã tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này chưa tồn tại! Xin vui lòng thêm phiếu mượn sách bên dưới có mã này và quay lại thêm chi tiết mượn sách này sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnSuaMS_Click(object sender, EventArgs e)
        {
            if (txtMaMS.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyMS.ktKhoaNgoaiPMS(txtMaMS.Text))
                {
                    if (!xuLyMS.ktKhoaChinhCTMS(txtMaMS.Text, cboSachMuon.SelectedValue.ToString()))
                    {
                        DateTime ngayMuon = DateTime.Parse(dateTimeNgayMuonSach.Text);
                        DateTime ngaySeTra = DateTime.Parse(dateTimeNgaySeTraSach.Text);
                        if (xuLyMS.suaCTMuonSach(txtMaMS.Text, cboSachMuon.SelectedValue.ToString(), ngayMuon, ngaySeTra))
                        {
                            MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                            dt.Clear();
                            dt = xuLyMS.loadPhieuMuonSach_Edit();
                            dtgv_PhieuMuonSach.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã mượn sách này chưa tồn tại! Xin vui lòng thêm phiếu mượn sách bên dưới có mã này và quay lại thêm chi tiết mượn sách này sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboSachMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sl = xuLyMS.traVeSoLuongSach(cboSachMuon.SelectedValue.ToString());
            txtSoLuongSachHienCo.Text = sl.ToString();
        }

        private void dtgv_PhieuMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_PhieuMuonSach.CurrentRow != null)
            {
                txtMaPhieuMuonSach.Text = dtgv_PhieuMuonSach.CurrentRow.Cells[0].Value.ToString();
                cboDocGiaMuon.Text = xuLyMS.traVeTenDG(dtgv_PhieuMuonSach.CurrentRow.Cells[1].Value.ToString());
                txtTinhTrang.Text = dtgv_PhieuMuonSach.CurrentRow.Cells[2].Value.ToString();
                txtTienPhat.Text = dtgv_PhieuMuonSach.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThemPhieuMS_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuMuonSach.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaPhieuMuonSach.Text.Length > 10)
            {
                MessageBox.Show("Mã mượn sách không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyMS.ktKhoaChinhPhieuMS(txtMaPhieuMuonSach.Text))
                {
                    if (xuLyMS.themPhieuMuonSach(txtMaPhieuMuonSach.Text, cboDocGiaMuon.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                        dt.Clear();
                        dt = xuLyMS.loadPhieuMuonSach_Edit();
                        dtgv_PhieuMuonSach.DataSource = dt;

                        DataTable dt1 = (DataTable)cboMaMuonCapNhatLai.DataSource;
                        dt1.Clear();
                        dt1 = xuLyMS.loadPhieuMuonSach_Edit();
                        cboMaMuonCapNhatLai.DataSource = dt1;
                        cboMaMuonCapNhatLai.DisplayMember = "MAMUON";
                        cboMaMuonCapNhatLai.ValueMember = "MAMUON";
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã mượn sách này đã tồn tại! Xin vui lòng thử lại mã mượn sách khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaPhieuMS_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuMuonSach.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else
            {
                if (!xuLyMS.ktKhoaChinhPhieuMS(txtMaPhieuMuonSach.Text))
                {
                    float a;
                    if (float.TryParse(txtTienPhat.Text, out a))
                    {
                        if (xuLyMS.suaPhieuMuonSach(txtMaPhieuMuonSach.Text, cboDocGiaMuon.SelectedValue.ToString(), txtTinhTrang.Text,a))
                        {
                            MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                            dt.Clear();
                            dt = xuLyMS.loadPhieuMuonSach_Edit();
                            dtgv_PhieuMuonSach.DataSource = dt;

                            DataTable dt1 = (DataTable)cboMaMuonCapNhatLai.DataSource;
                            dt1.Clear();
                            dt1 = xuLyMS.loadPhieuMuonSach_Edit();
                            cboMaMuonCapNhatLai.DataSource = dt1;
                            cboMaMuonCapNhatLai.DisplayMember = "MAMUON";
                            cboMaMuonCapNhatLai.ValueMember = "MAMUON";
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tiền phạt phải là kiểu dữ liệu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã mượn sách này không tồn tại! Xin vui lòng thử lại mã mượn sách khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaPhieuMS_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Thông tin chi tiết phiếu mượn sách và thông tin trả sách của phiếu mượn này cũng sẽ bị xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaPhieuMuonSach.Text.Length == 0)
                {
                    MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyMS.ktKhoaChinhPhieuMS(txtMaPhieuMuonSach.Text))
                    {
                        if (xuLyMS.ktPhieuMuonSachChuaTra(txtMaPhieuMuonSach.Text))
                        {
                            if (xuLyMS.xoaPhieuMuonSach(txtMaPhieuMuonSach.Text))
                            {
                                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                                dt.Clear();
                                dt = xuLyMS.loadPhieuMuonSach_Edit();
                                dtgv_PhieuMuonSach.DataSource = dt;

                                DataTable dt1 = (DataTable)cboMaMuonCapNhatLai.DataSource;
                                dt1.Clear();
                                dt1 = xuLyMS.loadPhieuMuonSach_Edit();
                                cboMaMuonCapNhatLai.DataSource = dt1;
                                cboMaMuonCapNhatLai.DisplayMember = "MAMUON";
                                cboMaMuonCapNhatLai.ValueMember = "MAMUON";

                                DataTable dt2 = (DataTable)dtgv_MuonSach.DataSource;
                                dt2.Clear();
                                dt2 = xuLyMS.loadChiTietMuonSach();
                                dtgv_MuonSach.DataSource = dt2;

                                DataTable dt3 = (DataTable)dtgv_TraSach.DataSource;
                                dt3.Clear();
                                dt3 = xuLyMS.loadTraSach();
                                dtgv_TraSach.DataSource = dt3;
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phiếu mượn sách này vì phiếu mượn sách này có mượn sách và chưa trả", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này không tồn tại! Xin vui lòng thử lại mã mượn sách khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemMS_MouseHover(object sender, EventArgs e)
        {
            lblThongBaoMS.Visible = true;
        }

        private void btnThemMS_MouseLeave(object sender, EventArgs e)
        {
            lblThongBaoMS.Visible = false;
        }

        private void btnXoaCTMS_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Thông tin trả sách của chi tiết mượn sách này cũng sẽ bị xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaMS.Text.Length == 0)
                {
                    MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (xuLyMS.ktKhoaNgoaiPMS(txtMaMS.Text))
                    {
                        if (xuLyMS.ktChiTietMuonSachChuaTra(txtMaMS.Text))
                        {
                            if (!xuLyMS.ktKhoaChinhCTMS(txtMaMS.Text, cboSachMuon.SelectedValue.ToString()))
                            {
                                DateTime ngayMuon = DateTime.Parse(dateTimeNgayMuonSach.Text);
                                DateTime ngaySeTra = DateTime.Parse(dateTimeNgaySeTraSach.Text);
                                if (xuLyMS.xoaCTMuonSach(txtMaMS.Text, cboSachMuon.SelectedValue.ToString()))
                                {
                                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                                    dt.Clear();
                                    dt = xuLyMS.loadPhieuMuonSach_Edit();
                                    dtgv_PhieuMuonSach.DataSource = dt;

                                    DataTable dt1 = (DataTable)dtgv_TraSach.DataSource;
                                    dt1.Clear();
                                    dt1 = xuLyMS.loadTraSach();
                                    dtgv_TraSach.DataSource = dt1;
                                }
                                else
                                {
                                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã mượn sách này không tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa chi tiết mượn sách này vì chi tiết mượn sách này chưa trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này chưa tồn tại! Xin vui lòng thêm phiếu mượn sách bên dưới có mã này và quay lại thêm chi tiết mượn sách này sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgv_TraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_TraSach.CurrentRow != null)
            {
                string maMuon = dtgv_TraSach.CurrentRow.Cells[0].Value.ToString();
                txtMaMSTra.Text = maMuon;
                dateTimeNgayTraSach.Text = dtgv_TraSach.CurrentRow.Cells[2].Value.ToString();
                cboTraSach.Text = xuLyMS.traVeTenSach(dtgv_TraSach.CurrentRow.Cells[1].Value.ToString());
                DateTime ngayTra = DateTime.Parse(dateTimeNgayTraSach.Text);
                DateTime ngaySeTra = xuLyMS.traVeNgaySeTra(maMuon, cboTraSach.SelectedValue.ToString());
                txtSoNgayTre.Text = xuLyMS.tinhNgayTre(ngaySeTra, ngayTra) + "";
            }
        }

        private void btnThemTraSach_Click(object sender, EventArgs e)
        {
            if (txtMaMSTra.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaMSTra.Text.Length > 10)
            {
                MessageBox.Show("Mã mượn sách không được quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyMS.ktKhoaChinh(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
                {
                    if (xuLyMS.ktKhoaNgoai(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
                    {
                        DateTime ngayTra = DateTime.Parse(dateTimeNgayTraSach.Text);
                        if (xuLyMS.themTraSach(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString(), ngayTra))
                        {
                            MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                            dt.Clear();
                            dt = xuLyMS.loadPhieuMuonSach_Edit();
                            dtgv_PhieuMuonSach.DataSource = dt;

                            DataTable dt1 = (DataTable)dtgv_MuonSach.DataSource;
                            dt1.Clear();
                            dt1 = xuLyMS.loadChiTietMuonSach();
                            dtgv_MuonSach.DataSource = dt1;

                            DataTable dt2 = (DataTable)dtgv_TraSach.DataSource;
                            dt2.Clear();
                            dt2 = xuLyMS.loadTraSach();
                            dtgv_TraSach.DataSource = dt2;

                            DataTable dt3 = (DataTable)cboSachMuon.DataSource;
                            dt3.Clear();
                            dt3 = xuLyMS.loadSachCombobox();
                            cboSachMuon.DataSource = dt3;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này không có trong chi tiết phiếu mượn sách! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã mượn sách này đã tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaTraSach_Click(object sender, EventArgs e)
        {
            if (txtMaMSTra.Text.Length == 0)
            {
                MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!xuLyMS.ktKhoaChinh(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
                {
                    if (xuLyMS.ktKhoaNgoai(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
                    {
                        DateTime ngayTra = DateTime.Parse(dateTimeNgayTraSach.Text);
                        if (xuLyMS.suaTraSach(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString(), ngayTra))
                        {
                            MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                            dt.Clear();
                            dt = xuLyMS.loadPhieuMuonSach_Edit();
                            dtgv_PhieuMuonSach.DataSource = dt;

                            DataTable dt2 = (DataTable)dtgv_TraSach.DataSource;
                            dt2.Clear();
                            dt2 = xuLyMS.loadTraSach();
                            dtgv_TraSach.DataSource = dt2;

                            DataTable dt3 = (DataTable)cboSachMuon.DataSource;
                            dt3.Clear();
                            dt3 = xuLyMS.loadSachCombobox();
                            cboSachMuon.DataSource = dt3;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã mượn sách này không có trong chi tiết phiếu mượn sách! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã mượn sách này không tồn tại nên không thể sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaTraSach_Click(object sender, EventArgs e)
        {
            //DialogResult r;
            //r = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    if (txtMaMSTra.Text.Length == 0)
            //    {
            //        MessageBox.Show("Mã mượn sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (!xuLyMS.ktKhoaChinh(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
            //        {
            //            if (xuLyMS.ktKhoaNgoai(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
            //            {
            //                DateTime ngayTra = DateTime.Parse(dateTimeNgayTraSach.Text);
            //                if (xuLyMS.xoaTraSach(txtMaMSTra.Text, cboTraSach.SelectedValue.ToString()))
            //                {
            //                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
            //                    dt.Clear();
            //                    dt = xuLyMS.loadPhieuMuonSach_Edit();
            //                    dtgv_PhieuMuonSach.DataSource = dt;

            //                    DataTable dt3 = (DataTable)cboSachMuon.DataSource;
            //                    dt3.Clear();
            //                    dt3 = xuLyMS.loadSachCombobox();
            //                    cboSachMuon.DataSource = dt3;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Mã mượn sách này không có trong chi tiết phiếu mượn sách! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Mã mượn sách này không tồn tại nên không thể sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void ckbCapNhatLaiPhieuMuon_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCapNhatLaiPhieuMuon.Checked)
            {
                GbCapNhatPhieuMuon.Visible = true;
            }
            else
            {
                GbCapNhatPhieuMuon.Visible = false;
            }
        }

        private void btnLuuCapNhatTra_Click(object sender, EventArgs e)
        {
            float a;
            if (float.TryParse(txtCapNhatTienPhat.Text, out a))
            {
                string maDG = xuLyMS.traVeMaDG(cboMaMuonCapNhatLai.SelectedValue.ToString());
                if (xuLyMS.suaPhieuMuonSach(cboMaMuonCapNhatLai.SelectedValue.ToString(), maDG,txtCapNhatTinhTrangPM.Text, a))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dt = (DataTable)dtgv_PhieuMuonSach.DataSource;
                    dt.Clear();
                    dt = xuLyMS.loadPhieuMuonSach_Edit();
                    dtgv_PhieuMuonSach.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tiền phạt phải là kiểu dữ liệu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyCapNhatTra_Click(object sender, EventArgs e)
        {
            txtCapNhatTienPhat.Clear();
            txtCapNhatTinhTrangPM.Clear();
            ckbCapNhatLaiPhieuMuon.Checked = false;
        }

        private void btnSearchTenSach_Click(object sender, EventArgs e)
        {
            if (txtSearchSach.Text.Length > 0)
            {
                DataTable dt = (DataTable)dtgv_Sach.DataSource;
                if (dt != null)
                {
                    dt.Clear();
                }
                dt = xuLyS.timKiemSach(txtSearchSach.Text);
                dtgv_Sach.DataSource = dt;
            }
            else
            {
                dtgv_Sach.DataSource = xuLyS.loadSach();
            }
        }

        private void btnTinhTienPhat_Click(object sender, EventArgs e)
        {
            double a;
            if (Double.TryParse(txtSoTienPhatTrenNgay.Text, out a))
            {
                double b = double.Parse(txtSoNgayTre.Text);
                double kq = a * b;
                txtSoTienDGPhaiTra.Text = kq.ToString();
            }
            else
            {
                MessageBox.Show("Tiền phạt phải là kiểu dữ liệu số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dtgv_ThongKe.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
            if (ktGroupBoxRadioButton(gb_ThongKe))
            {
                for (int i = 0; i < gb_ThongKe.Controls.Count; i++)
                {
                    RadioButton rd = (RadioButton)gb_ThongKe.Controls[i];
                    if (rd.Checked)
                    {
                        switch (rd.Name)
                        {
                            case "rdoThongKeSachMuon":
                                dt = xuLyTK.loadSachDangChoMuon();
                                dtgv_ThongKe.DataSource = dt;
                                dtgv_ThongKe = xuLyTK.thietLapHeaderText(dtgv_ThongKe, "Mã sách", "Tên sách", "Mã NXB", "Mã loại sách", "Số lượng", "Đơn giá", "Hình","Ngày mượn","Ngày trả","Tên đọc giả");
                                break;
                            case "rdoThongKeSachChuaMuon":
                                dt = xuLyTK.loadSachChuaChoMuon();
                                dtgv_ThongKe.DataSource = dt;
                                dtgv_ThongKe = xuLyTK.thietLapHeaderText(dtgv_ThongKe, "Mã sách", "Tên sách", "Mã NXB", "Mã loại sách", "Số lượng", "Đơn giá", "Hình");
                                break;
                            case "rdoThongKeSachMuonChuaTra":
                                dt = xuLyTK.loadSachMuonChuaTra();
                                dtgv_ThongKe.DataSource = dt;
                                dtgv_ThongKe = xuLyTK.thietLapHeaderText(dtgv_ThongKe, "Mã sách", "Tên sách", "Mã NXB", "Mã loại sách", "Số lượng", "Đơn giá", "Hình", "Ngày mượn", "Ngày sẽ trả", "Tên đọc giả mượn");
                                break;
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng 1 chọn mục muốn thống kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgv_LoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_LoaiSach.CurrentRow != null)
            {
                txtMaLoaiSach.Text = dtgv_LoaiSach.CurrentRow.Cells[0].Value.ToString();
                txtTenLoaiSach.Text = dtgv_LoaiSach.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void dtgv_NhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_NhaXuatBan.CurrentRow != null)
            {
                txtMaNhaXuatBan.Text = dtgv_NhaXuatBan.CurrentRow.Cells[0].Value.ToString();
                txtTenNhaXuatBan.Text = dtgv_NhaXuatBan.CurrentRow.Cells[1].Value.ToString();
                txtDiaChiNhaXuatBan.Text = dtgv_NhaXuatBan.CurrentRow.Cells[2].Value.ToString();
                txtDienThoaiNhaXuatBan.Text = dtgv_NhaXuatBan.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThemLoaiSach_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSach.Text.Length == 0 || txtTenLoaiSach.Text.Length == 0)
            {
                MessageBox.Show("Mã loại sách, tên loại sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaLoaiSach.Text.Length > 10)
            {
                MessageBox.Show("Mã loại sách không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyLSNXB.ktKhoaChinhLoaiSach(txtMaLoaiSach.Text))
                {
                    if (xuLyLSNXB.themLoaiSach(txtMaLoaiSach.Text, txtTenLoaiSach.Text))
                    {
                        MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = (DataTable)cboLoaiSach.DataSource;
                        dt.Clear();
                        xuLyS.loadThemTatCaCombobox(xuLyS.loadLoaiSach(), "LSALL", "Tất cả loại sách", cboLoaiSach, "TENLOAI", "MALS");

                        DataTable dt1 = (DataTable)dtgv_LoaiSach.DataSource;
                        dt1.Clear();
                        dt1 = xuLyLSNXB.loadLoaiSach();
                        dtgv_LoaiSach.DataSource = dt1;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã loại sách này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaLoaiSach_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSach.Text.Length == 0 || txtTenLoaiSach.Text.Length == 0)
            {
                MessageBox.Show("Mã loại sách, tên loại sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!xuLyLSNXB.ktKhoaChinhLoaiSach(txtMaLoaiSach.Text))
                {
                    if (xuLyLSNXB.suaLoaiSach(txtMaLoaiSach.Text, txtTenLoaiSach.Text))
                    {
                        MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = (DataTable)cboLoaiSach.DataSource;
                        dt.Clear();
                        xuLyS.loadThemTatCaCombobox(xuLyS.loadLoaiSach(), "LSALL", "Tất cả loại sách", cboLoaiSach, "TENLOAI", "MALS");

                        DataTable dt1 = (DataTable)dtgv_LoaiSach.DataSource;
                        dt1.Clear();
                        dt1 = xuLyLSNXB.loadLoaiSach();
                        dtgv_LoaiSach.DataSource = dt1;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã loại sách này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaLoaiSach_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Những cuốn sách thể loại này cũng sẽ bị xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaLoaiSach.Text.Length == 0)
                {
                    MessageBox.Show("Mã loại sách không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyLSNXB.ktKhoaChinhLoaiSach(txtMaLoaiSach.Text))
                    {
                        if (xuLyLSNXB.xoaLoaiSach(txtMaLoaiSach.Text))
                        {
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)cboLoaiSach.DataSource;
                            dt.Clear();
                            xuLyS.loadThemTatCaCombobox(xuLyS.loadLoaiSach(), "LSALL", "Tất cả loại sách", cboLoaiSach, "TENLOAI", "MALS");

                            DataTable dt1 = (DataTable)dtgv_LoaiSach.DataSource;
                            dt1.Clear();
                            dt1 = xuLyLSNXB.loadLoaiSach();
                            dtgv_LoaiSach.DataSource = dt1;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã loại sách này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemNhaXuatBan_Click(object sender, EventArgs e)
        {
            if (txtMaNhaXuatBan.Text.Length == 0 || txtTenNhaXuatBan.Text.Length == 0)
            {
                MessageBox.Show("Mã nhà xuất bản, tên nhà xuất bản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaNhaXuatBan.Text.Length > 10)
            {
                MessageBox.Show("Mã nhà xuất bản không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtDienThoaiNhaXuatBan.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (xuLyLSNXB.ktKhoaChinhNhaXuatBan(txtMaNhaXuatBan.Text))
                    {
                        if (xuLyLSNXB.themNXB(txtMaNhaXuatBan.Text, txtTenNhaXuatBan.Text, txtDiaChiNhaXuatBan.Text, txtDienThoaiNhaXuatBan.Text))
                        {
                            MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)cboNXB.DataSource;
                            dt.Clear();
                            xuLyS.loadThemTatCaCombobox(xuLyS.loadNXB(), "NXBALL", "Tất cả nhà xuất bản", cboNXB, "TENNXB", "MANXB");

                            DataTable dt1 = (DataTable)dtgv_NhaXuatBan.DataSource;
                            dt1.Clear();
                            dt1 = xuLyLSNXB.loadNhaXuatBan();
                            dtgv_NhaXuatBan.DataSource = dt1;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà xuất bản này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSuaNhaXuatBan_Click(object sender, EventArgs e)
        {
            if (txtMaNhaXuatBan.Text.Length == 0 || txtTenNhaXuatBan.Text.Length == 0)
            {
                MessageBox.Show("Mã nhà xuất bản, tên nhà xuất bản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtDienThoaiNhaXuatBan.Text.Length > 12)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyLSNXB.ktKhoaChinhNhaXuatBan(txtMaNhaXuatBan.Text))
                    {
                        if (xuLyLSNXB.suaNXB(txtMaNhaXuatBan.Text, txtTenNhaXuatBan.Text, txtDiaChiNhaXuatBan.Text, txtDienThoaiNhaXuatBan.Text))
                        {
                            MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)cboNXB.DataSource;
                            dt.Clear();
                            xuLyS.loadThemTatCaCombobox(xuLyS.loadNXB(), "NXBALL", "Tất cả nhà xuất bản", cboNXB, "TENNXB", "MANXB");

                            DataTable dt1 = (DataTable)dtgv_NhaXuatBan.DataSource;
                            dt1.Clear();
                            dt1 = xuLyLSNXB.loadNhaXuatBan();
                            dtgv_NhaXuatBan.DataSource = dt1;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà xuất bản này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoaNhaXuatBan_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không? Những cuốn sách nhà xuất bản loại này cũng sẽ bị xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaNhaXuatBan.Text.Length == 0)
                {
                    MessageBox.Show("Mã nhà xuất bản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyLSNXB.ktKhoaChinhNhaXuatBan(txtMaNhaXuatBan.Text))
                    {
                        if (xuLyLSNXB.xoaNXB(txtMaNhaXuatBan.Text))
                        {
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)cboNXB.DataSource;
                            dt.Clear();
                            xuLyS.loadThemTatCaCombobox(xuLyS.loadNXB(), "NXBALL", "Tất cả nhà xuất bản", cboNXB, "TENNXB", "MANXB");

                            DataTable dt1 = (DataTable)dtgv_NhaXuatBan.DataSource;
                            dt1.Clear();
                            dt1 = xuLyLSNXB.loadNhaXuatBan();
                            dtgv_NhaXuatBan.DataSource = dt1;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà xuất bản này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgv_Luong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_Luong.CurrentRow != null)
            {
                txtMaPhat.Text = dtgv_Luong.CurrentRow.Cells[0].Value.ToString();
                dateTimeNgayPhatLuong.Text = dtgv_Luong.CurrentRow.Cells[2].Value.ToString();
                txtSoNgayLamViec.Text = dtgv_Luong.CurrentRow.Cells[4].Value.ToString();
                txtLuongDinhMuc.Text = dtgv_Luong.CurrentRow.Cells[3].Value.ToString();
                txtLuongThucNhan.Text = dtgv_Luong.CurrentRow.Cells[5].Value.ToString();
                cboMaNV_Luong.Text = xuLyL.traVeTenNhanVien(dtgv_Luong.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void btnThemLuong_Click(object sender, EventArgs e)
        {
            if (txtMaPhat.Text.Length == 0)
            {
                MessageBox.Show("Mã phát lương không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMaPhat.Text.Length > 10)
            {
                MessageBox.Show("Mã phát lương không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyL.ktKhoaChinh(txtMaPhat.Text))
                {
                    DateTime ngayPhat = DateTime.Parse(dateTimeNgayPhatLuong.Text);
                    int luongDM, soNgay;
                    if (Int32.TryParse(txtLuongDinhMuc.Text, out luongDM) && Int32.TryParse(txtSoNgayLamViec.Text, out soNgay))
                    {
                        int luong = int.Parse(txtLuongThucNhan.Text);
                        if (xuLyL.themLuong(txtMaPhat.Text, cboMaNV_Luong.SelectedValue.ToString(), ngayPhat, luongDM, soNgay, luong))
                        {
                            MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_Luong.DataSource;
                            dt.Clear();
                            dt = xuLyL.loadLuong();
                            dtgv_Luong.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lương định mức và số ngày làm việc phải là kiểu số nguyên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phát lương này đã tồn tại! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtLuongDinhMuc_TextChanged(object sender, EventArgs e)
        {
            int soNgay, luongDM;
            int luong = 0;
            if (Int32.TryParse(txtLuongDinhMuc.Text, out luongDM) && Int32.TryParse(txtSoNgayLamViec.Text, out soNgay))
            {
                luong = soNgay * luongDM;
                txtLuongThucNhan.Text = luong.ToString();
            }
        }

        private void txtSoNgayLamViec_TextChanged(object sender, EventArgs e)
        {
            int soNgay, luongDM;
            int luong = 0;
            if (Int32.TryParse(txtLuongDinhMuc.Text, out luongDM) && Int32.TryParse(txtSoNgayLamViec.Text, out soNgay))
            {
                luong = soNgay * luongDM;
                txtLuongThucNhan.Text = luong.ToString();
            }
        }

        private void btnSuaLuong_Click(object sender, EventArgs e)
        {
            if (txtMaPhat.Text.Length == 0)
            {
                MessageBox.Show("Mã phát lương không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!xuLyL.ktKhoaChinh(txtMaPhat.Text))
                {
                    DateTime ngayPhat = DateTime.Parse(dateTimeNgayPhatLuong.Text);
                    int luongDM, soNgay;
                    if (Int32.TryParse(txtLuongDinhMuc.Text, out luongDM) && Int32.TryParse(txtSoNgayLamViec.Text, out soNgay))
                    {

                        int luong = int.Parse(txtLuongThucNhan.Text);
                        if (xuLyL.suaLuong(txtMaPhat.Text, cboMaNV_Luong.SelectedValue.ToString(), ngayPhat, luongDM, soNgay, luong))
                        {
                            MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_Luong.DataSource;
                            dt.Clear();
                            dt = xuLyL.loadLuong();
                            dtgv_Luong.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lương định mức và số ngày làm việc phải là kiểu số nguyên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phát lương này không tồn tại! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaLuong_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (txtMaPhat.Text.Length == 0)
                {
                    MessageBox.Show("Mã phát lương không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!xuLyL.ktKhoaChinh(txtMaPhat.Text))
                    {
                        if (xuLyL.xoaLuong(txtMaPhat.Text))
                        {
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = (DataTable)dtgv_Luong.DataSource;
                            dt.Clear();
                            dt = xuLyL.loadLuong();
                            dtgv_Luong.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã phát lương này không tồn tại! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            if (dtgv_PhieuMuonSach.CurrentRow != null)
            {
                string maMuon = dtgv_PhieuMuonSach.CurrentRow.Cells[0].Value.ToString();
                string ten = xuLyRP.traVeTenDG(dtgv_PhieuMuonSach.CurrentRow.Cells[1].Value.ToString());
                frmXemIn frm = new frmXemIn();
                frm.maMuon = maMuon;
                frm.tenDocGia = ten;
                frm.Show();
            }
        }

        private void btnXemInThongKe_Click(object sender, EventArgs e)
        {
            if (ktGroupBoxRadioButton(gb_ThongKe))
            {
                frmXemInThongKe frm = new frmXemInThongKe();
                for (int i = 0; i < gb_ThongKe.Controls.Count; i++)
                {
                    RadioButton rd = (RadioButton)gb_ThongKe.Controls[i];
                    if (rd.Checked)
                    {
                        switch (rd.Name)
                        {
                            case "rdoThongKeSachMuon":
                                frm.loai = 1;
                                break;
                            //case "rdoThongKeSachChuaMuon":
                            //    frm.loai = 2;
                            //    break;
                            case "rdoThongKeSachMuonChuaTra":
                                frm.loai = 3;
                                break;
                        }
                    }
                }
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại thống kê muốn xem in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
