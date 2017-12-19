using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BABundleExam
    {
        private DABundleExam _dabndlexm = new DABundleExam();
        internal int Update(BOBundleExam _bobndlexm)
        {
            return _dabndlexm.IUDBundle(_bobndlexm);
        }

        internal int Insert(BOBundleExam _bobndlexm)
        {
            return _dabndlexm.IUDBundle(_bobndlexm);
        }

        internal DataTable SelectBundleDetail(string v, int merchantid)
        {
            return _dabndlexm.SelectBundleDetail(v, merchantid);
        }
    }
}