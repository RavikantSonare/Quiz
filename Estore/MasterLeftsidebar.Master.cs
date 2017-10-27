using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Estore.BOLayer;
using Estore.BALayer;

namespace Estore
{
    public partial class MasterLeftsidebar : System.Web.UI.MasterPage
    {
        BAAllOperation _baallopt = new BAAllOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindLeftSideBarCategory();
        }

        private void BindLeftSideBarCategory()
        {
            DataSet _dtset = new DataSet();
            _dtset = _baallopt.ListAllCategory();
            _dtset.Relations.Add(new DataRelation("CategoriesRelation", _dtset.Tables[0].Columns["TopCategoryId"],
        _dtset.Tables[1].Columns["TopCategoryId"]));
        }
    }
}