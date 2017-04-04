using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAMerchantManage
    {
        DAMerchantManage _damermng = new DAMerchantManage();

        public List<BOMerchantManage> GetMerchantLevelList(BOMerchantManage _bomermng)
        {
            return _damermng.SelectMerchantManage(_bomermng);
        }

        public int Update(BOMerchantManage _bomermng)
        {
            return _damermng.IUDMerchantManage(_bomermng);
        }
    }
}
