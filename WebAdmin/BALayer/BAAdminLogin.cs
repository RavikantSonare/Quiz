using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAAdminLogin
    {
        private DAAdminLogin _daadminlogin = new DAAdminLogin();
        internal BOAdminLogin SelectAdminloginDetail(string eventtxt, string username, string password)
        {
            return _daadminlogin.SelectAdminDetail(eventtxt, username, password);
        }
    }
}