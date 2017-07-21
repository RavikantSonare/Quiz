<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMerchantManageEdit.aspx.cs" Inherits="WebAdmin.AdminMerchantManageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnUpdate]').click(function () {
                if ($('[id$=txtEndDate]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select End Date");
                    $('[id$=txtEndDate]').css("border", "1px solid #FF0000");
                    $('[id$=txtEndDate]').focus(function () {
                        $('[id$=txtEndDate]').css("border", "1px solid #000000");
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Merchant Manage Edit Date</h2>
    <hr />
    <asp:Panel ID="pnlMerchant" runat="server">
        <div class="tab-content">
            <div class="tab-pane active" id="myUser">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Merchant Name:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMerchantName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <label for="" class="col-sm-3 control-label">UserName:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">TelePhone:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <label for="" class="col-sm-3 control-label">Merchant Level:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMerchantLevel" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Start Date:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" Enabled="false" TextMode="Date"></asp:TextBox>
                                </div>
                                <label for="" class="col-sm-3 control-label">End Date:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sucess" OnClick="btnUpdate_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <style type="text/css">
            .messagealert {
                width: 50%;
                position: fixed;
                top: 0px;
                z-index: 100000;
                padding: 0;
                font-size: 15px;
            }
        </style>
        <div class="messagealert" id="alert_container">
        </div>
    </asp:Panel>
</asp:Content>
