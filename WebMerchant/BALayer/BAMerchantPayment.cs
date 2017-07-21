using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantPayment
    {
        DAMerchantPayment _damerpay = new DAMerchantPayment();
        internal int IUDPaymentDetail(BOMerchantPayment _bomerpmt)
        {
            return _damerpay.IUD(_bomerpmt);
        }
    }
}