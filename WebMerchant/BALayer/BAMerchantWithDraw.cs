using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAMerchantWithDraw
    {
        private DAMerchantWithDraw _damerwidrw = new DAMerchantWithDraw();
        internal DataTable SelectWithDrawDetail(string v, int mid)
        {
            return _damerwidrw.SelectwithDrawDetail(v, mid);
        }

        internal int Getordrno(string v)
        {
            return _damerwidrw.Gerordreno(v);
        }

        internal int Insert(BOMerchantWithDraw _bomerwidrw)
        {
            return _damerwidrw.IUD_BoWithDrawManage(_bomerwidrw);
        }
    }
}