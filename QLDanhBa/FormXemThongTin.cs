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
    public partial class FormXemThongTin : Form
    {
        BUS_NhomLienHe qlNhom = new BUS_NhomLienHe(Login.tendn);

        public FormXemThongTin()
        {
            InitializeComponent();
        }

        private void FormXemThongTin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            getNhom();

            txthoten.Text = QuanLyLienHe.hoten;
            txtsdt.Text = QuanLyLienHe.sdt.ToString();
            txtdiachi.Text = QuanLyLienHe.diachi;
            txtmaillh.Text = QuanLyLienHe.mail;
            txtmangxh.Text = QuanLyLienHe.mangxh;
            txtghichu.Text = QuanLyLienHe.ghichu;
            if (QuanLyLienHe.gioitinh)
                rdonam.Checked = true;
            else
                rdonu.Checked = true;

            int dem = 0;
            foreach (var item in cbonhom.Items)
            {
                if (item.ToString() == QuanLyLienHe.tennhom)
                {
                    cbonhom.SelectedIndex = dem;
                    break;
                }
                dem++;
            }

            cbotrangthai.Items.Add("Không trạng thái");
            cbotrangthai.Items.Add("Yêu thích");
            cbotrangthai.Items.Add("Chặn");
            if (QuanLyLienHe.trangthaiyt)
            {
                cbotrangthai.SelectedIndex = 1;
                lbttyeuthich.Text = "Đã yêu thích liên hệ";
            }
            else if (QuanLyLienHe.trangthaichan)
            {
                cbotrangthai.SelectedIndex = 2;
                lbttyeuthich.Text = "Đã chặn liên hệ";
            }
            else
            {
                cbotrangthai.SelectedIndex = 0;
                lbttyeuthich.Text = "Không yêu thích hay chặn liên hệ";
            }
        }

        private void getNhom()
        {
            cbonhom.Items.Add("Không thuộc nhóm nào");
            cboma_nhom.Items.Add(" ");
            cbonhom.SelectedIndex = 0;
            List<DTO_NhomLienHe> dsNhom = qlNhom.getDsNhom();
            foreach (DTO_NhomLienHe nhom in dsNhom)
            {
                cbonhom.Items.Add(nhom.TenNhom);
                cboma_nhom.Items.Add(nhom.Ma_nhom);
            }
        }

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            QuanLyLienHe f = new QuanLyLienHe();
            f.Show();
            this.Close();
        }
    }
}
