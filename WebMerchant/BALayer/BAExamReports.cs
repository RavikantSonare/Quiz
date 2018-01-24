using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAExamReports
    {
        private DAExamReports _daexmrpt = new DAExamReports();

        internal DataTable SelectExamreportList(string v, int mid)
        {
            return _daexmrpt.SelectExamReportlist(v, mid);
        }

        internal DataTable SelectExamreport(string v, int rptid)
        {
            return _daexmrpt.SelectExamReport(v, rptid);
        }
    }
}