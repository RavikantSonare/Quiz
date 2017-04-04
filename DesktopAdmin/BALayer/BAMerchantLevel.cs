using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAMerchantLevel
    {
        DAMerchantLevel _damerlvl = new DAMerchantLevel();

        public int Update(BOMerchantLevel _bomerlvl)
        {
            return _damerlvl.IUDMerchantLevel(_bomerlvl);
        }

        public int Insert(BOMerchantLevel _bomerlvl)
        {
            return _damerlvl.IUDMerchantLevel(_bomerlvl);
        }

        public List<BOMerchantLevel> GetMerchantLevelList(BOMerchantLevel _bomerlvl)
        {
            return _damerlvl.SelectMerchantLevelList(_bomerlvl);
        }

        public int Delete(BOMerchantLevel _bomerlvl)
        {
            return _damerlvl.IUDMerchantLevel(_bomerlvl);
        }
    }
}
