<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSalesReport.aspx.cs" Inherits="WebAdmin.AdminSalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
    <style>
        .hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sales Report</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="salesReport">
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-inline">
                        <div class="form-group">
                            <label for="exampleInputEmail2">Merchant Name:</label>
                            <asp:TextBox ID="txtmerchantName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSummary" runat="server" Text="Summary" OnClick="btnSummary_Click" class="btn btn-info" />
                        <span>$
                            <asp:Label ID="lblconfirmedamount" runat="server"></asp:Label></span>
                        <strong>($ is all confirmed order's amount)</strong>
                    </div>
                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable mtop">
                        <asp:GridView ID="gvSalesReport" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="OrderId" AllowPaging="True" OnPageIndexChanging="gvSalesReport_PageIndexChanging" PageSize="10">
                            <Columns>
                                <asp:BoundField HeaderText="Order No." DataField="OrderNo" />
                                <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                                <asp:BoundField HeaderText="Second Category" DataField="SecondCategoryName" />
                                <asp:BoundField HeaderText="Merchant Name" DataField="MerchantName" />
                                <asp:BoundField HeaderText="Price" DataField="Price" />
                                <asp:BoundField HeaderText="Fee Rate" DataField="MerchantFeeRate" />
                                <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" />
                                <asp:BoundField HeaderText="OrderStatus" DataField="OrderStatus" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:BoundField HeaderText="EmailId" DataField="EmailId" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:TemplateField HeaderText="Order Confirm">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnOrderconfirm" runat="server" CommandArgument='<%#Eval("OrderStatus") %>' OnClick="lnkbtnOrderconfirm_Click"><%# (Boolean.Parse(Eval("OrderStatus").ToString())) ? "Confirmed" : "Processing" %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email Notice">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSendMail" runat="server" Text="Send Email" class="btn btn-default" OnClick="btnSendMail_Click" />
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
</asp:Content>
