using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAExamManage
    {
        private DAExamManage _daexmmng = new DAExamManage();

        internal DataTable SelectExamDetail(string eventtext, int merchantid)
        {
            return _daexmmng.SelectExamDetail(eventtext, merchantid);
        }

        internal int Insert(BOExamManage _boexmmng)
        {
            return _daexmmng.IUD(_boexmmng);
        }

        internal int Update(BOExamManage _boexmmng)
        {
            return _daexmmng.IUD(_boexmmng);
        }

        internal int Delete(BOExamManage _boexmmng)
        {
            return _daexmmng.IUD(_boexmmng);
        }

        internal DataTable SelectExamDetailWithID(string txtevent, int examid)
        {
            return _daexmmng.SelectExamDetailWithID(txtevent, examid);
        }
    }
}