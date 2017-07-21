using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAExamManage
    {
        DAExamManage _daexmmng = new DAExamManage();

        public DataTable SelectExamManageList(string eventtxt)
        {
            return _daexmmng.SelectExamManageList(eventtxt);
        }

        internal int Update(BOExamManage _boexmmng)
        {
            return _daexmmng.IUD_ExamManage(_boexmmng);
        }

        public List<BOExamManage> SelectExamManageListSearch(string eventtxt)
        {
            return _daexmmng.SelectExamManageListSearch(eventtxt);
        }
    }
}