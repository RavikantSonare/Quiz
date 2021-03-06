﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantDashboard.aspx.cs" Inherits="WebMerchant.MerchantDashboard" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnUpdate]').click(function (e) {
                var focusSet = false; if ($('[id$=txtMerchantName]').val() == "") {
                    $('[id$=txtMerchantName]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtMerchantName]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtMerchantName]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter merchant name</div>");
                    }
                    $('[id$=txtMerchantName]').focus(function () {
                        $('[id$=txtMerchantName]').css("border", "1px solid #000000");
                    });
                    e.preventDefault(); // prevent form from POST to server
                    focusSet = true;
                } else {
                    $('[id$=txtMerchantName]').parent().next(".validation").remove(); // remove it
                }
                //if ($('[id$=txtTelephone]').val() == "") {
                //    $('[id$=txtTelephone]').css("border", "1px solid #FF0000");
                //    if ($('[id$=txtTelephone]').parent().next(".validation").length == 0) // only add if not added
                //    {
                //        $('[id$=txtTelephone]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter mobile no.</div>");
                //    }
                //    $('[id$=txtTelephone]').focus(function () {
                //        $('[id$=txtTelephone]').css("border", "1px solid #000000");
                //    });
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //} else {
                //    $('[id$=txtTelephone]').parent().next(".validation").remove(); // remove it
                //    $('[id$=txtTelephone]').keydown(function (e) {
                //        if (e.shiftKey || e.ctrlKey || e.altKey) {
                //            e.preventDefault();
                //        } else {
                //            var key = e.keyCode;
                //            if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                //                e.preventDefault();
                //            }
                //        }
                //    });
                //}
                if ($('[id$=txtEmailId]').val() == "") {
                    $('[id$=txtEmailId]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtEmailId]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtEmailId]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter email id</div>");
                    }
                    $('[id$=txtEmailId]').focus(function () {
                        $('[id$=txtEmailId]').css("border", "1px solid #000000");
                    });
                    e.preventDefault(); // prevent form from POST to server
                    focusSet = true;
                } else {
                    $('[id$=txtEmailId]').parent().next(".validation").remove(); // remove it
                    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!regex.test($('[id$=txtEmailId]').val())) {
                        if ($('[id$=txtEmailId]').parent().next(".validation").length == 0) // only add if not added
                        {
                            $('[id$=txtEmailId]').css("border", "1px solid #FF0000");
                            $('[id$=txtEmailId]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter valid email id</div>");
                        }
                        e.preventDefault(); // prevent form from POST to server
                        focusSet = true;
                    }
                }
                if ($('[id$=txtpassword]').val() == "") {
                    $('[id$=txtpassword]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtpassword]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtpassword]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter password</div>");
                    }
                    $('[id$=txtpassword]').focus(function () {
                        $('[id$=txtpassword]').css("border", "1px solid #000000");
                    });
                    e.preventDefault(); // prevent form from POST to server
                    focusSet = true;
                } else {
                    $('[id$=txtpassword]').parent().next(".validation").remove(); // remove it
                }
                //if ($('[id$=drpMerchantLevel]').val() == null) {
                //    $('[id$=drpMerchantLevel]').css("border", "1px solid #FF0000");
                //    if ($('[id$=drpMerchantLevel]').parent().next(".validation").length == 0) // only add if not added
                //    {
                //        $('[id$=drpMerchantLevel]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please select merchant level</div>");
                //    }
                //    $('[id$=drpMerchantLevel]').focus(function () {
                //        $('[id$=drpMerchantLevel]').css("border", "1px solid #000000");
                //    });
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //} else {
                //    $('[id$=drpMerchantLevel]').parent().next(".validation").remove(); // remove it
                //}
                //if ($('[id$=ddlActiveStatus]').val() == null) {
                //    $('[id$=ddlActiveStatus]').css("border", "1px solid #FF0000");
                //    if ($('[id$=ddlActiveStatus]').parent().next(".validation").length == 0) // only add if not added
                //    {
                //        $('[id$=ddlActiveStatus]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please select status</div>");
                //    }
                //    $('[id$=ddlActiveStatus]').focus(function () {
                //        $('[id$=ddlActiveStatus]').css("border", "1px solid #000000");
                //    });
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //} else {
                //    $('[id$=ddlActiveStatus]').parent().next(".validation").remove(); // remove it
                //}
                //if ($('[id$=txtStartDate]').val() == "") {
                //    $('[id$=txtStartDate]').css("border", "1px solid #FF0000");
                //    if ($('[id$=txtStartDate]').parent().next(".validation").length == 0) // only add if not added
                //    {
                //        $('[id$=txtStartDate]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter start date</div>");
                //    }
                //    $('[id$=txtStartDate]').focus(function () {
                //        $('[id$=txtStartDate]').css("border", "1px solid #000000");
                //    });
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //} else {
                //    $('[id$=txtStartDate]').parent().next(".validation").remove(); // remove it
                //}
                //if ($('[id$=txtEndDate]').val() == "") {
                //    $('[id$=txtEndDate]').css("border", "1px solid #FF0000");
                //    if ($('[id$=txtEndDate]').parent().next(".validation").length == 0) // only add if not added
                //    {
                //        $('[id$=txtEndDate]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter end date</div>");
                //    }
                //    $('[id$=txtEndDate]').focus(function () {
                //        $('[id$=txtEndDate]').css("border", "1px solid #000000");
                //    });
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //} else {
                //    $('[id$=txtEndDate]').parent().next(".validation").remove(); // remove it
                //}
                //var StartDate = $('[id$=txtStartDate]').val();
                //var EndDate = $('[id$=txtEndDate]').val();
                //var eDate = new Date(EndDate);
                //var sDate = new Date(StartDate);
                //if (StartDate != '' && StartDate != '' && sDate > eDate) {
                //    $('[id$=txtEndDate]').css("border", "1px solid #FF0000");
                //    $('[id$=txtEndDate]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please ensure that the End Date is greater than or equal to the Start Date.</div>");
                //    e.preventDefault(); // prevent form from POST to server
                //    focusSet = true;
                //}
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
    <h2>Merchant Dashboard</h2>
    <hr />
    <asp:Panel ID="pnlMerchant" runat="server">
        <form class="form-horizontal">
            <div class="form-group row">
                <label for="merchantlevel" class="control-label col-xs-2">Merchant Name:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtMerchantName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Email Id:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="userName" class="control-label col-xs-2">User Name:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Password:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Merchant Level:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtMerchantLevel" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Valid Time:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtValidDate" runat="server" CssClass="form-control" ReadOnly="true" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Location:</label>
                <div class="col-xs-5 row paddingrightzero">
                    <div class="col-xs-6">
                        <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-xs-6 paddingleftrightzero">
                        <asp:DropDownList ID="drpState" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Tel:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Brand:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">Merchant Picture:</label>
                <div class="col-xs-5">
                    <asp:FileUpload ID="fuMerchantPicture" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblPicture" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword" class="control-label col-xs-2">About Merchant:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtAboutMerchant" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-xs-offset-2 col-xs-10">
                    <asp:LinkButton ID="lnkbtnUpdate" runat="server" CssClass="btn btn-default" OnClick="btnUpdate_Click">Update</asp:LinkButton>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" Visible="false" />
                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                </div>
            </div>
        </form>
        <div class="messagealert" id="alert_container">
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
    </asp:Panel>
</asp:Content>
