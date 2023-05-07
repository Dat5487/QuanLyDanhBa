using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Yeuthich
    {
        DAL_Yeuthich db;

        public BUS_Yeuthich(string tendn) {
            db = new DAL_Yeuthich(tendn);
        }

        public void ThemYeuThich(int ma_lienhe)
        {
            db.ThemYeuThich(ma_lienhe);
        }

        public DataTable getGridYeuthich()
        {
            return db.getGridYeuthich();
        }

        public Boolean getTrangThaiYT(int ma_lienhe)
        {
            return db.getTrangThaiYT(ma_lienhe);
        }

        public void XoaYeuThich(int ma_lienhe)
        {
            db.XoaYeuThich(ma_lienhe);
        }

        public int getSoLuongYeuThich()
        {
            return db.getSoLuongYeuThich();
        }
    }
}
