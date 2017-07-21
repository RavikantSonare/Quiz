using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BATemplate
    {
        private DATemplate _datemplate = new DATemplate();

        internal DataTable SelecttemplateList(string v, int mid)
        {
            return _datemplate.SelectTemplatelist(v, mid);
        }

        internal int Update(BOTemplate _botmplt)
        {
            return _datemplate.IUDTemplate(_botmplt);
        }

        internal int Insert(BOTemplate _botmplt)
        {
            return _datemplate.IUDTemplate(_botmplt);
        }

        internal int Delete(BOTemplate _botmplt)
        {
            return _datemplate.IUDTemplate(_botmplt);
        }

        internal DataTable SelectTemplateDetailWithID(string v, int exmrptId)
        {
            return _datemplate.SelectTemplateWithTid(v, exmrptId);
        }
    }
}