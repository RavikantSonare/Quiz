<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPasswordChange.aspx.cs" Inherits="WebAdmin.AdminPasswordChange" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Change Password</h2>
    <hr />

    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="merchantLevel">
            <div class="row">
                <asp:Panel ID="Panel1" runat="server">
                    <form class="form-horizontal">
                        <div class="form-group row">
                            <label for="merchantlevel" class="control-label col-xs-2">UserName:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="merchantlevel" class="control-label col-xs-2">Password:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <label for="chkShowPassword">
                                    <input type="checkbox" id="chkShowPassword" />
                                    Show password</label>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Confirm Password:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-xs-offset-2 col-xs-10">
                                <asp:LinkButton ID="lnkbtnReset" runat="server" CssClass="btn btn-success" OnClick="lnkbtnReset_Click">Reset</asp:LinkButton>
                                <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                            </div>
                        </div>
                    </form>
                </asp:Panel>
            </div>
        </div>
    </div>
    <div id="modalPopUp" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <span id="spnTitle"></span>
                    </h4>
                </div>
                <div class="modal-body">
                    <p>
                        <span id="spnMsg"></span>.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                    <button type="button" id="btnConfirm" class="btn btn-danger">
                        Yes, please</button>
                </div>
            </div>
        </div>
    </div>
    <div class="messagealert" id="alert_container">
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#chkShowPassword").bind("click", function () {
                var txtPassword = $("[id*=txtPassword]");
                if ($(this).is(":checked")) {
                    txtPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPassword.attr("id") + '" type = "text" Class="form-control" value = "' + txtPassword.val() + '" />');
                    txtPassword.hide();
                } else {
                    txtPassword.val(txtPassword.next().val());
                    txtPassword.next().remove();
                    txtPassword.show();
                }
            });
        });
        function PasswordChanged(txt) {
            $(txt).prev().val($(txt).val());
        }
    </script>
</asp:Content>

