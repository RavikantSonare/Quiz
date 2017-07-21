using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMyUsers
    {
        private DAMyUsers _damyuser = new DAMyUsers();

        internal DataTable SelectUserDetail(string v, int mid)
        {
            return _damyuser.SelectUserList(v, mid);
        }

        internal int Insert(BOMyUsers _bomyuser)
        {
            return _damyuser.IUDUserDetail(_bomyuser);
        }

        internal int Update(BOMyUsers _bomyuser)
        {
            return _damyuser.IUDUserDetail(_bomyuser);
        }

        internal int Delete(BOMyUsers _bomyuser)
        {
            return _damyuser.IUDUserDetail(_bomyuser);
        }

        internal DataTable SelectUserDetailWithID(string v, int userId)
        {
            return _damyuser.SelectUserListWithUID(v, userId);
        }
    }
}