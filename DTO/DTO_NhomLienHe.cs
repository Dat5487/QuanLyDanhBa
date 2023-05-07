using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_NhomLienHe
    {
        private string _ma_nhom;

        public string Ma_nhom
        {
            get { return _ma_nhom; }
            set { _ma_nhom = value; }
        }
        private string _tennhom;

        public string TenNhom
        {
            get { return _tennhom; }
            set { _tennhom = value; }
        }

        private string _tendangnhap;

        public string Tendangnhap
        {
            get { return _tendangnhap; }
            set { _tendangnhap = value; }
        }
    }
}
