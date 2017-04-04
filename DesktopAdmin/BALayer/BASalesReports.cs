using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BASalesReports
    {
        private DASalesReports _daslsrpt = new DASalesReports();

        public List<BOSalesReports> SelectSalesReportsList(BOSalesReports _boslsrpt)
        {
            return _daslsrpt.SelectSalesReportsList(_boslsrpt);
        }

        public int Update(BOSalesReports _boslsrpt)
        {
            return _daslsrpt.IUDSalesReports(_boslsrpt);
        }
    }
}
