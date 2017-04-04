using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BASecondCategory
    {
        private DASecondCategory _dascecat = new DASecondCategory();
        public List<BOSecondCategory> SelectSecondCategoryList(BOSecondCategory _boseccat)
        {
            return _dascecat.selectSecondCatelist(_boseccat);
        }

        internal List<BOSecondCategory> SelectSecondCatListWithTop(string eventtxt,int topcatid)
        {
            return _dascecat.selectSecondCatelistWithTop(eventtxt,topcatid);
        }
    }
}
