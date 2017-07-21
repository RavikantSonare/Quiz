using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAMerchantManage
    {
        DAMerchantManage _damermng = new DAMerchantManage();

        public DataTable SelectExamManage(string eventtxt)
        {
            return _damermng.SelectMerchantManage(eventtxt);
        }

        public DataTable SelectMerchantManage(string eventtxt, int merchantid)
        {
            return _damermng.SelectMerchantManageWithId(eventtxt, merchantid);
        }

        public int Update(BOMerchantManage _bomermng)
        {
            return _damermng.IUDMerchantManage(_bomermng);
        }

        public int UpdateStatus(BOMerchantManage _bomermng)
        {
            return _damermng.UpdateStatus(_bomermng);
        }
    }
}