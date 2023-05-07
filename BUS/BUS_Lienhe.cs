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
    public class BUS_Lienhe
    {
        DAL_Lienhe db;
        public BUS_Lienhe(string tendn) {
            db = new DAL_Lienhe(tendn);
        }

        public Boolean add_New_LH(DTO_LienHe lh)
        {
            return db.themDongLH(lh);
        }

        public DataSet getDataSetLienHe()
        {
            return db.getDataSetLienHe();
        }

        public DTO_LienHe getTTTK(DTO_LienHe tk, string id)
        {
            return db.getTTTK(tk, id);
        }

        public Boolean sua_LH(DTO_LienHe lh, int ma_lienhe)
        {
            return db.sua_LH(lh, ma_lienhe);
        }

        public Boolean xoa_LH(string sdt)
        {
            return db.xoa_LH(sdt);
        }

        public DataTable TimKiemHoten(string tukhoa)
        {
            return db.TimKiemHoten(tukhoa);
        }

        public DataTable TimKiemSdt(string tukhoa)
        {
            return db.TimKiemSdt(tukhoa);
        }

        public int getSoLuongLH(string tendn)
        {
            return db.getSoLuongLH(tendn);
        }
        public DataTable getTable(string table)
        {
            return db.getTable(table);
        }

    }
}
