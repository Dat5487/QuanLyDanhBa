using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_QTV
    {
        private DAL_QTV db = new DAL_QTV();

        public DataViewManager getGridTaiKhoan()
        {
            return db.getGridTaiKhoan();
        }

        private Boolean TenDN_not_Exist(string tendangnhap)
        {
            Boolean kq = true;
            DataRow[] rows = db.getTable("QTV").Select("tendangnhap='" + tendangnhap + "'");
            if (rows.Length > 0)
            {
                kq = false;
            }
            return kq;
        }

        public string Kiemtra_Login(DTO_QTV admin)
        {
            return db.Kiemtra_Login(admin);
        }

        public Boolean add_New_TK(DTO_QTV tk)
        {
            Boolean kq = false;
            if (TenDN_not_Exist(tk.Tendangnhap))
            {
                db.themDongTK(tk);
                kq = true;
            }
            return kq;
        }
        public Boolean sua_TK(DTO_QTV tk,string username)
        {
            if (db.sua_TK(tk,username))
            {
                return true;
            }
            else
                return false;
        }
        public Boolean xoa_TK(string username)
        {
            if (db.xoa_TK(username))
            {
                return true;
            }
            else
                return false;
        }

        public DataTable TimKiem(string tukhoa)
        {
            return db.TimKiem(tukhoa);
        }

        public DTO_QTV getTTTK(DTO_QTV tk, string username)
        {
            return db.getTTTK(tk, username);
        }

        public void xoatatca(string tendn)
        {
            db.xoatatca(tendn);
        }

        public string getHoten(string tendn)
        {
            return db.getHoten(tendn);
        }
    }
}
