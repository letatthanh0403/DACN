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
    class KhachHangCtr
    {
        KhachHangModel khMod = new KhachHangModel();
        public DataTable GetData()
        {
            return khMod.GetData();
        }
        public bool AddData(KhachHangobj khObj)
        {
            return khMod.AddData(khObj);
        }
        public bool UpdData(KhachHangobj khObj)
        {
            return khMod.UpdData(khObj);
        }

        public bool DelData(string ma)
        {
            return khMod.DelData(ma);
        }
    }
}
