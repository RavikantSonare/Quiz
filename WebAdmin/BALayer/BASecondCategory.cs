using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BASecondCategory
    {
        private DASecondCategory _dascat = new DASecondCategory();

        internal DataTable SelectSecondCatgoryList(string v)
        {
            return _dascat.SelectSecondCategory(v);
        }

        public int Insert(BOSecondCategory _boscat)
        {
            return _dascat.IUDSecondCategory(_boscat);
        }

        public int Update(BOSecondCategory _boscat)
        {
            return _dascat.IUDSecondCategory(_boscat);
        }

        public int Delete(BOSecondCategory _boscat)
        {
            return _dascat.IUDSecondCategory(_boscat);
        }

        internal DataTable SelectSecodCategoryWithID(string v, int scatId)
        {
            return _dascat.SelectSecodCategoryWithID(v, scatId);
        }

        internal DataTable SelectSecondCatgorywithSearch(string v, string text)
        {
            return _dascat.SelectSecondCatgorywithSearch(v, text);
        }
    }
}