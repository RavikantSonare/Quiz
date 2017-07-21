using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BASalesReports
    {
        private DASalesReports _daslsrpt = new DASalesReports();
        internal DataTable SelectSalesReprotsWithMrid(string v, int mid)
        {
            return _daslsrpt.SelectSalesReport(v, mid);
        }
    }
}