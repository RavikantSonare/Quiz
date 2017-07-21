using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAPaymentOption
    {
        private DAPaymentOption _dapmtopt = new DAPaymentOption();
        internal DataTable SelectPaymentOptionList(string v)
        {
            return _dapmtopt.PaymentOptionList(v);
        }
    }
}