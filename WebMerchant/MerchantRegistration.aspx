<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegistration.aspx.cs" Inherits="WebMerchant.MerchantRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Merchant Registration</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/custom.css" rel="stylesheet">

    <!-- Login CSS -->
    <link href="css/login.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnRegistration]').click(function () {
                if ($('[id$=txtMerchantName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Merchant Name");
                    $('[id$=txtMerchantName]').css("border", "1px solid #FF0000");
                    $('[id$=txtMerchantName]').focus(function () {
                        $('[id$=txtMerchantName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtUserName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter UserName");
                    $('[id$=txtUserName]').css("border", "1px solid #FF0000");
                    $('[id$=txtUserName]').focus(function () {
                        $('[id$=txtUserName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
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
                //if ($('[id$=txtTelephone]').val() == "") {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Please Enter Telephone Number");
                //    $('[id$=txtTelephone]').css("border", "1px solid #FF0000");
                //    $('[id$=txtTelephone]').focus(function () {
                //        $('[id$=txtTelephone]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}
                //if (!ValidateMobile($('[id$=txtTelephone]').val())) {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Please Enter Valid Telephone Number");
                //    $('[id$=txtTelephone]').css("border", "1px solid #FF0000");
                //    $('[id$=txtTelephone]').focus(function () {
                //        $('[id$=txtTelephone]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}
                if ($('[id$=drpCountry]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Country");
                    $('[id$=drpCountry]').css("border", "1px solid #FF0000");
                    $('[id$=drpCountry]').focus(function () {
                        $('[id$=drpCountry]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=drpState]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select State");
                    $('[id$=drpState]').css("border", "1px solid #FF0000");
                    $('[id$=drpState]').focus(function () {
                        $('[id$=drpState]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=drpMerchantLevel]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Plan");
                    $('[id$=drpMerchantLevel]').css("border", "1px solid #FF0000");
                    $('[id$=drpMerchantLevel]').focus(function () {
                        $('[id$=drpMerchantLevel]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtAnnualFee]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Annual Fee");
                    $('[id$=txtAnnualFee]').css("border", "1px solid #FF0000");
                    $('[id$=txtAnnualFee]').focus(function () {
                        $('[id$=txtAnnualFee]').css("border", "1px solid #000000");
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
                if (!ValidatePassword($('[id$=txtPassword]').val())) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter minimum eight digit");
                    $('[id$=txtPassword]').css("border", "1px solid #FF0000");
                    $('[id$=txtPassword]').focus(function () {
                        $('[id$=txtPassword]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtConfirmPassword]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Confirm Password");
                    $('[id$=txtConfirmPassword]').css("border", "1px solid #FF0000");
                    $('[id$=txtConfirmPassword]').focus(function () {
                        $('[id$=txtConfirmPassword]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtConfirmPassword]').val() != $('[id$=txtPassword]').val()) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Password Does Not Match");
                    $('[id$=txtConfirmPassword]').css("border", "1px solid #FF0000");
                    $('[id$=txtConfirmPassword]').focus(function () {
                        $('[id$=txtConfirmPassword]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
            });

        });
        function ValidateEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };
        function ValidateMobile(mobile) {
            var expr = /^[1-9]{1}[0-9]{9}$/;
            return expr.test(mobile);
        };
        function ValidatePassword(password) {
            //var expr = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$/;
            var expr = /^.{8,}$/;
            return expr.test(password);
        };
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
                                    <h4>Registration</h4>
                                </div>
                            </div>
                            <hr>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="register-form" role="form" style="display: block;">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtMerchantName" runat="server" class="form-control" placeholder="Merchant Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="UserName"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtEmailId" runat="server" class="form-control" placeholder="Email Id"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control" placeholder="Telephone"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:DropDownList ID="drpCountry" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:DropDownList ID="drpState" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:DropDownList ID="drpMerchantLevel" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpMerchantLevel_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtAnnualFee" runat="server" class="form-control" placeholder="Annual Fee" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" class="form-control" placeholder="Confirm Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-12" style="text-align: center;">
                                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                                </div>
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="btnRegistration" runat="server" Text="Register Now" class="form-control btn btn-register" OnClick="btnRegistration_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="dnt_acnt">Already a Member?, <a href="Default.aspx">Log In Here</a></div>
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
