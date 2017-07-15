using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLphongkham.Model;
using QLphongkham.Object;

namespace QLphongkham.Control
{
    class HoaDonCtrl
    {
        HoaDonMod hdMod = new HoaDonMod();
        public DataTable GetData()
        {
            return hdMod.GetData();
        }
        public bool AddData(HoaDonThuocObj hdObj)
        {
            return hdMod.AddData(hdObj);
        }
        public bool DelData(string matt)
        {
            return hdMod.DelData(matt);
        }
    }
}
