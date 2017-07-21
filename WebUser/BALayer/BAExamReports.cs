using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebUser.BOLayer;
using WebUser.DAlayer;

namespace WebUser.BALayer
{
    public class BAExamReports
    {
        DAExamReports _daexmrpt = new DAExamReports();
        internal DataTable SelectExamReport(string v, int uid)
        {
            return _daexmrpt.SelectExamReport(v, uid);
        }
    }
}