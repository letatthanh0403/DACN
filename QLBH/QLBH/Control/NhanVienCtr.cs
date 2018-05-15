using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Object;
using QLBH.Model;
using System.Data;

namespace QLBH.Control
{
    class NhanVienCtr
    {
        NhanVienModel nvMod = new NhanVienModel();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool AddData(Nhanvienobj nvObj)
        {
            return nvMod.AddData(nvObj);
        }
        public bool UpdData(Nhanvienobj nvObj)
        {
            return nvMod.UpdData(nvObj);
        }

        public bool DelData(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
