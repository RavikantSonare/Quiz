﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebUser.BOLayer;
using WebUser.DAlayer;

namespace WebUser.BALayer
{
    public class BAExamManage
    {
        DAExamManage _daexmange = new DAExamManage();
        internal DataTable SelectExamDetail(string v, int uid)
        {
            return _daexmange.SelectExamDetail(v, uid);
        }
    }
}