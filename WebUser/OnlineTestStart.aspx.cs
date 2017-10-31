using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser
{
    public partial class OnlineTestStart : System.Web.UI.Page
    {
        static int hh, mm, ss;

        static double TimeAllSecondes = 3600;
        BOExamManage _examqueanslist;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["exmid"] != null)
                        {
                            string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                            GetExamDetail(examid);
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GetExamDetail(string examid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            _examqueanslist = _baexmmng.SelectExamQestionAnswer("GetEQAWithQId", Convert.ToInt32(examid));
            if (_examqueanslist != null)
            {
                lblExamCode.Text = _examqueanslist.ExamCode;
                lblTotalQuestion.Text = Convert.ToString(_examqueanslist.QuestionList.Count);
                //FormView1.DataSource = _examqueanslist.QuestionList;
                //FormView1.DataBind();
                dlquesanswer.DataSource = _examqueanslist.QuestionList.Take(1);
                dlquesanswer.DataBind();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;
            }

            TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            hh = time_Span.Hours;
            mm = time_Span.Minutes;
            ss = time_Span.Seconds;

            Label2.Text = "  " + hh + ":" + mm + ":" + ss;
        }
    }
}