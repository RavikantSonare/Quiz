using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BATopCategory
    {
        private DATopCategory _datcat = new DATopCategory();
        internal DataTable SelectTopCategoryList(string v)
        {
            return _datcat.SelectTopCategory(v);
        }

        internal int Insert(BOTopCategory _botcat)
        {
            return _datcat.IUDTopCategory(_botcat);
        }

        internal int Update(BOTopCategory _botcat)
        {
            return _datcat.IUDTopCategory(_botcat);
        }

        internal int Delete(BOTopCategory _botcat)
        {
            return _datcat.IUDTopCategory(_botcat);
        }

        internal DataTable SelectTopCategoryWithID(string v, int tidId)
        {
            return _datcat.SelectTopCategorywithId(v, tidId);
        }

        internal DataTable SelectTopCategorywithSearch(string v, string text)
        {
            return _datcat.SelectTopCategorywithSearch(v, text);
        }
    }
}