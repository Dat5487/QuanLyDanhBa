using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Chan
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8G5OH0Q\SQLEXPRESS;Initial Catalog=DanhBaDienTu;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter();
        SqlDataAdapter da2 = new SqlDataAdapter();
        string tendn;
        public DAL_Chan(string tendn)
        {
            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(da2);

            string query = String.Format("SELECT * FROM Chan WHERE tendangnhap = '{0}'", tendn);
            da1.SelectCommand = new SqlCommand(query, conn);
            da1.TableMappings.Add("Table", "Chan");
            da1.Fill(ds, "Chan");

            query = String.Format("SELECT * FROM LienHe WHERE tendangnhap = '{0}'", tendn);
            da2.SelectCommand = new SqlCommand(query, conn);
            da2.TableMappings.Add("Table", "LienHe");
            da2.Fill(ds, "LienHe");

            DataRelation relation = new DataRelation("Chan_LienHe",
                ds.Tables["Chan"].Columns["ma_lienhe"],
                ds.Tables["LienHe"].Columns["ma_lienhe"], false);
            ds.Relations.Add(relation);
            this.tendn = tendn;
        }

        public DataTable getTable(string name)
        {
            return ds.Tables[name];
        }

        public DataTable getGridChan()
        {
            conn.Open();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                string strSql = String.Format("Select LienHe.ma_lienhe, hoten, sdt, diachi, ngaysinh, gioitinh, mail, mangxh, ghichu, ma_nhom,tennhom,LienHe.tendangnhap From LienHe INNER JOIN Chan ON LienHe.ma_lienhe = Chan.ma_lienhe Where LienHe.tendangnhap = '{0}';", tendn);
                cmd.CommandText = strSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            return dt;
        }

        public void ThemChan(int ma_lienhe)
        {
            DataRow r = getTable("Chan").NewRow();
            conn.Open();
            r["ma_lienhe"] = ma_lienhe;
            r["tendangnhap"] = tendn;
            conn.Close();
            try
            {
                ds.Tables["Chan"].Rows.Add(r);
                da1.Update(ds, "Chan");
                ds.AcceptChanges();
            }
            catch { }
        }

        public void XoaChan(int ma_lienhe)
        {
            try
            {
                string query = String.Format("ma_lienhe= {0}", ma_lienhe);
                DataRow[] rows = getTable("Chan").Select(query);
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    da1.Update(ds, "Chan");
                    ds.AcceptChanges();
                }
            }
            catch (Exception) {}
        }

        public Boolean getTrangThaiChan(int ma_lienhe)
        {
            Boolean kq = false;
            string query = String.Format("ma_lienhe = {0}", ma_lienhe);
            DataRow[] rows = getTable("Chan").Select(query);
            if (rows.Length > 0)
            {
                kq = true;
            }
            return kq;
        }

        public int getSoLuongChan()
        {
            conn.Open();
            string query = String.Format("SELECT COUNT(ma_lienhe) FROM Chan WHERE tendangnhap = '{0}';", tendn);
            SqlCommand cmd = new SqlCommand(query, conn);
            int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return soluong;
        }
    }
}
