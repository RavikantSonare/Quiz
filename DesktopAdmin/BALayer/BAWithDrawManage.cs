using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAWithDrawManage
    {
        private DAWithDrawManage _dawdwmng = new DAWithDrawManage();

        public List<BOWithDrawManage> SelectWithDrawManageList(BOWithDrawManage _bowdwmng)
        {
            return _dawdwmng.SelectWithDrawManageList(_bowdwmng);
        }

        public int Update(BOWithDrawManage _bowdwmng)
        {
            return _dawdwmng.IUDWithDrawManage(_bowdwmng);
        }
    }
}
