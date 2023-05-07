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
    public partial class QTV : Form
    {
        BUS_QTV qlTK = new BUS_QTV();

        public QTV()
        {
            InitializeComponent();
        }

        private void QTV_Load(object sender, EventArgs e)
        {
            getDsquyen();
            getGridTaiKhoan();
            this.CenterToScreen();
        }

        private void ClearInput()
        {
            txttendangnhap.Text = "";
            txtmatkhau.Text = "";
            txttukhoa.Text = "";
            txthoten.Text = "";
        }
        private Boolean checkInput()
        {
            Boolean kq = true;
            if (txttendangnhap.Text == "")
            {
                kq = false;
                txttendangnhap.Focus();
            }
            else if (txtmatkhau.Text == "")
            {
                kq = false;
                txtmatkhau.Focus();
            }
            else if (txthoten.Text == "")
            {
                kq = false;
                txtmatkhau.Focus();
            }
            else if (cboquyenhan.SelectedIndex < 0)
            {
                kq = false;
                cboquyenhan.Focus();
            }
            return kq;
        }

        private void getDsquyen()
        {
            cboquyenhan.Items.Add("Quản lý tài khoản");
            cboquyenhan.Items.Add("Khách hàng");
        }

        public void TenCot()
        {
            dgvdstaikhoan.Columns["tendangnhap"].HeaderText = "Tên đăng nhập";
            dgvdstaikhoan.Columns["matkhau"].HeaderText = "Mật khẩu";
            dgvdstaikhoan.Columns["quyenhan"].HeaderText = "Quyền hạn";
            dgvdstaikhoan.Columns["hoten"].HeaderText = "Họ tên";

            dgvdstaikhoan.Columns["tendangnhap"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdstaikhoan.Columns["matkhau"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdstaikhoan.Columns["quyenhan"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdstaikhoan.Columns["hoten"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void getGridTaiKhoan()
        {
            DataViewManager dvm = qlTK.getGridTaiKhoan();
            dgvdstaikhoan.DataSource = dvm;
            dgvdstaikhoan.DataMember = "QTV";
            TenCot();
        }


        private void btnthemtk_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                DTO_QTV tk = new DTO_QTV();
                tk.Tendangnhap = txttendangnhap.Text;
                tk.Matkhau = txtmatkhau.Text;
                tk.Hoten = txthoten.Text;
                tk.Quyenhan = cboquyenhan.Items[cboquyenhan.SelectedIndex].ToString();
                Boolean kq = qlTK.add_New_TK(tk);
                if (!kq)
                {
                    MessageBox.Show("Thêm mới không thành công. Có thể tên đăng nhập đã tồn tại!");
                }
                ClearInput();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!");
            }
        }

        private void btnsuatk_Click(object sender, EventArgs e)
        {
            DTO_QTV tk = new DTO_QTV();
            if (checkInput() == true)
            {
                Boolean kq = true;
                string username = dgvdstaikhoan.CurrentRow.Cells[0].Value.ToString();
                tk.Matkhau = txtmatkhau.Text;
                tk.Hoten = txthoten.Text;
                tk.Quyenhan = cboquyenhan.Items[cboquyenhan.SelectedIndex].ToString();
                qlTK.sua_TK(tk, username);
                getGridTaiKhoan();
                if (!kq)
                {
                    MessageBox.Show("Sửa không thành công");
                }
                ClearInput();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!");
            }
        }

        private void btnxoatk_Click(object sender, EventArgs e)
        {
            string tendn = dgvdstaikhoan.CurrentRow.Cells[0].Value.ToString();
            Boolean kq = qlTK.xoa_TK(tendn);
            if (!kq)
            {
                MessageBox.Show("Xóa không thành công");
            }
            else if (kq == true)
            {
                qlTK.xoatatca(tendn);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearInput();
            txttendangnhap.Enabled = true;
        }

        private void txttukhoa_TextChanged(object sender, EventArgs e)
        {
            dgvdstaikhoan.DataSource = qlTK.TimKiem(txttukhoa.Text);
            if (txttukhoa.Text.Length == 0)
            {
                getGridTaiKhoan();
            }
            TenCot();
        }

        private void dgvdstaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTO_QTV tk = new DTO_QTV();
            string username = dgvdstaikhoan.CurrentRow.Cells[0].Value.ToString();
            tk = qlTK.getTTTK(tk, username);
            txttendangnhap.Text = tk.Tendangnhap;
            txtmatkhau.Text = tk.Matkhau;
            txthoten.Text = tk.Hoten;
            cboquyenhan.Text = tk.Quyenhan;
            txttendangnhap.Enabled = false;
        }

        private void tsdangxuat_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }
    }
}
