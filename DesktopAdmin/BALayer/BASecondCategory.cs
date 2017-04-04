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
    public class BASecondCategory
    {
        DASecondCategory dascat = new DASecondCategory();

        public DataTable SelectSecondCategory(BOSecondCategory _boscat)
        {
            return dascat.SelectSecondCategory(_boscat);
        }

        public int Insert(BOSecondCategory _boscat)
        {
            return dascat.IUDSecondCategory(_boscat);
        }

        public int Update(BOSecondCategory _boscat)
        {
            return dascat.IUDSecondCategory(_boscat);
        }

        public int Delete(BOSecondCategory _boscat)
        {
            return dascat.IUDSecondCategory(_boscat);
        }

        public List<BOSecondCategory> SelectSecondCategoryList(BOSecondCategory _boscat)
        {
            return dascat.SelectSecondCategoryList(_boscat);
        }
    }
}
