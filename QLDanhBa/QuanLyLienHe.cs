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
    public partial class QuanLyLienHe : Form
    {
        BUS_Lienhe qlLH = new BUS_Lienhe(Login.tendn);
        BUS_Yeuthich qlYT = new BUS_Yeuthich(Login.tendn);
        BUS_Chan qlChan = new BUS_Chan(Login.tendn);
        BUS_NhomLienHe qlNhom = new BUS_NhomLienHe(Login.tendn);

        //Các biến static để tuyền sang Form khác
        public static int ma_lienhe;
        public static string sdt;
        public static string hoten;
        public static string diachi;
        public static string mail;
        public static string mangxh;
        public static Boolean gioitinh;
        public static DateTime ngaysinh;
        public static string ghichu;
        public static Boolean trangthaiyt;
        public static Boolean trangthaichan;
        public static string tennhom;

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void nhómLiênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhomLienHe f = new NhomLienHe();
            f.Show();
        }

        public QuanLyLienHe()
        {
            InitializeComponent();
        }

        private void QuanLyLienHe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            getGridLienHe();
            tsbtnsua.Enabled = false;
            tsbtnxoa.Enabled = false;
            tsbtnxemtt.Enabled = false;
            getDstieuchi();
            getNhom();
            Tencot();
        }

        public void getDstieuchi()
        {
            cbotieuchi.Items.Add("Họ tên");
            cbotieuchi.Items.Add("Số điện thoại");
            cbotieuchi.SelectedIndex = 0;
        }

        private void getGridLienHe()// Set hoặc trả về dgv danh sách
        {
            dgvdanhsachlh.DataSource = qlLH.getDataSetLienHe();
            dgvdanhsachlh.DataMember = "LienHe";
            Tencot();
        }
        public void Tencot()
        {
            if (dgvdanhsachlh.Columns.Contains("ma_lienhe") == true)
            {
                dgvdanhsachlh.Columns["ma_lienhe"].Visible = false;
                dgvdanhsachlh.Columns["diachi"].Visible = false;
                dgvdanhsachlh.Columns["mangxh"].Visible = false;
                dgvdanhsachlh.Columns["ghichu"].Visible = false;
                dgvdanhsachlh.Columns["tendangnhap"].Visible = false;
                dgvdanhsachlh.Columns["ma_nhom"].Visible = false;
                dgvdanhsachlh.Columns["gioitinh"].Visible = false;

                dgvdanhsachlh.Columns["hoten"].HeaderText = "Họ và tên";
                dgvdanhsachlh.Columns["sdt"].HeaderText = "Số điện thoại";
                dgvdanhsachlh.Columns["gioitinh"].HeaderText = "Giới tính";
                dgvdanhsachlh.Columns["ngaysinh"].HeaderText = "Ngày sinh";
                dgvdanhsachlh.Columns["mail"].HeaderText = "Mail";
                dgvdanhsachlh.Columns["tennhom"].HeaderText = "Nhóm";

                dgvdanhsachlh.Columns["hoten"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvdanhsachlh.Columns["sdt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvdanhsachlh.Columns["gioitinh"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvdanhsachlh.Columns["ngaysinh"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvdanhsachlh.Columns["mail"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvdanhsachlh.Columns["tennhom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        public void getGridYT()
        {
            DataTable dt = qlYT.getGridYeuthich();
            dgvdanhsachlh.DataSource = dt;
        }
        public void getGridChan()
        {

            DataTable dt = qlChan.getGridChan();
            dgvdanhsachlh.DataSource = dt;
        }

        //Lấy thông tin từ form này để form khác dùng
        public void getTT()
        {
            DTO_LienHe lh = new DTO_LienHe();
            lh = getTTLH();
            ma_lienhe = Int32.Parse(dgvdanhsachlh.CurrentRow.Cells[0].Value.ToString());
            hoten = lh.Hoten;
            sdt = lh.Sdt;
            diachi = lh.Diachi;
            mail = lh.Mail;
            mangxh = lh.Mangxh;
            gioitinh = lh.Gioitinh;
            ngaysinh = lh.Ngaysinh;
            ghichu = lh.Ghichu;
            tennhom = lh.TenNhom;
            trangthaiyt = getTrangThaiYT();
            trangthaichan = getTrangThaiChan();
        }

        private void tsbtnxemtt_Click(object sender, EventArgs e)
        {
            getTT();
            FormXemThongTin f = new FormXemThongTin();
            f.Show();
            this.Close();
        }

        private void tsbtnthem_Click(object sender, EventArgs e)
        {
            FormThemLH f = new FormThemLH();
            f.Show();
            this.Close();

        }

        private void tsbtnsua_Click(object sender, EventArgs e)
        {
            try
            {
                getTT();
                FormSuaLH f = new FormSuaLH();
                f.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void tsbtnxoa_Click(object sender, EventArgs e)
        {
            string ma_lienhe = dgvdanhsachlh.CurrentRow.Cells[0].Value.ToString();
            Boolean kq = qlLH.xoa_LH(ma_lienhe);
            if (!kq)
            {
                MessageBox.Show("Xóa không thành công");
            }
            Update();
        }
        public void Update()
        {
            QuanLyLienHe f = new QuanLyLienHe();
            f.Show();
            this.Close();
        }

        private void stbtndanhba_Click(object sender, EventArgs e)
        {
            getGridLienHe();
            cbonhomlh.SelectedIndex = 0;
            lbtendslienhe.Text = "Danh sách liên hệ";
        }

        private void tsbtnYeuthich_Click(object sender, EventArgs e)
        {
            getGridYT();
            lbtendslienhe.Text = "Danh sách liên hệ yêu thích";
            Tencot();
        }

        private void tsbtnchan_Click(object sender, EventArgs e)
        {
            getGridChan();
            lbtendslienhe.Text = "Danh sách liên hệ bị chặn";
            Tencot();
        }

        private void tsbtncapnhat_Click(object sender, EventArgs e)
        {
            Update();
        }

        //Lấy thông tin từ dgv để cho vào Form khác
        public DTO_LienHe getTTLH()
        {
            try
            {
                DTO_LienHe lh = new DTO_LienHe();
                string sdt = dgvdanhsachlh.CurrentRow.Cells[2].Value.ToString();
                return qlLH.getTTTK(lh, sdt);
            }
            catch (Exception) { return null; }
        }

        public Boolean getTrangThaiYT()
        {
            int ma_lienhe = Int32.Parse(dgvdanhsachlh.CurrentRow.Cells[0].Value.ToString());
            return qlYT.getTrangThaiYT(ma_lienhe);
        }

        public Boolean getTrangThaiChan()
        {
            int ma_lienhe = Int32.Parse(dgvdanhsachlh.CurrentRow.Cells[0].Value.ToString());
            return qlChan.getTrangThaiChan(ma_lienhe);
        }

        private void txttimkiemlh_TextChanged(object sender, EventArgs e)
        {
            //Sẽ luôn không chọn nhóm khi nhập từ khóa tìm kiếm
            cbonhomlh.SelectedIndex = 0;
            lbtendslienhe.Text = "Danh sách liên hệ";
            if (cbotieuchi.SelectedIndex == 0)
            {
                dgvdanhsachlh.DataSource = qlLH.TimKiemHoten(txttimkiemlh.Text);
                Tencot();
            }
            else if (cbotieuchi.SelectedIndex == 1)
            {
                dgvdanhsachlh.DataSource = qlLH.TimKiemSdt(txttimkiemlh.Text);
                Tencot();

            }
            if (txttimkiemlh.Text.Length == 0)
            {
                getGridLienHe();
            }
        }

        private void getNhom()
        {
            cbonhomlh.Items.Add("Tất cả nhóm");
            cbomanhom.Items.Add("0");
            cbonhomlh.SelectedIndex = 0;
            List<DTO_NhomLienHe> dsNhom = qlNhom.getDsNhom();
            foreach (DTO_NhomLienHe nhom in dsNhom)
            {
                cbonhomlh.Items.Add(nhom.TenNhom);
                cbomanhom.Items.Add(nhom.Ma_nhom);
            }
        }

        private void cbonhomlh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbonhomlh.SelectedIndex;
            dgvdanhsachlh.DataSource = qlNhom.getGridNhomLH(cbomanhom.Items[index].ToString());
            Tencot();
        }

        private void dgvdanhsachlh_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnsua.Enabled = true;
            tsbtnxoa.Enabled = true;
            tsbtnxemtt.Enabled = true;
        }

        private void tsbtnIn_Click(object sender, EventArgs e)
        {
            FromIn f = new FromIn();
            f.Show();
        }
    }
}
