using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class KhachHangobj
    {
        string ma, tenkh, gioitinh, diachi, sdt;

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
            }
        }

        public string Ma
        {
            get
            {
                return ma;
            }

            set
            {
                ma = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public string Tenkh
        {
            get
            {
                return tenkh;
            }

            set
            {
                tenkh = value;
            }
        }
        public KhachHangobj() { }
        public KhachHangobj(string ma,string tenkh,string gioitinh,string diachi, string sdt)
        {
            this.ma = ma;
            this.tenkh = tenkh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
        }
    }
}
