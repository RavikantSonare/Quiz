using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAMerchantFeeRate
    {
        private DAMerchantFeeRate _damerfrt = new DAMerchantFeeRate();
        public int Update(BOMerchantFeeRate _bomerfrt)
        {
            return _damerfrt.IUDMerchantLevel(_bomerfrt);
        }

        public int Insert(BOMerchantFeeRate _bomerfrt)
        {
            return _damerfrt.IUDMerchantLevel(_bomerfrt);
        }

        public List<BOMerchantFeeRate> GetMerchantLevelList(BOMerchantFeeRate _bomerfrt)
        {
            return _damerfrt.SelectMerchantLevelList(_bomerfrt);
        }

        public int Delete(BOMerchantFeeRate _bomerfrt)
        {
            return _damerfrt.IUDMerchantLevel(_bomerfrt);
        }
    }
}
