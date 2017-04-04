using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAExamConfig
    {
        private DAExamConfig _daexmcnfg = new DAExamConfig();
        internal List<BOExamConfig> SelectExamConfigByMerchant(BOExamConfig _boexmcnfg)
        {
            return _daexmcnfg.SelectExamconfglist(_boexmcnfg);
        }

        internal int Update(BOExamConfig _boexmcnfg)
        {
            return _daexmcnfg.IUDExamConfig(_boexmcnfg);
        }

        internal int Insert(BOExamConfig _boexmcnfg)
        {
            return _daexmcnfg.IUDExamConfig(_boexmcnfg);
        }

        internal int Delete(BOExamConfig _boexmcnfg)
        {
            return _daexmcnfg.IUDExamConfig(_boexmcnfg);
        }
    }
}
