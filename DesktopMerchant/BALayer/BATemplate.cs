using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BATemplate
    {
        private DATemplate _datmplt = new DATemplate();

        internal int Update(BOTemplate _botmplt)
        {
            return _datmplt.IUDTemplate(_botmplt);
        }

        internal int Insert(BOTemplate _botmplt)
        {
            return _datmplt.IUDTemplate(_botmplt);
        }

        internal List<BOTemplate> SelecttemplateList(string v, int mid)
        {
            return _datmplt.SelectTemplatelist(v, mid);
        }

        internal int Delete(BOTemplate _botmplt)
        {
            return _datmplt.IUDTemplate(_botmplt);
        }
    }
}
