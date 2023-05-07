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
    public partial class NhomLienHe : Form
    {
        BUS_NhomLienHe qlNhom = new BUS_NhomLienHe(Login.tendn);

        public NhomLienHe()
        {
            InitializeComponent();
        }
        private void ClearInput()
        {
            txttennhom.Text = "";
        }
        private Boolean checkInput()
        {
            Boolean kq = true;
            if (txttennhom.Text == "")
            {
                kq = false;
                txttennhom.Focus();
            }
            return kq;
        }

        private void getGridNhom()
        {
            DataViewManager dvm = qlNhom.getGridNhom(Login.tendn);
            dgvdsnhom.DataSource = dvm;
            dgvdsnhom.DataMember = "NhomLienHe";
            dgvdsnhom.Columns["tendangnhap"].Visible = false;
            dgvdsnhom.Columns["ma_nhom"].Visible = false;
            dgvdsnhom.Columns["tennhom"].HeaderText = "Tên nhóm";
        }
        private void btnthemnhom_Click(object sender, EventArgs e)
        {
            if (checkInput() == true)
            {
                DTO_NhomLienHe nhom = new DTO_NhomLienHe();
                nhom.TenNhom = txttennhom.Text;

                Boolean kq = qlNhom.add_New_Nhom(nhom, Login.tendn);
                if (!kq)
                {
                    MessageBox.Show("Thêm mới không thành công.");
                }
                ClearInput();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!");
            }
        }

        private void NhomLienHe_Load(object sender, EventArgs e)
        {
            getGridNhom();
            this.CenterToScreen();
        }

        private void btnsuanhom_Click(object sender, EventArgs e)
        {
            DTO_NhomLienHe nhom = new DTO_NhomLienHe();
            if (checkInput() == true)
            {
                Boolean kq = true;
                nhom.Ma_nhom = dgvdsnhom.CurrentRow.Cells[0].Value.ToString();
                nhom.TenNhom = txttennhom.Text;
                kq = qlNhom.sua_Nhom(nhom);
                getGridNhom();
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

        private void btnxoanhom_Click(object sender, EventArgs e)
        {
            string ma_nhom = dgvdsnhom.CurrentRow.Cells[0].Value.ToString();
            Boolean kq = qlNhom.xoa_Nhom(ma_nhom);
            if (!kq)
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void dgvdsnhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTO_NhomLienHe nhom = new DTO_NhomLienHe();
            string ma_nhom = dgvdsnhom.CurrentRow.Cells[0].Value.ToString();
            nhom = qlNhom.getTT(ma_nhom);
            txttennhom.Text = nhom.TenNhom;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
