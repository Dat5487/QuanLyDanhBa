using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_Chan
    {
        private string _ma_lienhe;
        public string Ma_lienhe
        {
            get { return _ma_lienhe; }
            set { _ma_lienhe = value; }
        }
        private string _tendangnhap;

        public string Tendangnhap
        {
            get { return _tendangnhap; }
            set { _tendangnhap = value; }
        }

    }
}
