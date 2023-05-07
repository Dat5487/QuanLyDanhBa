using BUS;
using DTO;
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
    public partial class Login : Form
    {
        public static string tendn;//Truyền tendn sang form khác

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtpassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DTO_QTV tk = new DTO_QTV();
            tendn = txtusername.Text;
            tk.Tendangnhap = txtusername.Text;
            tk.Matkhau = txtpassword.Text;
            tendn = txtusername.Text;
            Clear();
            lbError.Text = "";
            BUS_QTV B_QTV = new BUS_QTV();

            if (B_QTV.Kiemtra_Login(tk) == "error")
            {
                lbError.Text = "Tài khoản hoặc mật khẩu sai";

            }
            if (B_QTV.Kiemtra_Login(tk) == "Quản lý tài khoản")
            {
                QTV QTV_form = new QTV();
                this.Hide();
                QTV_form.ShowDialog();
            }
            if (B_QTV.Kiemtra_Login(tk) == "Khách hàng")
            {
                Main Main_form = new Main();
                this.Hide();
                Main_form.Show();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckboxhienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxhienmk.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            if (!ckboxhienmk.Checked)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void Clear()
        {
            txtpassword.Text = "";
            txtusername.Text = "";
        }

    }
}
