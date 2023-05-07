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
    public class DAL_Yeuthich
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8G5OH0Q\SQLEXPRESS;Initial Catalog=DanhBaDienTu;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter();
        SqlDataAdapter da2 = new SqlDataAdapter();
        string tendn;
        public DAL_Yeuthich(string tendn)
        {
            this.tendn = tendn;

            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(da2);

            string query = String.Format("SELECT * FROM Yeuthich WHERE tendangnhap = '{0}'", tendn);
            da1.SelectCommand = new SqlCommand(query, conn);
            da1.TableMappings.Add("Table", "Yeuthich");
            da1.Fill(ds, "Yeuthich");

            query = String.Format("SELECT * FROM LienHe WHERE tendangnhap = '{0}'", tendn);
            da2.SelectCommand = new SqlCommand(query, conn);
            da2.TableMappings.Add("Table", "LienHe");
            da2.Fill(ds, "LienHe");
        }

        public DataTable getTable(string name)
        {
            return ds.Tables[name];
        }

        public DataTable getGridYeuthich()
        {
            conn.Open();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                string strSql = String.Format("Select LienHe.ma_lienhe, hoten, sdt, diachi,gioitinh, ngaysinh, mail, mangxh, ghichu, ma_nhom,tennhom,LienHe.tendangnhap From LienHe INNER JOIN Yeuthich ON LienHe.ma_lienhe = Yeuthich.ma_lienhe Where LienHe.tendangnhap = '{0}';", tendn);
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

        public void ThemYeuThich(int ma_lienhe)
        {
            DataRow r = getTable("Yeuthich").NewRow();
            conn.Open();
            r["ma_lienhe"] = ma_lienhe;
            r["tendangnhap"] = tendn;
            conn.Close();
            try
            {
                ds.Tables["Yeuthich"].Rows.Add(r);
                da1.Update(ds, "Yeuthich");
                ds.AcceptChanges();
            }
            catch { }
        }

        public void XoaYeuThich(int ma_lienhe)
        {
            try
            {
                string query = String.Format("ma_lienhe= {0}", ma_lienhe);
                DataRow[] rows = getTable("Yeuthich").Select(query);
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    da1.Update(ds, "Yeuthich");
                    ds.AcceptChanges();
                }
            }
            catch (Exception) { }
        }

        public Boolean getTrangThaiYT(int ma_lienhe)
        {
            Boolean kq = false;
            string query = String.Format("ma_lienhe = {0}", ma_lienhe);
            DataRow[] rows = getTable("Yeuthich").Select(query);
            if (rows.Length > 0)
            {
                kq = true;
            }
            return kq;
        }

        public int getSoLuongYeuThich()
        {
            conn.Open();
            string query = String.Format("SELECT COUNT(ma_lienhe) FROM Yeuthich WHERE tendangnhap = '{0}';", tendn);
            SqlCommand cmd = new SqlCommand(query, conn);
            int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return soluong;
        }
    }
}
