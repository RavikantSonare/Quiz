using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebUser.BOLayer;
using WebUser.BALayer;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace WebUser
{
    public partial class UserLogin : System.Web.UI.Page
    {
        private DataTable _datatable;
        private int userId = default(int);
        public enum MessageType { Success, Error, Info, Warning };
        BAExamManage _baexmmng = new BAExamManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                    userId = _bouserDetail.UserId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgirdViewExamDetail(_bouserDetail.UserId);
                        FillgridViewExamReport(_bouserDetail.UserId);
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

        private void FillgirdViewExamDetail(int uid)
        {
            _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetail("GetExWithUid", txtSearch.Text, uid);
            gvExamDetail.DataSource = _datatable;
            gvExamDetail.DataBind();
        }

        private void FillgridViewExamReport(int uid)
        {
            BAExamReports _baexmrpt = new BALayer.BAExamReports();
            _datatable = new DataTable();
            _datatable = _baexmrpt.SelectExamReport("GetExRptWithUid", uid);
            gvExamReport.DataSource = _datatable;
            gvExamReport.DataBind();
        }

        protected void btnTestMode_Click(object sender, EventArgs e)
        {
            //string fileName = string.Empty;
            //Button btntest = (Button)sender;
            //string val = btntest.CommandArgument;
            //if (btntest.CommandArgument == "300-120")
            //{
            //    fileName = "Cisco-300-120.docx";
            //}
            //else if (btntest.CommandArgument == "302-120")
            //{
            //    fileName = "Cisco-302-120.docx";// Replace Your Filename with your required filename
            //}
            //else
            //{
            //    fileName = "Cisco-Math.docx";
            //}

            //Response.ContentType = "application/octet-stream";

            //Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);

            //Response.TransmitFile(Server.MapPath("~/ExamSimulator/" + fileName));//Place "YourFolder" your server folder Here

            //Response.End();

            Button btntest = (Button)sender;
            string val = HttpUtility.UrlEncode(Common.Encrypt(btntest.CommandArgument.Trim()));
            Response.Redirect("~/OnlineTestBegin.aspx?exmid=" + val + "&tstmd=TM");
        }

        protected void btnStudyNow_Click(object sender, EventArgs e)
        {
            Button btntest = (Button)sender;
            string val = HttpUtility.UrlEncode(Common.Encrypt(btntest.CommandArgument.Trim()));
            Response.Redirect("~/OnlineTestBegin.aspx?exmid=" + val + "&tstmd=SM");
        }

        protected void btnTestOnce_Click(object sender, EventArgs e)
        {
            Button btntest = (Button)sender;
            string val = HttpUtility.UrlEncode(Common.Encrypt(btntest.CommandArgument.Trim()));
            Response.Redirect("~/OnlineTestBegin.aspx?exmid=" + val + "&tstmd=TO");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Button btntest = (Button)sender;
            var list = _baexmmng.SelectExamQestionAnswerbase64("GetEQAWithQId", Convert.ToInt32(btntest.CommandArgument.Trim()));
            string strserialize = JsonConvert.SerializeObject(list);
            string path = Server.MapPath("~/ExamSimulator/");
            string filename = list.ExamCode + ".json";
            System.IO.File.WriteAllText(path + list.ExamCode + ".json", strserialize);



            //Get the Input File Name and Extension.
            string fileName = Path.GetFileNameWithoutExtension(filename);
            string fileExtension = Path.GetExtension(filename);

            //Build the File Path for the original (input) and the encrypted (output) file.
            string input = Server.MapPath("~/ExamSimulator/") + fileName + fileExtension;
            string output = Server.MapPath("~/ExamSimulator/") + fileName + ".vcee";

            //Save the Input File, Encrypt it and save the encrypted file in output path.
            // this.Encrypt(input, output);

            //Download the Encrypted File.
            Response.ContentType = "application/octet-stream";
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(input));
            Response.WriteFile(input);
            Response.Flush();

            //Delete the original (input) and the encrypted (output) file.
            File.Delete(input);
            File.Delete(output);

            Response.End();


            //Response.ContentType = "application/octet-stream";

            //Response.AddHeader("Content-Disposition", "attachment;filename=" + list.ExamCode + ".huizhou");

            //Response.TransmitFile(Server.MapPath("~/ExamSimulator/" + list.ExamCode + ".huizhou"));//Place "YourFolder" your server folder Here

            //Response.End();
            // System.IO.File.WriteAllText(path + list.ExamCode + ".huizhou", strserialize);
            //using (var file = new StreamWriter(@"D:\Work\Project\WebUser\test.json", false))
            //{
            //    file.Write(strserialize);
            //    file.Close();
            //    file.Dispose();
            //}
        }

        private void Encrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "PROJECTQUIZMW238";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                        {
                            int data;
                            while ((data = fsInput.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetail("GetExWithUid", txtSearch.Text, userId);
            gvExamDetail.DataSource = _datatable;
            gvExamDetail.DataBind();
        }

        protected void gvExamDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    HiddenField hdacopt = (HiddenField)e.Row.FindControl("hdaccesoption");
            //    HiddenField hdoto = (HiddenField)e.Row.FindControl("hdoto");
            //    Button btnTestonce = (Button)e.Row.FindControl("btnTestOnce");
            //    string[] val = (hdacopt.Value).Split(',');
            //    foreach (var item in val)
            //    {
            //        if (item == "4")
            //        {
            //            if (Convert.ToBoolean(hdoto.Value))
            //            {
            //                btnTestonce.Visible = true;
            //            }
            //        }
            //    }
            //}
        }
    }
}