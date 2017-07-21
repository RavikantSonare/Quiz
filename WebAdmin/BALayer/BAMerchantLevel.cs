using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
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

        public int Delete(BOMerchantLevel _bomerlvl)
        {
            return _damerlvl.IUDMerchantLevel(_bomerlvl);
        }

        public DataTable GetMerchantLevelList(string txtevent)
        {
            return _damerlvl.SelectMerchantLevelList(txtevent);
        }

        internal DataTable SelectMerchantLevelWithID(string v, int mlvlId)
        {
            return _damerlvl.SelectMerchantLevelWithID(v, mlvlId);
        }
    }
}