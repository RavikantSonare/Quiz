using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAPaymentOption
    {
        DAPaymentOption _dapopt = new DAPaymentOption();

        public List<BOPaymentOption> SelectPaymentOptionList(BOPaymentOption _bopymopt)
        {
            return _dapopt.SelectPaymentOption(_bopymopt);
        }
    }
}
