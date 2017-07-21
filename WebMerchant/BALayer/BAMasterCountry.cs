using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMasterCountry
    {
        private DAMasterCountry _damstcountry = new DAMasterCountry();
        internal DataTable GetCountryList(string v)
        {
            return _damstcountry.GeCountryList(v);
        }
    }
}