<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="samples_Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../ckeditor.js"></script>
    <script src="js/sample.js"></script>
    <link rel="stylesheet" href="css/samples.css">
    <link rel="stylesheet" href="toolbarconfigurator/lib/codemirror/neo.css">
</head>
<body>
    <form id="form1" runat="server">
        <%-- <div>
            <asp:TextBox ID="editor" runat="server"></asp:TextBox>
            <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click" />
        </div>
        <div id="divhtml" runat="server">
        </div>--%>

        <asp:Label ID="Label1" Text="CK Editor Sample" runat="server"></asp:Label>
        <br />
        <textarea runat="server" placeholder="Haber metnini girin." name="editor1" style="height: 700px" id="editor1" rows="10" cols="80">
            </textarea>
        <script type="text/javascript">
            // Replace the <textarea id="editor1"> with a CKEditor
            // instance, using default configuration.
            // CKEDITOR.replace('BodyContent_editor1');
            CKEDITOR.replace('<%=editor1.ClientID %>',
{
    //filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
    //filebrowserImageBrowseUrl: './Upload.ashx/',
    //filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?Type=Flash',
    //filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    //filebrowserImageUploadUrl: './Upload.ashx',
    //filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
});
        </script>
        <asp:Button runat="server" Text="Show Text" ID="show_text" OnClick="show_text_Click" />
        <asp:Label ID="lblNewsLong" runat="server"></asp:Label>

    </form>
    <script>
        initSample();
    </script>
</body>
</html>
