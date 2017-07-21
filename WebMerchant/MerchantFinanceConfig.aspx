<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantFinanceConfig.aspx.cs" Inherits="WebMerchant.MerchantFinanceConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=drpPaymentOption]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Payment Option");
                    $('[id$=drpPaymentOption]').css("border", "1px solid #FF0000");
                    $('[id$=drpPaymentOption]').focus(function () {
                        $('[id$=drpPaymentOption]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtAccountEmail]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Email Address");
                    $('[id$=txtAccountEmail]').css("border", "1px solid #FF0000");
                    $('[id$=txtAccountEmail]').focus(function () {
                        $('[id$=txtAccountEmail]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtAccountEmail]').val() != "") {
                    var regex = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
                    if (!regex.test($('[id$=txtAccountEmail]').val())) {
                        $('[id$=lblerror]').css("display", "block");
                        $('[id$=lblerror]').html("Email address not valid");
                        $('[id$=txtAccountEmail]').css("border", "1px solid #FF0000");
                        $('[id$=txtAccountEmail]').focus(function () {
                            $('[id$=txtAccountEmail]').css("border", "1px solid #000000");
                            $('[id$=lblerror]').css("display", "none");
                        });
                        return false;
                    }
                }
                if ($('[id$=txtFirstName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter First Name");
                    $('[id$=txtFirstName]').css("border", "1px solid #FF0000");
                    $('[id$=txtFirstName]').focus(function () {
                        $('[id$=txtFirstName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtFirstName]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtFirstName]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtFirstName]').css("border", "1px solid #FF0000");
                //        $('[id$=txtFirstName]').focus(function () {
                //            $('[id$=txtFirstName]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
                if ($('[id$=txtLastName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Last Name");
                    $('[id$=txtLastName]').css("border", "1px solid #FF0000");
                    $('[id$=txtLastName]').focus(function () {
                        $('[id$=txtLastName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtLastName]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtLastName]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtLastName]').css("border", "1px solid #FF0000");
                //        $('[id$=txtLastName]').focus(function () {
                //            $('[id$=txtLastName]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
                if ($('[id$=txtCountry]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Country");
                    $('[id$=txtCountry]').css("border", "1px solid #FF0000");
                    $('[id$=txtCountry]').focus(function () {
                        $('[id$=txtCountry]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtCountry]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtCountry]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtCountry]').css("border", "1px solid #FF0000");
                //        $('[id$=txtCountry]').focus(function () {
                //            $('[id$=txtCountry]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
                if ($('[id$=txtCity]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter City");
                    $('[id$=txtCity]').css("border", "1px solid #FF0000");
                    $('[id$=txtCity]').focus(function () {
                        $('[id$=txtCity]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtCity]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtCity]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtCity]').css("border", "1px solid #FF0000");
                //        $('[id$=txtCity]').focus(function () {
                //            $('[id$=txtCity]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
                if ($('[id$=txtBankName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Bank Name");
                    $('[id$=txtBankName]').css("border", "1px solid #FF0000");
                    $('[id$=txtBankName]').focus(function () {
                        $('[id$=txtBankName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtBankName]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtBankName]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtBankName]').css("border", "1px solid #FF0000");
                //        $('[id$=txtBankName]').focus(function () {
                //            $('[id$=txtBankName]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
                if ($('[id$=txtSwiftCode]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Swift Code");
                    $('[id$=txtSwiftCode]').css("border", "1px solid #FF0000");
                    $('[id$=txtSwiftCode]').focus(function () {
                        $('[id$=txtSwiftCode]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtSwiftCode]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtSwiftCode]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtSwiftCode]').css("border", "1px solid #FF0000");
                //        $('[id$=txtSwiftCode]').focus(function () {
                //            $('[id$=txtSwiftCode]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
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
    <h2>Finance Config</h2>
    <hr />
    <asp:Panel ID="Panel1" runat="server">
        <div class="tab-content">
            <div class="tab-pane active mtop30" id="financeConfig">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Payment Receive Option:</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="drpPaymentOption" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpPaymentOption_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                            </div>
                            <asp:Panel ID="pnlPaypal" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="" class="col-sm-3 control-label">Account Email:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtAccountEmail" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlWireTransfer" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="" class="col-sm-3 control-label">First Name:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                    <label for="" class="col-sm-3 control-label">Last Name:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLastName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="" class="col-sm-3 control-label">Country:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtCountry" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                    <label for="" class="col-sm-3 control-label">City:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtCity" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="" class="col-sm-3 control-label">Bank Of Name:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtBankName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                    <label for="" class="col-sm-3 control-label">Swift Code:</label>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtSwiftCode" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                                <div class="col-sm-offset-3 col-sm-3">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-default" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-default" OnClick="btnReset_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    Your Currently payment receive option:
                                </div>
                                <div class="col-sm-12 mtop30">
                                    <asp:GridView ID="gvPaymentDetail" GridLines="None" AutoGenerateColumns="false" runat="server" Width="50%" AllowPaging="True" OnPageIndexChanging="gvPaymentDetail_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField HeaderText="Payment Option" DataField="PaymentOption" />
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("FinanceConfigId")%>' OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <h2>Record not found...</h2>
                                        </EmptyDataTemplate>
                                    </asp:GridView>

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
