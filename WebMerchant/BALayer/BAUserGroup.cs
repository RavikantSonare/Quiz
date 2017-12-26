using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.BALayer
{
    public class BAUserGroup
    {
        DAUserGroup _dausrgrp = new DAUserGroup();
        internal DataTable SelectGroupDetail(string eventtxt, int mid)
        {
            return _dausrgrp.SelectGroupDetail(eventtxt, mid);
        }

        internal DataTable SelectGroupDetailWithGroupID(string v, int groupId)
        {
            return _dausrgrp.SelectGroupDetailWithGroupID(v, groupId);
        }

        internal int Delete(BOUserGroup _bousergrp)
        {
            return _dausrgrp.IUDGroupDetail(_bousergrp);
        }

        internal int Update(BOUserGroup _bousergrp)
        {
            return _dausrgrp.IUDGroupDetail(_bousergrp);
        }

        internal int Insert(BOUserGroup _bousergrp)
        {
            return _dausrgrp.IUDGroupDetail(_bousergrp);
        }
    }
}