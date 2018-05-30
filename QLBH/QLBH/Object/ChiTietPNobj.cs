using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class ChiTietPNobj
    {
        string mahd, mahh;
        int sl, dongia,thanhtien;

        public int Dongia
        {
            get
            {
                return dongia;
            }

            set
            {
                dongia = value;
            }
        }

        public string Mahd
        {
            get
            {
                return mahd;
            }

            set
            {
                mahd = value;
            }
        }

        public string Mahh
        {
            get
            {
                return mahh;
            }

            set
            {
                mahh = value;
            }
        }

        public int Sl
        {
            get
            {
                return sl;
            }

            set
            {
                sl = value;
            }
        }

        public int Thanhtien
        {
            get
            {
                return thanhtien;
            }

            set
            {
                thanhtien = value;
            }
        }
        public ChiTietPNobj() { }

        public ChiTietPNobj(string mahd, string mahh, int sl, int dongia,int thanhtien)
        {
            this.mahd = mahd;
            this.mahh = mahh;
            this.sl = sl;
            this.dongia = dongia;
            this.thanhtien = thanhtien;
        }
    }
}
