using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BASalesReport
    {
        private DASalesReport _daslsrpt = new DASalesReport();

        public DataTable SelectSalesReportsList(string eventtxt)
        {
            return _daslsrpt.SelectSalesReportsList(eventtxt);
        }

        public int Update(BOSalesReport _boslsrpt)
        {
            return _daslsrpt.IUDSalesReports(_boslsrpt);
        }
    }
}