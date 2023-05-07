using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_QTV
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8G5OH0Q\SQLEXPRESS;Initial Catalog=DanhBaDienTu;Integrated Security=True");
        private DataSet ds = null;
        private SqlDataAdapter da1 = null;
        public DAL_QTV()
        {
            ds = new DataSet();
            da1 = new SqlDataAdapter();
            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            da1.SelectCommand = new SqlCommand("Select * from QTV", conn);
            da1.TableMappings.Add("Table", "QTV");
            da1.Fill(ds, "QTV");

        }
        public DataTable getTable(string name)
        {
            return ds.Tables[name];
        }

        public string Kiemtra_Login(DTO_QTV admin)
        {
            string query = String.Format("SELECT quyenhan FROM QTV WHERE tendangnhap = N'{0}' AND matkhau = N'{1}'", admin.Tendangnhap, admin.Matkhau);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    return row["quyenhan"].ToString();
                }
            }
            else
            {
                return "error";
            }
            return "error";
        }

        public DataViewManager getGridTaiKhoan()
        {
            return ds.DefaultViewManager;
        }

        public void themDongTK(DTO_QTV tk)
        {
            DataRow r = getTable("QTV").NewRow();
            r["tendangnhap"] = tk.Tendangnhap;
            r["matkhau"] = tk.Matkhau;
            r["hoten"] = tk.Hoten;
            r["quyenhan"] = tk.Quyenhan;
            try
            {
                ds.Tables["QTV"].Rows.Add(r);
                da1.Update(ds, "QTV");
                ds.AcceptChanges();
            }
            catch { }
        }

        public Boolean sua_TK(DTO_QTV tk,string username)
        {
            Boolean kq = false;
            DataRow[] rows = getTable("QTV").Select("tendangnhap='" + username + "'");
            if (rows.Length > 0)
            {
                rows[0].BeginEdit();
                rows[0]["matkhau"] = tk.Matkhau;
                rows[0]["hoten"] = tk.Hoten;
                rows[0]["quyenhan"] = tk.Quyenhan;
                rows[0].EndEdit();
                da1.Update(ds, "QTV");
                ds.AcceptChanges();
                kq = true;
            }
            return kq;
        }

        public Boolean xoa_TK(string username)
        {
            Boolean kq = false;
            DataRow[] rows = getTable("QTV").Select("tendangnhap='" + username + "'");
            if(rows.Length>0)
            {
                rows[0].Delete();
                da1.Update(ds,"QTV");
                ds.AcceptChanges();
                kq = true;
            }
            return kq;
        }

        public DataTable TimKiem(string tukhoa)
        {
            try
            {
                DataTable dt = getTable("QTV");
                DataRow[] rows = dt.Select("tendangnhap like '%" + tukhoa + "%'");
                return rows.CopyToDataTable();
            }
            catch(Exception) { return null; }
        }

        public DTO_QTV getTTTK(DTO_QTV tk, string username)
        {
            foreach (DataRow r in getTable("QTV").Rows)
                if (r["tendangnhap"].ToString()==username)
                {
                    tk.Tendangnhap = r["tendangnhap"].ToString();
                    tk.Matkhau = r["matkhau"].ToString();
                    tk.Hoten = r["hoten"].ToString();
                    tk.Quyenhan = r["quyenhan"].ToString();
                }
            return tk;
        }

        public void xoatatca(string tendn)//Xóa tất cả những dòng có tendangnhap của tài khoản đang xóa
        {
            conn.Open();
            //Xóa tất cả những liên hệ có tendangnhap của tài khoản đang xóa
            SqlCommand cmd = new SqlCommand(@"DELETE FROM LienHe WHERE tendangnhap = @tendangnhap;", conn);
            cmd.Parameters.AddWithValue("tendangnhap", tendn);
            cmd.ExecuteNonQuery();
            //Xóa tất cả những yêu thích có tendangnhap của tài khoản đang xóa
            cmd = new SqlCommand(@"DELETE FROM Yeuthich WHERE tendangnhap = @tendangnhap;", conn);
            cmd.Parameters.AddWithValue("tendangnhap", tendn);
            cmd.ExecuteNonQuery();
            //Xóa tất cả những chặn có tendangnhap của tài khoản đang xóa
            cmd = new SqlCommand(@"DELETE FROM Chan WHERE tendangnhap = @tendangnhap;", conn);
            cmd.Parameters.AddWithValue("tendangnhap", tendn);
            cmd.ExecuteNonQuery();
            //Xóa tất cả những nhóm có tendangnhap của tài khoản đang xóa
            cmd = new SqlCommand(@"DELETE FROM NhomLienHe WHERE tendangnhap = @tendangnhap;", conn);
            cmd.Parameters.AddWithValue("tendangnhap", tendn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public string getHoten(string tendn)
        {
            conn.Open();
            string query = String.Format("SELECT hoten FROM QTV WHERE tendangnhap = '{0}';", tendn);
            SqlCommand cmd = new SqlCommand(query, conn);
            string hoten = cmd.ExecuteScalar().ToString();
            conn.Close();
            return hoten;
        }
    }
}
