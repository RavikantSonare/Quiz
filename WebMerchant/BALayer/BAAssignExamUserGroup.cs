using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAAssignExamUserGroup
    {
        DAAssignExamUserGroup _daaeug = new DAAssignExamUserGroup();
        internal int Insert(BOAssignExamUserGroup _boaeug)
        {
            return _daaeug.IUDAssignExamUser(_boaeug);
        }
    }
}