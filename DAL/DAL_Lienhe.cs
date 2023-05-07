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
    public class DAL_Lienhe
    {
        string tendn;
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8G5OH0Q\SQLEXPRESS;Initial Catalog=DanhBaDienTu;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter();
        public DAL_Lienhe(string tendn)
        {
            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            string query = String.Format("SELECT * FROM LienHe WHERE tendangnhap = '{0}'",tendn);
            da1.SelectCommand = new SqlCommand(query, conn);
            da1.TableMappings.Add("Table", "LienHe");
            da1.Fill(ds, "LienHe");
            this.tendn = tendn;

        }
        public DataTable getTable(string name)
        {
            return ds.Tables[name];
        }

        public DataSet getDataSetLienHe()
        {
            return ds;
        }

        public int getMaxId()//Lấy Id lớn nhất + 1
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Max(ma_lienhe) FROM LienHe;", conn);
            int id = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;
            conn.Close();
            return id;
        }
        public Boolean themDongLH(DTO_LienHe lh)
        {
            DataRow r = getTable("LienHe").NewRow();
            r["ma_lienhe"] = getMaxId();
            r["hoten"] = lh.Hoten;
            r["sdt"] = lh.Sdt;
            r["diachi"] = lh.Diachi;
            r["ngaysinh"] = lh.Ngaysinh;
            r["mail"] = lh.Mail;
            r["mangxh"] = lh.Mangxh;
            r["ghichu"] = lh.Ghichu;
            if (lh.Gioitinh)
            {
                r["gioitinh"] = true;
            }
            else
            {
                r["gioitinh"] = false;
            }
            r["ma_nhom"] = null;
            r["tendangnhap"] = tendn;
            try
            {
                ds.Tables["LienHe"].Rows.Add(r);
                da1.Update(ds, "LienHe");
                ds.AcceptChanges();
                return true;
            }
            catch { return false; }
        }

        public Boolean sua_LH(DTO_LienHe lh, int ma_lienhe)
        {
            Boolean kq = false;
            string query = String.Format("ma_lienhe= {0}", ma_lienhe);
            DataRow[] rows = getTable("LienHe").Select(query);
            if (rows.Length > 0)
            {
                rows[0].BeginEdit();
                rows[0]["hoten"] = lh.Hoten;
                rows[0]["sdt"] = lh.Sdt;
                rows[0]["diachi"] = lh.Diachi;
                rows[0]["mail"] = lh.Mail;
                rows[0]["mangxh"] = lh.Mangxh;
                rows[0]["ngaysinh"] = lh.Ngaysinh;
                rows[0]["ghichu"] = lh.Ghichu;
                rows[0]["tennhom"] = lh.TenNhom;
                rows[0]["ma_nhom"] = lh.Ma_nhom;
                if (lh.Gioitinh)
                {
                    rows[0]["gioitinh"] = true;
                }
                else
                {
                    rows[0]["gioitinh"] = false;
                }
                rows[0].EndEdit();
                try
                {
                    da1.Update(ds, "LienHe");
                    ds.AcceptChanges();
                    kq = true;
                }
                catch (Exception) { kq = false; }
               
            }
            return kq;
        }

        public Boolean xoa_LH(string ma_lienhe)
        {
            Boolean kq = false;
            try
            {
                string query = String.Format("ma_lienhe= {0}", ma_lienhe);
                DataRow[] rows = getTable("LienHe").Select(query);
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    da1.Update(ds, "LienHe");
                    ds.AcceptChanges();
                    kq = true;
                }
                return kq;
            }
            catch(Exception) { return false; }

        }

        public DTO_LienHe getTTTK(DTO_LienHe lh, string sdt)
        {
            foreach (DataRow r in getTable("LienHe").Rows)
                if (r["sdt"].ToString() == sdt)
                {
                    lh.Hoten = r["hoten"].ToString();
                    lh.Sdt =  r["sdt"].ToString();
                    lh.Diachi = r["diachi"].ToString();
                    lh.Ngaysinh = DateTime.Parse(r["ngaysinh"].ToString());
                    if (Boolean.Parse(r["gioitinh"].ToString()))
                    {
                        lh.Gioitinh = true;
                    }
                    else
                        lh.Gioitinh = false;
                    lh.Mail = r["mail"].ToString();
                    lh.Mangxh = r["mangxh"].ToString();
                    lh.Ghichu = r["ghichu"].ToString();
                    lh.TenNhom = r["tennhom"].ToString();

                }
            return lh;
        }

        public DataTable TimKiemHoten(string tukhoa)
        {
            try
            {
                DataTable dt = getTable("LienHe");
                DataRow[] rows = dt.Select("hoten like '%" + tukhoa + "%'");
                return rows.CopyToDataTable();
            }
            catch (Exception) { return null; }
        }

        public DataTable TimKiemSdt(string sdt)
        {
            try
            {
                DataTable dt = getTable("LienHe");
                DataRow[] rows = dt.Select("CONVERT(sdt, System.String) like '%" + sdt + "%'");
                return rows.CopyToDataTable();
            }
            catch (Exception) { return null; }
        }

        public int getSoLuongLH(string tendn)
        {
            string query = String.Format("SELECT COUNT(ma_lienhe) FROM LienHe WHERE tendangnhap = '{0}';", tendn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return soluong;
        }
    }
}
