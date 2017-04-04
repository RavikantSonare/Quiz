using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BATopCategory
    {
        DATopCategory _datopcat = new DATopCategory();
        internal List<BOTopCategory> SelectTopCategoryList(BOTopCategory _botopcat)
        {
            return _datopcat.SelectTopCatList(_botopcat);
        }
    }
}
