using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class ChiTietHDobj
    {
        string mahd, mahh;

        public string MaHangHoa
        {
            get { return mahh; }
            set { mahh = value; }
        }

        public string MaHoaDon
        {
            get { return mahd; }
            set { mahd = value; }
        }
        int sl;



        public int SoLuong
        {
            get { return sl; }
            set { sl = value; }
        }


        public ChiTietHDobj() { }

        public ChiTietHDobj(string mahd, string mahh, int sl)
        {
            this.mahd = mahd;
            this.mahh = mahh;
            this.sl = sl;

        }
    }
}
