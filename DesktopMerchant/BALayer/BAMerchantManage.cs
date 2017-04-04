using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAMerchantManage
    {
        DAMerchantManage _damermng = new DAMerchantManage();
        public BOMerchantManage SelectMerchantLogin(string Event, string username, string password)
        {
            return _damermng.SelectLoginUsers(Event, username, password);
        }

        public List<BOMerchantManage> SelectMerchantDetail(int loginid, BOMerchantManage _bomer)
        {
            return _damermng.SelectMerchantDetail(loginid, _bomer);
        }

        internal DateTime SelectValiddate(string Event, int merchantId)
        {
            return _damermng.SelectValiddate(Event, merchantId);
        }
    }
}
