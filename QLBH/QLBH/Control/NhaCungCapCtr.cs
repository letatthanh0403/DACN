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
    class NhaCungCapCtr
    {
        NhaCungCapModel ncc = new NhaCungCapModel();
        public DataTable GetData()
        {
            return ncc.GetData();
        }
    }
}
