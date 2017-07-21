using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantBalance
    {
        private DAMerchantBalance _damerlbalnc = new DAMerchantBalance();

        internal decimal SelectMerbalance(string v, int mid)
        {
            return _damerlbalnc.SelectMerchantBalance(v, mid);
        }
    }
}