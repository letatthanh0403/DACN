using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBH.Model;
using QLBH.Object;
namespace QLBH.Control
{
    class ChiTietHDCtr
    {
        ChiTietHDModel ctMod = new ChiTietHDModel();
        public DataTable GetData(string ma)
        {
            return ctMod.GetData(ma);
        }
        public DataTable Getdata(string dk)
        {
            return ctMod.Getdata(dk);
        }
        public bool AddData(DataTable dt)
        {
            return ctMod.AddData(dt);
        }
        public bool AddData(ChiTietHDobj hdObj)
        {
            return ctMod.AddData(hdObj);
        }
        public bool DelData(string ma,string mamh)
        {
            return ctMod.DelData(ma,mamh);
        }
    }
}
