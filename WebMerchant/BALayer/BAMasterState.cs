using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMasterState
    {
        private DAMasterState _damststate = new DAMasterState();
        internal DataTable GetStateList(string v, string countryid)
        {
            return _damststate.GetStatelist(v, countryid);
        }
    }
}