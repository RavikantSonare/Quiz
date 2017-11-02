using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;


namespace WebAdmin
{
    public partial class AdminQuestionType : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOQuestionType _boqtype = new BOQuestionType();
        private BAQuestionType _baqtype = new BAQuestionType();
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminDetail"] != null)
                {
                    BOAdminLogin _boadmin = (BOAdminLogin)Session["AdminDetail"];
                    adminId = _boadmin.AdminId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgridViewQuestionType();
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        private void FillgridViewQuestionType()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baqtype.SelectQuestionType("GETALL");
            gvQuestiobType.DataSource = _datatable1;
            gvQuestiobType.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(txtQuestionType.Text))
                    {
                        _boqtype.QuestionType = txtQuestionType.Text;
                        _boqtype.IsActive = true;
                        _boqtype.IsDelete = false;
                        _boqtype.CreatedBy = adminId;
                        _boqtype.CreatedDate = DateTime.UtcNow;
                        _boqtype.UpdateBy = adminId;
                        _boqtype.UpdateDate = DateTime.UtcNow;
                        if (ViewState["qtypeId"] != null)
                        {
                            _boqtype.QuestionTypeId = Convert.ToInt32(ViewState["qtypeId"]);
                            _boqtype.Event = "Update";
                            if (_baqtype.Update(_boqtype) == 2)
                            {
                                ShowMessage("Question type updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _boqtype.QuestionTypeId = 0;
                            _boqtype.Event = "Insert";
                            if (_baqtype.Insert(_boqtype) == 1)
                            {
                                ShowMessage("Question type added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter top question type";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            ClearControl();
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int qtypeId = Convert.ToInt32(gvQuestiobType.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable2 = new DataTable();
                _datatable2 = _baqtype.SelectQuestionTypeWithID("GetQtypewithId", qtypeId);
                if (_datatable2.Rows.Count > 0)
                {
                    ViewState["qtypeId"] = _datatable2.Rows[0]["QuestionTypeId"].ToString();
                    txtQuestionType.Text = _datatable2.Rows[0]["QuestionType"].ToString();
                    btnAdd.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int qtypeid = Convert.ToInt32(gvQuestiobType.DataKeys[gvrow.RowIndex].Value.ToString());
                    _boqtype.QuestionTypeId = qtypeid;
                    _boqtype.IsDelete = true;
                    _boqtype.CreatedBy = adminId;
                    _boqtype.CreatedDate = DateTime.UtcNow;
                    _boqtype.UpdateBy = adminId;
                    _boqtype.UpdateDate = DateTime.UtcNow;
                    _boqtype.Event = "Delete";
                    int rtnvalue = _baqtype.Delete(_boqtype);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Question type deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete question type because used in another entity", MessageType.Info);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            ClearControl();
        }

        private void ClearControl()
        {
            btnAdd.Text = "Add";
            ViewState["qtypeId"] = "";
            ViewState["qtypeId"] = null;
            FillgridViewQuestionType();
            Common.ClearControl(Panel1);
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}