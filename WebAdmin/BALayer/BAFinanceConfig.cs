using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAFinanceConfig
    {
        private DAFinanceConfig _dafncfg = new DAFinanceConfig();
        internal DataTable SelectFinanceConfigDetail(string v, int mId)
        {
            return _dafncfg.SelectfinanceconfigDetail(v, mId);
        }
    }
}