using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAQAManage
    {
        private DAQAManage _daqamng = new DAQAManage();

        internal int Insert(BOQAManage _boqamng)
        {
            return _daqamng.IUDQA(_boqamng);
        }

        internal int Update(BOQAManage _boqamng)
        {
            return _daqamng.IUDQA(_boqamng);
        }

        internal int Delete(BOQAManage _boqamng)
        {
            return _daqamng.IUDQA(_boqamng);
        }

        internal DataTable SelectQAmanageList(string eventxt, int mid)
        {
            return _daqamng.SelectQAlist(eventxt, mid);
        }

        internal DataTable SelectQAmanagRecord(string eventxt, int qid)
        {
            return _daqamng.SelectQARecord(eventxt, qid);
        }

        internal DataTable SelectQAmanageListWithSearch(string v, string text, int merchantId)
        {
            return _daqamng.SelectQAmanageListwithSearch(v, text, merchantId);
        }
    }
}