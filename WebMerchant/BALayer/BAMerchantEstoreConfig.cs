using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantEstoreConfig
    {
        DAMerchantEstoreConfig _damecnfg = new DAMerchantEstoreConfig();
        internal int Insert(BOMerchantEstoreConfig _bomecnfg)
        {
            return _damecnfg.IUDEstoreConfig(_bomecnfg);
        }
    }
}