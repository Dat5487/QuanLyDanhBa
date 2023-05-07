using System;

namespace DTO
{
    public class DTO_QTV
    {
        private string _tendangnhap;
        public string Tendangnhap
        {
            get { return _tendangnhap; }
            set { _tendangnhap = value; }
        }
        private string _matkhau;

        public string Matkhau
        {
            get { return _matkhau; }
            set { _matkhau = value; }
        }
        private string _quyenhan;

        public string Quyenhan
        {
            get { return _quyenhan; }
            set { _quyenhan = value; }
        }

        private string _hoten;

        public string Hoten
        {
            get { return _hoten; }
            set { _hoten = value; }
        }

    }
}
