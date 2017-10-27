using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Estore.BOLayer;
using Estore.DALayer;

namespace Estore.BALayer
{
    public class BAMerchantManage
    {
        private DAMerchantManage _damchntmng = new DAMerchantManage();

        internal BOMerchantManage SelectMerchantLogin(string eventtxt, string username, string password)
        {
            return _damchntmng.SelectmerchantLogin(eventtxt, username, password);
        }
    }
}