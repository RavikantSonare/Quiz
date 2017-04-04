using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BASalesReports
    {
        private DASalesReports _daslsrprt = new DASalesReports();

        internal List<BOSalesReports> SelectSalesReprotsWithMrid(string v, int mrid)
        {
            return _daslsrprt.SelectSalesReportsWithId(v, mrid);
        }
    }
}
