using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantAllowSales
    {
        DAMerchantAllowSales _damallsls = new DAMerchantAllowSales();

        internal DataTable SelectAllowSales(string v, int examid)
        {
            return _damallsls.SelectAllowsales(v, examid);
        }

        internal int Insert(BOMerchantAllowSales _bomallsales)
        {
            return _damallsls.IUDAllowSales(_bomallsales);
        }
    }
}