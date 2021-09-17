using CrystalDecisions.Shared;
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
    public partial class frmXemIn : Form
    {
        XuLyReport xuLy = new XuLyReport();
        public string maMuon;
        public string tenDocGia;
        public frmXemIn()
        {
            InitializeComponent();
        }

        private void frmXemIn_Load(object sender, EventArgs e)
        {
            ReportPhieuMuonSach rp = new ReportPhieuMuonSach();
            rp.SetDatabaseLogon("sa", "nguyen114814", "LAPTOP-1LO8U7LN\\SQLEXPRESS", "QUANLYTHUVIEN_DOAN_NET");
            rp.SetDataSource(xuLy.loadChiTietMuonSach(maMuon));


            ParameterDiscreteValue pa = new ParameterDiscreteValue();
            pa.Value = maMuon;
            ParameterValues pv = new ParameterValues();
            pv.Add(pa);
            rp.DataDefinition.ParameterFields["MaMuon"].ApplyCurrentValues(pv);

            ParameterDiscreteValue pa1 = new ParameterDiscreteValue();
            pa1.Value = tenDocGia;
            ParameterValues pv1 = new ParameterValues();
            pv1.Add(pa1);
            rp.DataDefinition.ParameterFields["TenDocGia"].ApplyCurrentValues(pv1);

            
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.DisplayToolbar = false;
            crystalReportViewer1.DisplayStatusBar = false;
        }
    }
}
