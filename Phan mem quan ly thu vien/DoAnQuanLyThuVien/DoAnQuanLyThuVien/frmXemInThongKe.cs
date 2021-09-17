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
    public partial class frmXemInThongKe : Form
    {
        XuLyReport xuLy = new XuLyReport();
        public int loai;
        public frmXemInThongKe()
        {
            InitializeComponent();
        }

        private void frmXemInThongKe_Load(object sender, EventArgs e)
        {
            if (loai == 1)
            {
                ReportThongKeSachMuonDaTra rp = new ReportThongKeSachMuonDaTra();
                rp.SetDatabaseLogon("sa", "nguyen114814", "LAPTOP-1LO8U7LN\\SQLEXPRESS", "QUANLYTHUVIEN_DOAN_NET");
                rp.SetDataSource(xuLy.loadSachChoMuonDaTra());

                crystalReportViewer1.Refresh();
                crystalReportViewer1.ReportSource = rp;
                crystalReportViewer1.DisplayToolbar = false;
                crystalReportViewer1.DisplayStatusBar = false;
            }
            //else if (loai == 2)
            //{
            //    ReportThongKeSachChuaChoMuon rp = new ReportThongKeSachChuaChoMuon();
            //    rp.SetDatabaseLogon("sa", "nguyen114814", "LAPTOP-1LO8U7LN\\SQLEXPRESS", "QUANLYTHUVIEN_DOAN_NET");
            //    rp.SetDataSource(xuLy.loadSachChuaChoMuon());

            //    crystalReportViewer1.Refresh();
            //    crystalReportViewer1.ReportSource = rp;
            //    crystalReportViewer1.DisplayToolbar = false;
            //    crystalReportViewer1.DisplayStatusBar = false;
            //}
            if(loai == 3)
            {
                ReportThongKeSachMuonChuaTra rpt = new ReportThongKeSachMuonChuaTra();
                rpt.SetDatabaseLogon("sa", "nguyen114814", "LAPTOP-1LO8U7LN\\SQLEXPRESS", "QUANLYTHUVIEN_DOAN_NET");
                rpt.SetDataSource(xuLy.loadSachMuonChuaTra());

                crystalReportViewer1.Refresh();
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.DisplayToolbar = false;
                crystalReportViewer1.DisplayStatusBar = false;
            }
        }
    }
}
