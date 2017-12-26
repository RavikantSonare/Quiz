using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAUserAccess
    {
        DAUserAccess _dausraccess = new DAUserAccess();
        internal DataTable SelectUserAccess(string eventtxt)
        {
            return _dausraccess.SelectUserAccess(eventtxt);
        }
    }
}