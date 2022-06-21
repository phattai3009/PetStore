using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using DAL;
using DoAn_DotNet.Custom;

namespace DoAn_DotNet.GUI
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            load();
            crystalReportViewer1.Refresh();
        }

        public void load()
        {
            DataTable dt = new DataTable();
            DonHangDAO dh = new DonHangDAO();
            dt = dh.DonHang_Report(loadMaDH.maDH);
            CrystalReport2 rpt = new CrystalReport2();
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "123", "PHATTAI", "QL_PetStore");
        }
    }
}
