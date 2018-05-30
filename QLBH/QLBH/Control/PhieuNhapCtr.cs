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
    class PhieuNhapCtr
    {
        PhieuNhapModel hdMod = new PhieuNhapModel();
        public DataTable GetData()
        {
            return hdMod.GetData();
        }
        public DataTable GetID()
        {
            return hdMod.GetID();
        }
        public bool AddData(PhieuNhapobj hdObj)
        {
            return hdMod.AddData(hdObj);
        }
        public bool DelData(string ma)
        {
            return hdMod.DelData(ma);
        }
        public bool UpdateTT(string SoPN, long TongTien)
        {
            return  hdMod.UpdateTT(SoPN, TongTien);
        }
    }
}
