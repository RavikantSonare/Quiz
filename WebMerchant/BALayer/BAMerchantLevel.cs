using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantLevel
    {
        DAMerchantLevel _damerlvl = new DAMerchantLevel();
        internal DataTable GetMerchantLevelList(string v)
        {
            return _damerlvl.SelectMerchantLevelList(v);
        }
    }
}