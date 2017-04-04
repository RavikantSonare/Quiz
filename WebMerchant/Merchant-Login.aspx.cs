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
    public partial class Merchant_Login : System.Web.UI.Page
    {
        private DataTable _datatable;
        private BAMerchantManage _bamermng = new BAMerchantManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    FilgirdViewMerchantDetail("GETWITHID", _bomerchantDetail.MerchantId);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private void FilgirdViewMerchantDetail(string eventtxt, int merchantid)
        {
            _datatable = new DataTable();
            _datatable = _bamermng.SelectMerchantDetail(eventtxt, merchantid);
            if (_datatable.Rows.Count > 0)
            {
                gvMerchantDetail.DataSource = _datatable;
                gvMerchantDetail.DataBind();
            }
        }

        private void FilldropDowntopCategory()
        {
            BATopCategory _batopcat = new BATopCategory();
            _datatable = _batopcat.SelectTopCategoryList("GETALL");
            if (_datatable.Rows.Count > 0)
            {
                drpTopcategory.DataSource = _datatable;
                drpTopcategory.DataTextField = "TopCategoryName";
                drpTopcategory.DataValueField = "TopCategoryID";
            }
        }
    }
}