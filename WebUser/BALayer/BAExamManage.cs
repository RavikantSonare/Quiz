using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebUser.BOLayer;
using WebUser.DAlayer;

namespace WebUser.BALayer
{
    public class BAExamManage
    {
        DAExamManage _daexmange = new DAExamManage();
        internal DataTable SelectExamDetail(string v, string searchtext, int uid)
        {
            return _daexmange.SelectExamDetail(v, searchtext, uid);
        }

        public DataTable SelectExamDetailWithID(string v, int exmid)
        {
            return _daexmange.SelectExamDetailWithID(v, exmid);
        }

        public BOExamManage SelectExamQestionAnswer(string v, int exmid)
        {
            return _daexmange.SelectExamQestionAnswer(v, exmid);
        }

        public BOExamManage SelectExamQestionAnswerbase64(string v, int exmid)
        {
            return _daexmange.SelectExamQestionAnswerbase64(v, exmid);
        }

        internal int IUD(BOExamManage _boexammanage)
        {
            return _daexmange.IUD(_boexammanage);
        }
    }
}