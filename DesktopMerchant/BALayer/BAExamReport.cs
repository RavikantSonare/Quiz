using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAExamReport
    {
        private DAExamReport _daexmrpt = new DAExamReport();

        internal List<BOExamReport> SelectExamreportList(string v, int mid)
        {
            return _daexmrpt.SelectExamreportList(v, mid);
        }
    }
}
