using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using WebUser.BOLayer;

namespace WebUser
{
    public partial class OnlineTestReport : System.Web.UI.Page
    {
        #region Global Variables
        // public int currentQuestionIndex;
        static BOExamManage _examqueanslist = new BOExamManage();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetail"] != null)
            {
                BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                if (Session["ExamList"] != null)
                {
                    _examqueanslist = (BOExamManage)Session["ExamList"];
                    lblExamCode.Text = _examqueanslist.ExamCode;
                    lblResultMsg.Text = "Congratulation!! You has passed the " + _examqueanslist.ExamTitle + " exam";
                    lblResultMsg.ForeColor = System.Drawing.Color.Green;
                    lblExamName.Text = _examqueanslist.ExamTitle;
                    lbldate.Text = DateTime.Now.ToShortDateString();
                    lbltime.Text = DateTime.Now.ToShortTimeString();
                }
            }
        }
        protected void LoadData(object sender, EventArgs e)
        {
            Thread.Sleep(6000);
        }
    }
}