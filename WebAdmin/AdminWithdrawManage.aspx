<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminWithdrawManage.aspx.cs" Inherits="WebAdmin.AdminWithdrawManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Withdraw Manage</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="withdrawManager">
            <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
            <asp:GridView ID="gvWithdrawManage" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="WithDrawOrderId" AllowPaging="True" OnPageIndexChanging="gvWithdrawManage_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="WithDraw Order No." DataField="WithDrawOrderNo" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" />
                    <asp:BoundField HeaderText="Merchant Name" DataField="MerchantName" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                    <asp:BoundField HeaderText="OrderStatus" DataField="OrderStatus" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                    <asp:BoundField HeaderText="Email Id" DataField="Emailid" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                    <asp:TemplateField HeaderText="Merchant Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnMerchantName" runat="server" CommandArgument='<%#Eval("MerchantId")%>' OnClick="lnkbtnMerchantName_Click"><%#Eval("MerchantName")%></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Confirm">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnOrderconfirm" runat="server" CommandArgument='<%#Eval("OrderStatus") %>' OnClick="lnkbtnOrderconfirm_Click"><%# (Boolean.Parse(Eval("OrderStatus").ToString())) ? "Confirmed" : "Processing" %></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Notice">
                        <ItemTemplate>
                            <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" class="btn btn-default" OnClick="btnSendEmail_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <h2>Record not found...</h2>
                </EmptyDataTemplate>
            </asp:GridView>
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
