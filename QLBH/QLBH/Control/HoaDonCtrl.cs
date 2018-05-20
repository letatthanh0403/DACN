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
    class HoaDonCtrl
    {
        HoaDonModel hdMod = new HoaDonModel();
        public DataTable GetData()
        {
            return hdMod.GetData();
        }
        public bool AddData(HoaDonobj hdObj)
        {
            return hdMod.AddData(hdObj);
        }
        public bool DelData(string ma)
        {
            return hdMod.DelData(ma);
        }
    }
}
