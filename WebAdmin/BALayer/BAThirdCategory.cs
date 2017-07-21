using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.BALayer
{
    public class BAThirdCategory
    {
        private DAThirdCategory datcat = new DAThirdCategory();

        public DataTable SelectThirdCategoryList(string txtevent)
        {
            return datcat.SelectThirdCategory(txtevent);
        }

        public int Insert(BOThirdCategory _bothirdcate)
        {
            return datcat.IUDThirdCategory(_bothirdcate);
        }

        public int Update(BOThirdCategory _bothirdcate)
        {
            return datcat.IUDThirdCategory(_bothirdcate);
        }

        public int Delete(BOThirdCategory _bothirdcate)
        {
            return datcat.IUDThirdCategory(_bothirdcate);
        }

        internal DataTable SelectThirdCategoryWithID(string v, int ThirdcatId)
        {
            return datcat.SelectThirdCategoryWithID(v, ThirdcatId);
        }

        internal DataTable SelectThirdCatgorywithSearch(string v, string text)
        {
            return datcat.SelectThirdCatgorywithSearch(v, text);
        }
    }
}