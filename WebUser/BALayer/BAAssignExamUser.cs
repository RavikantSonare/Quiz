using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUser.BOLayer;
using WebUser.DAlayer;

namespace WebUser.BALayer
{
    public class BAAssignExamUser
    {
        DAAssignExamUser _daaeu = new DAlayer.DAAssignExamUser();
        internal int IUD(BOAssignExamUser _boaeu)
        {
           return _daaeu.IUD(_boaeu);
        }
    }
}