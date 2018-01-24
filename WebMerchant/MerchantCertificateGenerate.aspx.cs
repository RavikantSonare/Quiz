using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantCertificateGenerate : System.Web.UI.Page
    {
        private BOMerchantCertificate _bomercertfict = new BOMerchantCertificate();
        private BAMerchantCertificate _bamercertfict = new BAMerchantCertificate();

        private BOExamReports _boexmrpt = new BOExamReports();
        private BAExamReports _baexmrpt = new BAExamReports();

        private int MerchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Imagewatermark("img_20180124142911197.png");
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    MerchantId = _bomerchantDetail.MerchantId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        if (Request.QueryString["exmrptid"].ToString() != null && Request.QueryString["name"].ToString() != null && Request.QueryString["crtficid"].ToString() != null)
                        {
                            string concat = Request.QueryString["exmrptid"].ToString();
                            concat += " " + Request.QueryString["name"].ToString();
                            concat += " " + Request.QueryString["crtficid"].ToString();
                            int rptid = Convert.ToInt32(Request.QueryString["exmrptid"]);
                            int certid = Convert.ToInt32(Request.QueryString["crtficid"].ToString());

                            DataTable _datatable2 = new DataTable();
                            _datatable2 = _baexmrpt.SelectExamreport("GetExamRptID", rptid);

                            DataTable _datatable3 = new DataTable();
                            _datatable3 = _bamercertfict.SelectCertifcateDetailWithID("GetCertificateWithCId", certid);

                            imgcertificate.ImageUrl = "~/TemplateImage/" + _datatable3.Rows[0]["CertificatePic"].ToString();
                           // Imagewatermark("img_20180124142911197.png");
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
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        internal void Imagewatermark(string imagename)
        {
            string filePath = string.Empty;
            filePath = HostingEnvironment.MapPath("~/TemplateImage/");
            Bitmap bmp1 = (Bitmap)System.Drawing.Image.FromFile(filePath + imagename);
            string watermarkText = "Quiz Manage";
            using (Bitmap bmp = new Bitmap(System.Drawing.Image.FromFile(filePath + imagename)))
            {
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    //Set the Color of the Watermark text.
                    Brush brush = new SolidBrush(Color.Black);

                    //Set the Font and its size.
                    Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                    //Determine the size of the Watermark text.
                    SizeF textSize = new SizeF();
                    textSize = grp.MeasureString(watermarkText, font);

                    //Position the text and draw it on the image.
                    //Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                    Point position = new Point(149, 162);
                    grp.DrawString(watermarkText, font, brush, position);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Watermarked image to the MemoryStream.
                        bmp.Save(memoryStream, ImageFormat.Png);
                        memoryStream.Position = 0;

                        //Start file download.
                        Response.Clear();
                        Response.ContentType = "image/png";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + imagename);

                        //Write the MemoryStream to the Response.
                        memoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                    }
                }
            }
        }
    }
}