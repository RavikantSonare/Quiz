using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantSalesReports : System.Web.UI.Page
    {
        private BOSalesReports _boslsrprt = new BOSalesReports();
        private BASalesReports _baslsrprt = new BASalesReports();
        private int MerchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    MerchantId = _bomerchantDetail.MerchantId;
                    if (!IsPostBack)
                    {
                        FillgridViewSalesReports(MerchantId);
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

        private void FillgridViewSalesReports(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baslsrprt.SelectSalesReprotsWithMrid("GetReportWithMrID", mid);
            if (_datatable1.Rows.Count > 0)
            {
                gvSalesReports.DataSource = _datatable1;
                gvSalesReports.DataBind();
                //Calculate Sum and display in Footer Row
                decimal total = _datatable1.AsEnumerable().Where(row => row.Field<bool>("OrderStatus") == true).Sum(row => row.Field<decimal>("Price"));
                decimal NetAmount = _datatable1.AsEnumerable().Where(row => row.Field<bool>("OrderStatus") == true).Sum(row => row.Field<decimal>("NetAmount"));
                gvSalesReports.FooterRow.Cells[5].Text = "Total";
                gvSalesReports.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                gvSalesReports.FooterRow.Cells[6].Text = "$" + total.ToString("N2");
                gvSalesReports.FooterRow.Cells[8].Text = "$" + NetAmount.ToString("N2");
            }
            else
            {
                gvSalesReports.DataSource = _datatable1;
                gvSalesReports.DataBind();
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvSalesReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesReports.PageIndex = e.NewPageIndex;
            FillgridViewSalesReports(MerchantId);
        }
    }
}