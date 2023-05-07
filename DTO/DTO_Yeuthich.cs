using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class DTO_Yeuthich
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
