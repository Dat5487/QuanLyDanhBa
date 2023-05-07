using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhomLienHe
    {
        private DAL_NhomLienHe db;

        public BUS_NhomLienHe(string tendn)
        {
            db= new DAL_NhomLienHe(tendn);
        }

        public DataViewManager getGridNhom(string tendn)
        {
            return db.getGridNhom(tendn);
        }

        private Boolean TenNhom_not_Exist(string ten_nhom,string tendn)
        {
            Boolean kq = true;
            DataRow[] rows = db.getTable("NhomLienHe").Select("tennhom='" + ten_nhom + "'" + " AND tendangnhap='" + tendn + "'");
            if (rows.Length > 0)
            {
                kq = false;
            }
            return kq;
        }

        public Boolean add_New_Nhom(DTO_NhomLienHe nhom,string tendn)
        {
            Boolean kq = false;
            if (TenNhom_not_Exist(nhom.TenNhom, tendn))
            {
               kq = db.themDongNhom(nhom);
            }
            return kq;
        }

        public Boolean sua_Nhom(DTO_NhomLienHe nhom)
        {
            return db.sua_Nhom(nhom);
        }

        public Boolean xoa_Nhom(string nhom)
        {
            return db.xoa_Nhom(nhom);

        }

        public DTO_NhomLienHe getTT(string ma_nhom)
        {
            return db.getTT(ma_nhom);
        }

        public List<DTO_NhomLienHe> getDsNhom()
        {
            return db.getDsNhom();
        }

        public DataTable getGridNhomLH(string ma_nhom)
        {
            return db.getGridNhomLH(ma_nhom);
        }

        public int getSoLuongNhom()
        {
            return db.getSoLuongNhom();
        }
    }
}
