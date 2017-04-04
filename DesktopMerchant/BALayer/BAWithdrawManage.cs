using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using DesktopMerchant.DALayer;

namespace DesktopMerchant.BALayer
{
    class BAWithDrawManage
    {
        DAWithDrawManage _dawmng = new DAWithDrawManage();
        internal int Getordrno(string v)
        {
            return _dawmng.Getorderno(v);
        }

        internal int Insert(BOWithDrawManage _bowmng)
        {
            return _dawmng.IUD_BoWithDrawManage(_bowmng);
        }

        internal List<BOWithDrawManage> SelectWithDrawRecord(string v, int merchantID)
        {
            return _dawmng.SelectWithdrawRecord(v, merchantID);
        }
    }
}
