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
    class ChiTietTTCtrl
    {
        ChiTietTTMod ctMod = new ChiTietTTMod();
        public DataTable GetData()
        {
            return ctMod.GetData();
        }

        public DataTable LayData(string dieukien)
        {
            return ctMod.LayData(dieukien);
        }

        public bool AddData(ChiTietToaThuocObj ctObj)
        {
            return ctMod.AddData(ctObj);
        }
        public bool DelData(string ma)
        {
            return ctMod.DelData(ma);
        }
    }
}
