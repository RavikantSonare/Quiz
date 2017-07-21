using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BASecondCategory
    {
        private DASecondCategory _daseccat = new DASecondCategory();
        internal DataTable SelectSecondCategoryList(string strevent, string topcatid)
        {
            return _daseccat.SelectSecondCategory(strevent, topcatid);
        }

        internal DataTable SelectSecondCategoryList(string v)
        {
            return _daseccat.SelectAllSecondCategory(v);
        }

        internal int Insert(BOSecondCategory _boscat)
        {
            return _daseccat.IUD(_boscat);
        }
    }
}