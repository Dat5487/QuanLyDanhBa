using DTO;
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
    public partial class FormThemLH : Form
    {
        BUS_Lienhe qlLH = new BUS_Lienhe(Login.tendn);

        public FormThemLH()
        {
            InitializeComponent();
        }

        private void FormThemLH_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private Boolean checkInput()
        {
            Boolean kq = true;
            if (txthoten.Text == "")
            {
                kq = false;
                txthoten.Focus();
            }
            else if (txtsdt.Text == "")
            {
                kq = false;
                txtsdt.Focus();
            }
            return kq;
        }

        public void Thoat()
        {
            QuanLyLienHe f = new QuanLyLienHe();
            f.Show();
            this.Close();
        }

        private void btnthemlh_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                DTO_LienHe lh = new DTO_LienHe();
                lh.Sdt = txtsdt.Text;
                lh.Diachi = txtdiachi.Text;
                lh.Hoten = txthoten.Text;
                lh.Mail = txtmaillh.Text;
                lh.Mangxh = txtmangxh.Text;
                lh.Ngaysinh = dtngaysinh.Value;
                if (rdonam.Checked)
                {
                    lh.Gioitinh = true;
                }
                else
                {
                    lh.Gioitinh = false;
                }
                lh.Ghichu = txtghichu.Text;
                lh.Tendangnhap = Login.tendn;
                lh.Ma_nhom = null;
                Boolean kq = qlLH.add_New_LH(lh);
                if (!kq)
                {
                    MessageBox.Show("Thêm mới không thành công.");
                }
                Thoat();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Thoat();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtmaillh.Text = "";
            txtmangxh.Text = "";
            txtsdt.Text = "";
            txtghichu.Text = "";
        }

        private void txtsdt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
