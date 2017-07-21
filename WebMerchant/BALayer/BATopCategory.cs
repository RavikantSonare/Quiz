using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BATopCategory
    {
        private DATopCategory _datopcat = new DATopCategory();

        internal DataTable SelectTopCategoryList(string eventtxt)
        {
            return _datopcat.SelectTopCategory(eventtxt);
        }
    }
}