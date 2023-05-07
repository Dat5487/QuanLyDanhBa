using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Chan
    {
        DAL_Chan db;
        public BUS_Chan(string tendn)
        {
            db = new DAL_Chan(tendn);
        }
        public void ThemChan(int ma_lienhe)
        {
            db.ThemChan(ma_lienhe);
        }
        public DataTable getGridChan()
        {
            return db.getGridChan();
        }
        public Boolean getTrangThaiChan(int ma_lienhe)
        {
            return db.getTrangThaiChan(ma_lienhe);
        }
        public void XoaChan(int ma_lienhe)
        {
            db.XoaChan(ma_lienhe);
        }
        public int getSoLuongChan()
        {
            return db.getSoLuongChan();
        }
    }
}
