using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAPaymentOption
    {
        DAPaymentOption _dapopt = new DAPaymentOption();

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

        public DataTable SelectPaymentOptionList(string txtevent)
        {
            return _dapopt.SelectPaymentOption(txtevent);
        }

        internal DataTable SelectPaymentOptionWithID(string v, int poptId)
        {
            return _dapopt.SelectPaymentOptionWithID(v, poptId);
        }
    }
}