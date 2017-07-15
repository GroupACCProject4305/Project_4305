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
    class BenhNhanCtrl
    {
        BenhNhanMod bnMod = new BenhNhanMod();

        public DataTable GetData()
        {
            return bnMod.GetData();
        }

        public bool AddData(BenhNhanObj bnObj)
        {
            return bnMod.AddData(bnObj);
        }

        public bool UpdData(BenhNhanObj bnObj)
        {
            return bnMod.UpdData(bnObj);
        }

        public bool DelData(string mabn)
        {
            return bnMod.DelData(mabn);
        }
    }
}
