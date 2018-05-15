using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class Nhanvienobj
    {
        string ma, tennv, email, gioitinh, cmnd, matkhau, maqh;
        string ngaysinh;

        public string Cmnd
        {
            get
            {
                return cmnd;
            }

            set
            {
                cmnd = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
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

        public string Maqh
        {
            get
            {
                return maqh;
            }

            set
            {
                maqh = value;
            }
        }

        public string Matkhau
        {
            get
            {
                return matkhau;
            }

            set
            {
                matkhau = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public string Tennv
        {
            get
            {
                return tennv;
            }

            set
            {
                tennv = value;
            }
        }
        public Nhanvienobj() { }
        public Nhanvienobj(string ma,string tennv, string email,string ngaysinh, string gioitinh, string cmnd, string matkhau, string maqh)
        {
            this.ma = ma;
            this.tennv = tennv;
            this.email = email;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.cmnd = cmnd;
            this.matkhau = matkhau;
            this.maqh = maqh;
        }
    }
}
