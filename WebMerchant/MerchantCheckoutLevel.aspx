<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantCheckoutLevel.aspx.cs" Inherits="WebMerchant.MerchantCheckoutLevel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Merchant Registration</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/custom.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mtop30">
                <asp:DataList ID="dlpricetable" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow" DataKeyField="MerchantLevelId">
                    <ItemTemplate>
                        <div class="col-xs-12 col-md-3">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><%#Eval("MerchantLevel")%></h3>
                                </div>
                                <div class="panel-body">
                                    <div class="the-price">
                                        <h1>$<%#Eval("AnnualFee") %><span class="subscript">/yr</span></h1>
                                    </div>
                                    <table class="table">
                                        <tr>
                                            <td><%#Eval("ExamCount") %> Exam Count
                                            </td>
                                        </tr>
                                        <tr class="active">
                                            <td><%#Eval("StudentCount") %> Student Count
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>100K Demo
                                            </td>
                                        </tr>
                                        <tr class="active">
                                            <td>100MB Demo
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Demo
                                            </td>
                                        </tr>
                                        <tr class="active">
                                            <td>Demo
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="panel-footer">
                                    <asp:Button ID="btncheckout" Text="Checkout" runat="server" CssClass="btn btn-success" CommandArgument='<%#Eval("AnnualFee") %>' ToolTip='<%#Eval("MerchantLevel") %>' OnClick="btncheckout_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <%--  <div class="col-xs-12 col-md-3">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Bronze</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$10<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>1 Account
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>1 Project
                            </td>
                                </tr>
                                <tr>
                                    <td>100K API Access
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>100MB Storage
                            </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                            </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="http://www.jquery2dotnet.com" class="btn btn-success" role="button">Sign Up</a>
                            1 month FREE trial
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-3">
                    <div class="panel panel-success">
                        <div class="cnrflash">
                            <div class="cnrflash-inner">
                                <span class="cnrflash-label">MOST
                           
                                    <br>
                                    POPULR</span>
                            </div>
                        </div>
                        <div class="panel-heading">
                            <h3 class="panel-title">Silver</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$20<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>2 Account
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>5 Project
                            </td>
                                </tr>
                                <tr>
                                    <td>100K API Access
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>200MB Storage
                            </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                            </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="http://www.jquery2dotnet.com" class="btn btn-success" role="button">Sign Up</a>
                            1 month FREE trial
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-3">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Gold</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$35<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>5 Account
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>20 Project
                            </td>
                                </tr>
                                <tr>
                                    <td>300K API Access
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>500MB Storage
                            </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                            </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                            </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="http://www.jquery2dotnet.com" class="btn btn-success" role="button">Sign Up</a> 1 month FREE trial
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <div class="messagealert" id="alert_container">
        </div>
    </form>
</body>
</html>
