using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ExamSimulator.BOLayer;
using ExamSimulator.DALayer;

namespace ExamSimulator.BALayer
{
    class BAExamManage
    {
        DAExamManage _daexmange = new DAExamManage();
        internal List<BOExamManage> SelectExamDetail(string v, int uid)
        {
            return _daexmange.SelectExamDetail(v, uid);
        }

        public BOExamManage SelectExamQestionAnswer(string v, int exmid)
        {
            return _daexmange.SelectExamQestionAnswer(v, exmid);
        }

        public BOExamManage SelectExamQestionAnswerbase64(string v, int exmid)
        {
            return _daexmange.SelectExamQestionAnswerbase64(v, exmid);
        }
    }
}
