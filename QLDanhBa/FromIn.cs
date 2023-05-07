using BUS;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDanhBa
{
    public partial class FromIn : Form
    {
        public FromIn()
        {
            InitializeComponent();
        }
        BUS_Lienhe qlLH = new BUS_Lienhe(Login.tendn);

        private void FromIn_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLDanhBa.ReportLienHe.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsLienHe";
            rds.Value = qlLH.getTable("LienHe");

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
