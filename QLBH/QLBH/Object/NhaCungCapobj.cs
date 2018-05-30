using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class NhaCungCapobj
    {
        string ma, tenncc, diachi, email, sdt;

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

        public string Tenncc
        {
            get
            {
                return tenncc;
            }

            set
            {
                tenncc = value;
            }
        }
        public NhaCungCapobj()
        {  }
        public NhaCungCapobj(string ma, string tenncc, string diachi, string email,string sdt)
        {
            this.ma = ma;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.email = email;
            this.sdt = sdt;


        }
    }
}
