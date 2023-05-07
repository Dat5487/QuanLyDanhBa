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
    public partial class FormSuaLH : Form
    {
        BUS_Yeuthich qlYT = new BUS_Yeuthich(Login.tendn);
        BUS_Chan qlChan = new BUS_Chan(Login.tendn);
        BUS_Lienhe qlLH = new BUS_Lienhe(Login.tendn);
        BUS_NhomLienHe qlNhom = new BUS_NhomLienHe(Login.tendn);
        public FormSuaLH()
        {
            InitializeComponent();
        }
        private void ClearInput()
        {
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtmaillh.Text = "";
            txtmangxh.Text = "";
            txtsdt.Text = "";
            txtghichu.Text = "";
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

        private void FormSuaLH_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            getNhom();

            txthoten.Text = QuanLyLienHe.hoten;
            txtsdt.Text = QuanLyLienHe.sdt;
            txtdiachi.Text = QuanLyLienHe.diachi;
            txtmaillh.Text = QuanLyLienHe.mail;
            txtmangxh.Text = QuanLyLienHe.mangxh;
            txtghichu.Text = QuanLyLienHe.ghichu;
            if (QuanLyLienHe.gioitinh)
                rdonam.Checked = true;
            else
                rdonu.Checked = true;

            int dem = 0;//Vị trí của nhóm trong combobox
            foreach (var item in cbonhom.Items)
            {
                if (item.ToString() == QuanLyLienHe.tennhom)
                {
                    cbonhom.SelectedIndex = dem;//Chọn nhóm
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

        private void btnsualh_Click(object sender, EventArgs e)
        {
            DTO_LienHe lh = new DTO_LienHe();
            if (checkInput() == true)
            {
                Boolean kq = true;
                lh.Hoten = txthoten.Text;
                lh.Sdt = txtsdt.Text;
                lh.Diachi = txtdiachi.Text;
                lh.Ngaysinh = dtngaysinh.Value;
                lh.Mangxh = txtmangxh.Text;
                lh.Mail = txtmaillh.Text;
                if (cbonhom.SelectedIndex == 0)
                {
                    lh.TenNhom = null;
                    lh.Ma_nhom = null;
                }
                else
                {
                    lh.TenNhom = cbonhom.Items[cbonhom.SelectedIndex].ToString();
                    lh.Ma_nhom = cboma_nhom.Items[cbonhom.SelectedIndex].ToString();
                }
                if (rdonam.Checked)
                {
                    lh.Gioitinh = true;
                }
                else
                {
                    lh.Gioitinh = false;
                }
                lh.Ghichu = txtghichu.Text;

                //Thay đổi Yêu thích - Chặn 
                kq = qlLH.sua_LH(lh, QuanLyLienHe.ma_lienhe);
                if (cbotrangthai.SelectedIndex == 1)
                {
                    qlChan.XoaChan(QuanLyLienHe.ma_lienhe);
                    qlYT.ThemYeuThich(QuanLyLienHe.ma_lienhe);
                }
                else if (cbotrangthai.SelectedIndex == 2)
                {
                    qlYT.XoaYeuThich(QuanLyLienHe.ma_lienhe);
                    qlChan.ThemChan(QuanLyLienHe.ma_lienhe);
                }
                else if (cbotrangthai.SelectedIndex == 0)
                {
                    qlYT.XoaYeuThich(QuanLyLienHe.ma_lienhe);
                    qlChan.XoaChan(QuanLyLienHe.ma_lienhe);
                }

                if (!kq)
                {
                    MessageBox.Show("Sửa không thành công");
                }
                //ClearInput();
                QuanLyLienHe f = new QuanLyLienHe();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            QuanLyLienHe f = new QuanLyLienHe();
            f.Show();
            this.Close();
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

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
