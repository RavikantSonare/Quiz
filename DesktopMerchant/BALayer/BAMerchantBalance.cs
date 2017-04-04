using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAMerchantBalance
    {
        private DAMerchantBalance _damerblnc = new DAMerchantBalance();
        internal decimal SelectMerbalance(string eventtxt, int mid)
        {
            return _damerblnc.SelectMerchantBalance(eventtxt, mid);
        }
    }
}
