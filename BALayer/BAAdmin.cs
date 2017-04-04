using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAAdmin
    {
        DAAdmin daadmin = new DAAdmin();
        public BOAdmin SelectAdminLogin(string Event,string username, string password)
        {
            return daadmin.SelectLoginUsers(Event, username, password);
        }
    }
}
