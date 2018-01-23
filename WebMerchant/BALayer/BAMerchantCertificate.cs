using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantCertificate
    {
        private DAMerchantCertificate _dacertificate = new DAMerchantCertificate();

        internal DataTable SelectCertifcateList(string v, int mid)
        {
            return _dacertificate.SelectCertifcateList(v, mid);
        }

        internal int Update(BOMerchantCertificate _bomercerfict)
        {
            return _dacertificate.IUDCertifcate(_bomercerfict);
        }

        internal int Insert(BOMerchantCertificate _bomercerfict)
        {
            return _dacertificate.IUDCertifcate(_bomercerfict);
        }

        internal int Delete(BOMerchantCertificate _bomercerfict)
        {
            return _dacertificate.IUDCertifcate(_bomercerfict);
        }

        internal DataTable SelectCertifcateDetailWithID(string v, int exmrptId)
        {
            return _dacertificate.SelectCertifcateWithTid(v, exmrptId);
        }
    }
}