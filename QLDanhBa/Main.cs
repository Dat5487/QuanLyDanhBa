using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDanhBa
{
    public partial class Main : Form
    {
        BUS_Lienhe qlLH = new BUS_Lienhe(Login.tendn);
        BUS_NhomLienHe qlNhom = new BUS_NhomLienHe(Login.tendn);
        BUS_Yeuthich qlYT = new BUS_Yeuthich(Login.tendn);
        BUS_Chan qlChan = new BUS_Chan(Login.tendn);
        BUS_QTV qlTK = new BUS_QTV();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lbusername.Text = qlTK.getHoten(Login.tendn);
            this.CenterToScreen();
            lbsoluonglh.Text = qlLH.getSoLuongLH(Login.tendn).ToString();
            lbslnhomlh.Text = qlNhom.getSoLuongNhom().ToString();
            lbslyeuthich.Text = qlYT.getSoLuongYeuThich().ToString();
            lbsllhchan.Text = qlChan.getSoLuongChan().ToString();
        }

        private void nhómLiênHệToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NhomLienHe f = new NhomLienHe();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void quảnLýLiênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLienHe f = new QuanLyLienHe();
            f.Show();
            this.Close();
        }

    }
}
