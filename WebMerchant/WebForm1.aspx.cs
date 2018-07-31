using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMerchant
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            abc a = new abc();
            a.add(10, 20.0);
        }
    }

    class abc
    {
        public void add(int a,int b)
        {
            Console.Write(Convert.ToString(a+b));

        }
        public void add(int a, double b)
        {
            Console.Write(Convert.ToString(a + b));
        }
    }
}