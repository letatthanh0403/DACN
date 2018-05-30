using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Object
{
    class PhieuNhapobj
    {
        string ma, ngaylap, nguoilap, ncc;
        int tongtien;

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

        public string Ncc
        {
            get
            {
                return ncc;
            }

            set
            {
                ncc = value;
            }
        }

        public string Ngaylap
        {
            get
            {
                return ngaylap;
            }

            set
            {
                ngaylap = value;
            }
        }

        public string Nguoilap
        {
            get
            {
                return nguoilap;
            }

            set
            {
                nguoilap = value;
            }
        }

        public int Tongtien
        {
            get
            {
                return tongtien;
            }

            set
            {
                tongtien = value;
            }
        }
        public PhieuNhapobj() { }
        public PhieuNhapobj(string nguoilap,string ncc )
        {
           
            this.nguoilap = nguoilap;
            this.ncc = ncc;
          
        }
    
    }
}
