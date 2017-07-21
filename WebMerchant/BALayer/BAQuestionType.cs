using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAQuestionType
    {
        DAQuestionType _daqtype = new DAQuestionType();

        internal DataTable SelectQuestionTypeList(string v,int levelid)
        {
            return _daqtype.SelectQuestionTypelist(v, levelid);
        }
    }
}