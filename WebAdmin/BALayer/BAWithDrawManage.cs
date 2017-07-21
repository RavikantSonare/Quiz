using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAWithDrawManage
    {
        private DAWithDrawManage _dawdwmng = new DAWithDrawManage();

        public DataTable SelectWithDrawManageList(string txtevent)
        {
            return _dawdwmng.SelectWithDrawManageList(txtevent);
        }

        public int Update(BOWithDrawManage _bowdwmng)
        {
            return _dawdwmng.IUDWithDrawManage(_bowdwmng);
        }
    }
}