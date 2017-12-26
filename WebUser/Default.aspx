<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUser.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/custom.css" rel="stylesheet">

    <!-- Login CSS -->
    <link href="css/login.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnLogin]').click(function () {
                if ($('[id$=txtEmailId]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Email Id");
                    $('[id$=txtEmailId]').css("border", "1px solid #FF0000");
                    $('[id$=txtEmailId]').focus(function () {
                        $('[id$=txtEmailId]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if (!ValidateEmail($('[id$=txtEmailId]').val())) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Valid Email Id");
                    $('[id$=txtEmailId]').css("border", "1px solid #FF0000");
                    $('[id$=txtEmailId]').focus(function () {
                        $('[id$=txtEmailId]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtPassword]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Password");
                    $('[id$=txtPassword]').css("border", "1px solid #FF0000");
                    $('[id$=txtPassword]').focus(function () {
                        $('[id$=txtPassword]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

            });

        });
        function CheckFirstChar(key, txt) {
            if (key == 32 && txt.value.length <= 0) {
                return false;
            }
            else if (txt.value.length > 0) {
                if (txt.value.charCodeAt(0) == 32) {
                    txt.value = txt.value.substring(1, txt.value.length);
                    return true;
                }
            }
            return true;
        }
        function ValidateEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Login</h4>
                                </div>
                            </div>
                            <hr>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="login-form" role="form" style="display: block;">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtEmailId" runat="server" class="form-control" placeholder="Email Id" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-12" style="text-align: center;">
                                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                                </div>
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="btnLogin" runat="server" Text="Log In" class="form-control btn btn-login" OnClick="btnLogin_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
