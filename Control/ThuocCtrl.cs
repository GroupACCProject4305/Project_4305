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
    class ThuocCtrl
    {
        ThuocMod thMod = new ThuocMod();

        public DataTable GetData()
        {
            return thMod.GetData();
        }

        public bool AddData(ThuocObj thObj)
        {
            return thMod.AddData(thObj);
        }

        public bool UpdData(ThuocObj thObj)
        {
            return thMod.UpdData(thObj);
        }

        public bool DelData(string mathuoc)
        {
            return thMod.DelData(mathuoc);
        }
    }
}
