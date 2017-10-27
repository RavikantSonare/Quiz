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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllCount();
        }

        private void AllCount()
        {
            BAAllOperation _baallcnt = new BAAllOperation();
            BOAllCount _boallcnt = new BOAllCount();
            _boallcnt = _baallcnt.AllCount();
            lblMerchantCount.Text = _boallcnt.TotalMerchant.ToString();
            lblUserCount.Text = _boallcnt.TotalUser.ToString();
            lblExamCount.Text = _boallcnt.TotalExams.ToString();
            lblQuestionCount.Text = _boallcnt.TotalQuestion.ToString();
        }
    }
}