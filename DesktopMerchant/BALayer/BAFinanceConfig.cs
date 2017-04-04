using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAFinanceConfig
    {
        private DAFinanceConfig _dafcnfg = new DAFinanceConfig();
        internal int Insert(BOFinanceConfig _bofcnfg)
        {
            return _dafcnfg.IUDFinanceConfig(_bofcnfg);
        }

        internal int Update(BOFinanceConfig _bofcnfg)
        {
            return _dafcnfg.IUDFinanceConfig(_bofcnfg);
        }

        internal List<BOFinanceConfig> SelectFinanceConfigList(BOFinanceConfig _bofcnfg)
        {
            return _dafcnfg.SelectFinancConfigList(_bofcnfg);
        }
    }
}
