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
    public class DAL_NhomLienHe
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8G5OH0Q\SQLEXPRESS;Initial Catalog=DanhBaDienTu;Integrated Security=True");
        private DataSet ds = null;
        private SqlDataAdapter da1 = null;
        private SqlDataAdapter da2= null;
        string tendn;
        public DAL_NhomLienHe(string tendn)
        {
            this.tendn= tendn;
            ds = new DataSet();

            da1 = new SqlDataAdapter();
            da2 = new SqlDataAdapter();

            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(da2);

            string query = String.Format("SELECT * FROM NhomLienHe WHERE tendangnhap = '{0}'",tendn);
            da1.SelectCommand = new SqlCommand(query, conn);
            da1.TableMappings.Add("Table", "NhomLienHe");
            da1.Fill(ds, "NhomLienHe");
            query = String.Format("SELECT * FROM LienHe WHERE tendangnhap = '{0}'", tendn);
            da2.SelectCommand = new SqlCommand(query, conn);
            da2.TableMappings.Add("Table", "LienHe");
            da2.Fill(ds, "LienHe");

        }

        public DataViewManager getGridNhom(string tendn)
        {
            return ds.DefaultViewManager;
        }

        public DataTable getTable(string name)
        {
            return ds.Tables[name];
        }

        public int getMaxId()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Max(ma_nhom) FROM NhomLienHe;", conn);
            int id = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;
            conn.Close();
            return id;
        }

        public Boolean themDongNhom(DTO_NhomLienHe nhom)
        {
            DataRow r = getTable("NhomLienHe").NewRow();
            r["tennhom"] = nhom.TenNhom;
            r["ma_nhom"] = getMaxId();
            r["tendangnhap"] = tendn;
            try
            {
                ds.Tables["NhomLienHe"].Rows.Add(r);
                da1.Update(ds, "NhomLienHe");
                ds.AcceptChanges();
                return true;
            }
            catch(Exception) { return false; }
        }

        //Sửa ma_nhom và tennhom của các liên hệ
        public void suaTTNhom(string ma_nhom, string ten_nhom)
        {
            string query = String.Format("ma_nhom= '{0}'", ma_nhom);
            foreach (DataRow r in ds.Tables["LienHe"].Select(query))
            {
                r.BeginEdit();
                r["tennhom"] = ten_nhom;
                r.EndEdit();
                da2.Update(ds, "LienHe");
                ds.AcceptChanges();
            }
        }

        public Boolean sua_Nhom(DTO_NhomLienHe nhom)
        {
            Boolean kq = false;
            DataRow[] rows = getTable("NhomLienHe").Select("ma_nhom='" + nhom.Ma_nhom + "'");
            if (rows.Length > 0)
            {
                rows[0].BeginEdit();
                rows[0]["tennhom"] = nhom.TenNhom;
                rows[0].EndEdit();
                try
                {
                    da1.Update(ds, "NhomLienHe");
                    ds.AcceptChanges();
                    suaTTNhom(nhom.Ma_nhom, nhom.TenNhom);
                    kq = true;
                }
                catch(Exception) { kq = false; }
                
            }
            else
            {
                kq = false;
            }
            return kq;
        }

        //Xóa ma_nhom và tennhom của các liên hệ
        public void xoaTTNhom(string ma_nhom)
        {
            string query = String.Format("ma_nhom= '{0}'", ma_nhom);
            foreach (DataRow r in ds.Tables["LienHe"].Select(query))
            {
                r.BeginEdit();
                r["tennhom"] = null;
                r["ma_nhom"] = null;
                r.EndEdit();
                da2.Update(ds, "LienHe");
                ds.AcceptChanges();
            }
        }

        public Boolean xoa_Nhom(string ma_nhom)
        {
            Boolean kq = false;
            DataRow[] rows = getTable("NhomLienHe").Select("ma_nhom='" + ma_nhom + "'");
            if (rows.Length > 0)
            {
                rows[0].Delete();
                xoaTTNhom(ma_nhom);
                try
                {
                    da1.Update(ds, "NhomLienHe");
                    ds.AcceptChanges();
                    kq = true;
                }
                catch(Exception) { kq = false; }
            }
            else
            {
                kq = false;
            }
            return kq;
        }

        public DTO_NhomLienHe getTT(string ma_nhom)
        {
            DTO_NhomLienHe nhom = new DTO_NhomLienHe();
            foreach (DataRow r in getTable("NhomLienHe").Rows)
                if (r["ma_nhom"].ToString() == ma_nhom)
                {
                    nhom.TenNhom = r["tennhom"].ToString();
                    nhom.Tendangnhap = r["tendangnhap"].ToString();
                }
            return nhom;
        }

        public List<DTO_NhomLienHe> getDsNhom()
        {
            List<DTO_NhomLienHe> dsNhom = new List<DTO_NhomLienHe>();
            DataTable dt = getTable("NhomLienHe");
            DTO_NhomLienHe nhom;

            foreach (DataRow r in getTable("NhomLienHe").Select("tendangnhap='" + tendn + "'"))
                {
                    nhom = new DTO_NhomLienHe();
                    nhom.TenNhom = r["tennhom"].ToString();
                    nhom.Ma_nhom = r["ma_nhom"].ToString();
                    dsNhom.Add(nhom);
                }
            return dsNhom;
        }

        public DataTable getGridNhomLH(string ma_nhom)
        {
            try
            {
                DataTable dt = getTable("LienHe");
                if (ma_nhom == "0")
                    return dt;
                else
                {
                    DataRow[] rows = dt.Select("ma_nhom = '" + ma_nhom + "'");
                    return rows.CopyToDataTable();
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
        public int getSoLuongNhom()
        {
            string query = String.Format("SELECT COUNT(ma_nhom) FROM NhomLienHe WHERE tendangnhap = '{0}';", tendn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return soluong;
        }
    }
}
