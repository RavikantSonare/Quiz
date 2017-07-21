using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAFinanceConfig
    {
        private DAFinanceConfig _dafncfg = new DAFinanceConfig();

        internal int Update(BOFinanceConfig _bofncfg)
        {
            return _dafncfg.IUD(_bofncfg);
        }

        internal int Insert(BOFinanceConfig _bofncfg)
        {
            return _dafncfg.IUD(_bofncfg);
        }

        internal DataTable SelectFinanceConfigDetail(string v, int mId)
        {
            return _dafncfg.SelectfinanceconfigDetail(v, mId);
        }

        internal DataTable SelectFCDetailFID(string v1, int v2)
        {
            return _dafncfg.SelectFCDetailFID(v1, v2);
        }
    }
}