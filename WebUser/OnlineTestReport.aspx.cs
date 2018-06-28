using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser
{
    public partial class OnlineTestReport : System.Web.UI.Page
    {
        #region Global Variables
        // public int currentQuestionIndex;
        static BOExamManage _examqueanslist = new BOExamManage();
        BOUser _bouserDetail;
        double resultScore;
        double passingSocre;
        double totalScore;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetail"] != null)
            {
                _bouserDetail = (BOUser)Session["UserDetail"];
                if (Session["ExamList"] != null)
                {
                    _examqueanslist = (BOExamManage)Session["ExamList"];
                    lblExamCode.Text = _examqueanslist.SecondCategory + " " + _examqueanslist.ExamCode;
                    lblExamName.Text = _examqueanslist.SecondCategory + " " + _examqueanslist.ExamCode;
                    passingSocre = ((_examqueanslist.QuestionList.Count() * 100) * Convert.ToDouble(_examqueanslist.PassingPercentage)) / 100;
                    resultScore = _examqueanslist.QuestionList.Where(ur => ur.UserResult == true).Count() * 100;
                    totalScore = _examqueanslist.QuestionList.Count() * 100;
                    lblpassingscore.Text = Convert.ToString(passingSocre) + "/" + (totalScore);
                    lblyourscore.Text = Convert.ToString(resultScore) + " / " + (totalScore);
                    //lblpbpassingvalue.Text = Convert.ToString(passingSocre);
                    // lblpbresultvalue.Text = Convert.ToString(_examqueanslist.QuestionList.Where(ur => ur.UserResult == true).Count() * 100);
                    string htmlpassingvalue = "<div class='progress-bar progress-bar-success' role='progressbar' aria-valuenow='" + Convert.ToString(passingSocre / (totalScore / 100)) + "' aria-valuemin='0' aria-valuemax='100'><span class='skill'><i class='val'>" + Convert.ToString(passingSocre) + "</i></span></div>";
                    pbpassingvalue.InnerHtml = htmlpassingvalue;
                    string htmlresultvalue = string.Empty;
                    if (resultScore >= passingSocre)
                    {
                        lblResultMsg.Text = "Congratulation!! You has passed the " + _examqueanslist.SecondCategory + " " + _examqueanslist.ExamCode + " exam";
                        lblResultMsg.ForeColor = System.Drawing.Color.Green;
                        htmlresultvalue = "<div class='progress-bar progress-bar-success' role='progressbar' aria-valuenow='" + Convert.ToString(resultScore / (totalScore / 100)) + "' aria-valuemin='0' aria-valuemax='100'><span class='skill'><i class='val'>" + Convert.ToString(resultScore) + "</i></span></div>";
                    }
                    else
                    {
                        lblResultMsg.Text = "Sorry!! You has failed the " + _examqueanslist.SecondCategory + " " + _examqueanslist.ExamCode + " exam";
                        lblResultMsg.ForeColor = System.Drawing.Color.Red;
                        if (resultScore != 0)
                            htmlresultvalue = "<div class='progress-bar progress-bar-danger' role='progressbar' aria-valuenow='" + Convert.ToString(resultScore / (totalScore / 100)) + "' aria-valuemin='0' aria-valuemax='100'><span class='skill'><i class='val'>" + Convert.ToString(resultScore) + "</i></span></div>";
                        else
                            htmlresultvalue = "<div class='progress-bar progress-bar-danger' role='progressbar' aria-valuenow='" + 1 + "' aria-valuemin='0' aria-valuemax='100'><span class='skill'><i class='val'>" + Convert.ToString(resultScore) + "</i></span></div>";
                    }
                    pbresultvalue.InnerHtml = htmlresultvalue;
                    DateTime now = DateTime.Now;
                    lbldate.Text = now.ToShortDateString();
                    lbltime.Text = now.ToLongTimeString();
                    Session.Remove("ExamList");
                    if (_examqueanslist.QuestionList.FirstOrDefault().Event == "TO")
                    {
                        UpdateExamManage(_examqueanslist);
                        InserExamReport(_examqueanslist);
                    }
                }
                else
                {
                    Response.Redirect("UserLogin.aspx");
                }
            }
        }
        protected void LoadData(object sender, EventArgs e)
        {
            Thread.Sleep(6000);
        }

        private void InserExamReport(BOExamManage _boexammanage)
        {
            try
            {
                if (_boexammanage != null)
                {
                    BOExamReports _boexrport = new BOExamReports();
                    BAExamReports _baexrport = new BAExamReports();
                    _boexrport.UserId = _bouserDetail.UserId;
                    _boexrport.CategoryId = 1;
                    _boexrport.ExamId = _boexammanage.ExamCodeId;
                    if (resultScore >= passingSocre)
                    {
                        _boexrport.Result = true;
                    }
                    else
                    {
                        _boexrport.Result = false;
                    }
                    _boexrport.Score = Convert.ToDecimal(resultScore);
                    _boexrport.OutofScore = Convert.ToDecimal(totalScore);
                    _boexrport.AllowPrint = true;
                    _boexrport.DigitalCertificateId = 1;
                    var rnd = new Random(DateTime.Now.Millisecond);
                    int ticks = rnd.Next(0, 3000);
                    _boexrport.CertificationNo = ticks;
                    _boexrport.ExamGivenDate = DateTime.UtcNow;
                    _boexrport.MerchantId = _bouserDetail.MerchantId;
                    _boexrport.IsActive = true;
                    _boexrport.IsDelete = false;
                    _boexrport.CreatedBy = _bouserDetail.UserId;
                    _boexrport.CreatedDate = DateTime.UtcNow;
                    _boexrport.UpdatedBy = _bouserDetail.UserId;
                    _boexrport.UpdatedDate = DateTime.UtcNow;
                    _boexrport.Event = "Insert";
                    _baexrport.Insert(_boexrport);
                }

            }
            catch (Exception ex)
            {
                Common.LogError(ex);
            }
        }

        private void UpdateExamManage(BOExamManage _boexammanage)
        {
            //BOExamManage _boexmnge = new BOExamManage();
            //BAExamManage _baexmmng = new BAExamManage();
            //_boexmnge.ExamCodeId = _boexammanage.ExamCodeId;
            //_boexmnge.OnlyTestOnce = false;
            //_boexmnge.UpdatedBy = _bouserDetail.UserId;
            //_boexmnge.UpdatedDate = DateTime.UtcNow;
            //_boexmnge.Event = "UpdateByUser";
            //_baexmmng.IUD(_boexmnge);

            ///6June2018 New table for TestOnce permission

            BOAssignExamUser _boaeu = new BOAssignExamUser();
            BAAssignExamUser _baaeu = new BAAssignExamUser();
            _boaeu.ExamId = _boexammanage.ExamCodeId;
            _boaeu.UserId = _bouserDetail.UserId;
            _boaeu.TestOnce = false;
            _boaeu.UpdatedBy = _bouserDetail.UserId;
            _boaeu.UpdatedDate = DateTime.UtcNow;
            _boaeu.Event = "UpdateByUser";
            _baaeu.IUD(_boaeu);
        }
    }
   
}