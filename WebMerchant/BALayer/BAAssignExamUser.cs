using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAAssignExamUser
    {
        DAAssignExamUser _daaeu=new DAAssignExamUser();
        internal int Insert(BOAssignExamUser _boaeu)
        {
           return _daaeu.IUDAssignExamUser(_boaeu);
        }
    }
}