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
    class ToaThuocCtrl
    {
        ToaThuocMod ttMod = new ToaThuocMod();
        public DataTable GetData()
        {
            return ttMod.GetData();
        }
        public bool AddData(ToaThuocObj hdObj)
        {
            return ttMod.AddData(hdObj);
        }
        public bool DelData(string matt)
        {
            return ttMod.DelData(matt);
        }
    }
}
