using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAMyUser
    {
        private DAMyUser _damyuser = new DAMyUser();

        public int Update(BOMyUser _bomyuser)
        {
            return _damyuser.IUDMyUser(_bomyuser);
        }

        public int Insert(BOMyUser _bomyuser)
        {
            return _damyuser.IUDMyUser(_bomyuser);
        }

        public List<BOMyUser> SelectUserDetail(BOMyUser _bomyuser)
        {
            return _damyuser.SelectUserDetail(_bomyuser);
        }

        internal int Delete(BOMyUser _bomyuser)
        {
            return _damyuser.IUDMyUser(_bomyuser);
        }
    }
}
