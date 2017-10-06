using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;


namespace WebAdmin.BALayer
{
    public class BAExtraPermission
    {
        private DAExtraPermission _daextper = new DAExtraPermission();

        public DataTable SelectExtraPermission(string eventtxt)
        {
            return _daextper.SelectExtraPermission(eventtxt);
        }
    }
}