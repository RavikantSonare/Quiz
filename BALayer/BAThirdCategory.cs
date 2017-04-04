using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BOLayer;
using DALayer;

namespace BALayer
{
    public class BAThirdCategory
    {
        private DAThirdCategory datcat = new DAThirdCategory();
        public List<BOThirdCategory> SelectThirdCategoryList(BOThirdCategory _bothirdcate)
        {
            return datcat.SelectThirdCategoryList(_bothirdcate);
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
    }
}
