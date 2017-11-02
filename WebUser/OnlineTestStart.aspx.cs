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
        #region Global Variables
        static int currentQuestionIndex = 0;
        BOExamManage _examqueanslist = new BOExamManage();
        #endregion

        static int hh, mm, ss;
        static double TimeAllSecondes = 3600;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                    if (Request.QueryString["exmid"] != null && Request.QueryString["tstmd"] != null)
                    {
                        string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                        _examqueanslist = GetEQAList(examid, Request.QueryString["tstmd"]);
                        GetExamDetail(_examqueanslist);
                    }
                    else
                    {
                        Response.Redirect("UserLogin.aspx");
                    }
                    if (!IsPostBack)
                    {

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

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex -= 1;
                btnnext.Enabled = true;
                showQuestionNo(currentQuestionIndex + 1);
                GetExamDetail(_examqueanslist);
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < _examqueanslist.QuestionList.Count - 1)
            {
                currentQuestionIndex += 1;
                btnprevious.Enabled = true;
                showQuestionNo(currentQuestionIndex + 1);
                GetExamDetail(_examqueanslist);
            }
        }

        private BOExamManage GetEQAList(string examid, object mode)
        {
            BAExamManage _baexmmng = new BAExamManage();
            var list = _baexmmng.SelectExamQestionAnswer("GetEQAWithQId", Convert.ToInt32(examid));
            list.Event = mode.ToString();
            return list;
        }

        private void GetExamDetail(BOExamManage _exmlist)
        {
            if (_exmlist != null)
            {
                lblExamCode.Text = _exmlist.ExamCode;
                lblTotalQuestion.Text = Convert.ToString(_exmlist.QuestionList.Count);
                dlquesanswer.DataSource = _exmlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                dlquesanswer.DataBind();
                showQuestionNo(currentQuestionIndex + 1);
            }
            else
            {
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }

        private void showQuestionNo(int qno)
        {
            try
            {
                lblOutofTotalQuestion.Text = qno.ToString();
                if (currentQuestionIndex == 0)
                {
                    btnnext.Enabled = true;
                    btnprevious.Enabled = false;
                }
                if (currentQuestionIndex == _examqueanslist.QuestionList.Count - 1)
                {
                    btnprevious.Enabled = true;
                    btnnext.Enabled = false;
                }
            }
            catch
            {

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