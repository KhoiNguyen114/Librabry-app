namespace DoAnQuanLyThuVien
{
    partial class frmThemTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemTaiKhoan));
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dtgv_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMaTK = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.cboMaLoaiTaiKhoan = new System.Windows.Forms.ComboBox();
            this.lblLoaiTaiKhoan = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(770, 87);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 44);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(770, 220);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 44);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dtgv_TaiKhoan
            // 
            this.dtgv_TaiKhoan.AllowUserToAddRows = false;
            this.dtgv_TaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_TaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.tableLayoutPanel1.SetColumnSpan(this.dtgv_TaiKhoan, 2);
            this.dtgv_TaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_TaiKhoan.Location = new System.Drawing.Point(3, 2);
            this.dtgv_TaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgv_TaiKhoan.Name = "dtgv_TaiKhoan";
            this.dtgv_TaiKhoan.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dtgv_TaiKhoan, 2);
            this.dtgv_TaiKhoan.RowTemplate.Height = 24;
            this.dtgv_TaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_TaiKhoan.Size = new System.Drawing.Size(761, 262);
            this.dtgv_TaiKhoan.TabIndex = 2;
            this.dtgv_TaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_TaiKhoan_CellClick);
            this.dtgv_TaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_TaiKhoan_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MATK";
            this.Column1.HeaderText = "Mã tài khoản";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENDN";
            this.Column2.HeaderText = "Tên đăng nhập";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MALOAI";
            this.Column4.HeaderText = "Mã loại tài khoản";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "MANV";
            this.Column5.HeaderText = "Mã nhân viên";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 268);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(761, 263);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.92769F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.87125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.92769F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87478F));
            this.tableLayoutPanel2.Controls.Add(this.txtMaTaiKhoan, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNhanVien, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboMaNhanVien, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblMatKhau, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtMatKhau, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMaTK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTenDN, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboMaLoaiTaiKhoan, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLoaiTaiKhoan, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenDN, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(755, 239);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // txtMaTaiKhoan
            // 
            this.txtMaTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaTaiKhoan.Location = new System.Drawing.Point(176, 2);
            this.txtMaTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            this.txtMaTaiKhoan.Size = new System.Drawing.Size(162, 27);
            this.txtMaTaiKhoan.TabIndex = 1;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhanVien.Location = new System.Drawing.Point(3, 118);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(167, 59);
            this.lblNhanVien.TabIndex = 8;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(176, 120);
            this.cboMaNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(162, 27);
            this.cboMaNhanVien.TabIndex = 9;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatKhau.Location = new System.Drawing.Point(3, 59);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(167, 59);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Location = new System.Drawing.Point(176, 61);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(162, 27);
            this.txtMatKhau.TabIndex = 3;
            // 
            // lblMaTK
            // 
            this.lblMaTK.AutoSize = true;
            this.lblMaTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaTK.Location = new System.Drawing.Point(3, 0);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(167, 59);
            this.lblMaTK.TabIndex = 0;
            this.lblMaTK.Text = "Mã tài khoản";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDN.Location = new System.Drawing.Point(486, 2);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(167, 27);
            this.txtTenDN.TabIndex = 5;
            // 
            // cboMaLoaiTaiKhoan
            // 
            this.cboMaLoaiTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaLoaiTaiKhoan.FormattingEnabled = true;
            this.cboMaLoaiTaiKhoan.Location = new System.Drawing.Point(486, 61);
            this.cboMaLoaiTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaLoaiTaiKhoan.Name = "cboMaLoaiTaiKhoan";
            this.cboMaLoaiTaiKhoan.Size = new System.Drawing.Size(167, 27);
            this.cboMaLoaiTaiKhoan.TabIndex = 7;
            // 
            // lblLoaiTaiKhoan
            // 
            this.lblLoaiTaiKhoan.AutoSize = true;
            this.lblLoaiTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiTaiKhoan.Location = new System.Drawing.Point(344, 59);
            this.lblLoaiTaiKhoan.Name = "lblLoaiTaiKhoan";
            this.lblLoaiTaiKhoan.Size = new System.Drawing.Size(136, 59);
            this.lblLoaiTaiKhoan.TabIndex = 6;
            this.lblLoaiTaiKhoan.Text = "Loại tài khoản";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenDN.Location = new System.Drawing.Point(344, 0);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(136, 59);
            this.lblTenDN.TabIndex = 4;
            this.lblTenDN.Text = "Tên đăng nhập";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.56065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.20755F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.16442F));
            this.tableLayoutPanel1.Controls.Add(this.btnSua, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnThem, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtgv_TaiKhoan, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(989, 533);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frmThemTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmThemTaiKhoan";
            this.Text = "frmThemTaiKhoan";
            this.Load += new System.EventHandler(this.frmThemTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dtgv_TaiKhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaTaiKhoan;
        private System.Windows.Forms.Label lblMaTK;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.ComboBox cboMaLoaiTaiKhoan;
        private System.Windows.Forms.Label lblLoaiTaiKhoan;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}