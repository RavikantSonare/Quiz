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
    public partial class AdminWithdrawOption : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOPaymentOption _bopopt = new BOPaymentOption();
        private BAPaymentOption _bapopt = new BAPaymentOption();
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
                        FillgridViewPaymentOption();
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

        private void FillgridViewPaymentOption()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bapopt.SelectPaymentOptionList("GETALL");
            gvPaymentOption.DataSource = _datatable1;
            gvPaymentOption.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(txtPaymentOption.Text))
                    {
                        _bopopt.PaymentOption = txtPaymentOption.Text;
                        _bopopt.IsActive = true;
                        _bopopt.IsDelete = false;
                        _bopopt.CreatedBy = adminId;
                        _bopopt.CreatedDate = DateTime.UtcNow;
                        _bopopt.UpdateBy = adminId;
                        _bopopt.UpdateDate = DateTime.UtcNow;
                        if (ViewState["poptId"] != null)
                        {
                            _bopopt.PaymentOptionId = Convert.ToInt32(ViewState["poptId"]);
                            _bopopt.Event = "Update";
                            if (_bapopt.Update(_bopopt) == 2)
                            {
                                ShowMessage("Payment option updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _bopopt.PaymentOptionId = 0;
                            _bopopt.Event = "Insert";
                            if (_bapopt.Insert(_bopopt) == 1)
                            {
                                ShowMessage("Payment option added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter payment option";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                    }
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
                int poptId = Convert.ToInt32(gvPaymentOption.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable2 = new DataTable();
                _datatable2 = _bapopt.SelectPaymentOptionWithID("GETPOptWithId", poptId);
                if (_datatable2.Rows.Count > 0)
                {
                    ViewState["poptId"] = _datatable2.Rows[0][0].ToString();
                    txtPaymentOption.Text = _datatable2.Rows[0][1].ToString();
                    lnkbtnAdd.Text = "Update";
                    lnkbtnAdd.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
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
                    int poptid = Convert.ToInt32(gvPaymentOption.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bopopt.PaymentOptionId = poptid;
                    _bopopt.IsDelete = true;
                    _bopopt.CreatedBy = adminId;
                    _bopopt.CreatedDate = DateTime.UtcNow;
                    _bopopt.UpdateBy = adminId;
                    _bopopt.UpdateDate = DateTime.UtcNow;
                    _bopopt.Event = "Delete";
                    int rtnvalue = _bapopt.Delete(_bopopt);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Payment Option deleted successfully", MessageType.Success);
                    }
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
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            ViewState["poptId"] = "";
            ViewState["poptId"] = null;
            Common.ClearControl(Panel1);
            FillgridViewPaymentOption();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}