using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BOLayer;
using DALayer;

namespace BALayer
{
   public  class BATopCategory
    {
        DATopCategory datcat = new DATopCategory();

        public int Insert(BOTopCategory _botcat)
        {
            return datcat.IUDTopCategory(_botcat);
        }

        public DataTable SelectTopCategory(BOTopCategory _botcat)
        {
            return datcat.SelectTopCategory(_botcat);
        }

        public int Update(BOTopCategory _botcat)
        {
            return datcat.IUDTopCategory(_botcat);
        }

        public int Delete(BOTopCategory _botcat)
        {
            return datcat.IUDTopCategory(_botcat);
        }
        public List<BOTopCategory> SelectTopCategoryList(BOTopCategory _botcat)
        {
            return datcat.SelectTopCategoryList(_botcat);
        }
    }
}
