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
    class HangHoaCtr
    {
        HangHoaModel hhMod = new HangHoaModel();
        public DataTable GetData()
        {
            return hhMod.GetData();
        }
        public DataTable NhaSanXuat()
        {
            return hhMod.NhaSX();
        }
        public DataTable GetData(string dieukien)
        {
            return hhMod.GetData(dieukien);
        }
        public DataTable GetData2(string dieukien)
        {
            return hhMod.GetData2(dieukien);
        }
    }
}
