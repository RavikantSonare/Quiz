using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Estore.BOLayer;
using Estore.DALayer;

namespace Estore.BALayer
{
    public class BAAllOperation
    {
        DAAllOperation _daallopt = new DAAllOperation();
        public BOAllCount AllCount()
        {
            return _daallopt.AllCount();
        }

        public DataSet ListAllCategory()
        {
            return _daallopt.ListAllCategory();
        }
    }
}