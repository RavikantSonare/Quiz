using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantManage
    {
        private DAMerchantManage _damchntmng = new DAMerchantManage();

        internal BOMerchantManage SelectMerchantLogin(string eventtxt, string username, string password)
        {
            return _damchntmng.SelectmerchantLogin(eventtxt, username, password);
        }

        internal DataTable SelectMerchantDetail(string eventtxt, int merchantid)
        {
            return _damchntmng.SelectMerchantDetail(eventtxt, merchantid);
        }

        internal DateTime SelectValiddate(string v, int merchantId)
        {
            return _damchntmng.ValidDate(v, merchantId);
        }

        public int Insert(BOMerchantManage _bomermng)
        {
            return _damchntmng.IUDMerchantManage(_bomermng);
        }
    }
}