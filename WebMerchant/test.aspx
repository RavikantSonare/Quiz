<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebMerchant.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/example.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Default Toolbar Config</h1>
        <p>
            This example simply shows the default toolbar config.
        </p>
        <rte:editor runat="server" id="Editor1" text="Type here" />
    </form>
</body>
</html>
