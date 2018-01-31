<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;

public class Upload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        HttpPostedFile uploads = context.Request.Files["upload"];
        string CKEditorFuncNum = context.Request["CKEditorFuncNum"];

        string file = FileUploadAppendTimeStamp(uploads);// System.IO.Path.GetFileName(uploads.FileName);

        uploads.SaveAs(context.Server.MapPath(".") + "\\resource\\" + file);

        //provide direct URL here
        string url = "http://localhost:60956/resource/" + file;

        context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public string FileUploadAppendTimeStamp(HttpPostedFile fu)
    {
        if (fu != null)
        {
            string filename = string.Empty;
            filename = string.Concat(
            System.IO.Path.GetFileNameWithoutExtension(fu.FileName),
            DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            System.IO.Path.GetExtension(fu.FileName)
            );

            return filename;
        }
        else { return ""; }
    }

}