using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Estore.BOLayer;
using Estore.DALayer;

namespace Estore.BALayer
{
    public class BAAllCount
    {
        DAAllCount _daallcnt = new DAAllCount();
        public BOAllCount AllCount()
        {
            return _daallcnt.AllCount();
        }
    }
}