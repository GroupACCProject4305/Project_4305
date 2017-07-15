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
    class PhieuKhamCtrl
    {
        PhieuKhamMod pkMod = new PhieuKhamMod();
        public DataTable GetData()
        {
            return pkMod.GetData();
        }
        public bool AddData(PhieuKhamObj pkObj)
        {
            return pkMod.AddData(pkObj);
        }
        public bool UpdData(PhieuKhamObj pkObj)
        {
            return pkMod.UpdData(pkObj);
        }
        public bool DelData(string mapk)
        {
            return pkMod.DelData(mapk);
        }
    }
}
