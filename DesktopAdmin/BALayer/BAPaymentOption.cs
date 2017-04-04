using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAPaymentOption
    {
        DAPaymentOption _dapopt = new DAPaymentOption();

        public List<BOPaymentOption> SelectPaymentOptionList(BOPaymentOption _bopymopt)
        {
            return _dapopt.SelectPaymentOption(_bopymopt);
        }

        public int Update(BOPaymentOption _bopymopt)
        {
            return _dapopt.IUDPaymentOption(_bopymopt);
        }

        public int Insert(BOPaymentOption _bopymopt)
        {
            return _dapopt.IUDPaymentOption(_bopymopt);
        }

        public int Delete(BOPaymentOption _bopymopt)
        {
            return _dapopt.IUDPaymentOption(_bopymopt);
        }
    }
}
