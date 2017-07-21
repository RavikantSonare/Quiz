using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
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

        public int Delete(BOMerchantFeeRate _bomerfrt)
        {
            return _damerfrt.IUDMerchantLevel(_bomerfrt);
        }

        public DataTable GetMerchantLevelList(string txtevent)
        {
            return _damerfrt.SelectMerchantLevelList(txtevent);
        }

        internal DataTable SelectFeeRateWithID(string v, int frateId)
        {
            return _damerfrt.SelectFeeRateWithID(v, frateId);
        }
    }
}