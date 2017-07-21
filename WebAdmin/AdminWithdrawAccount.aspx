<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminWithdrawAccount.aspx.cs" Inherits="WebAdmin.AdminWithdrawAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Withdraw Account Detail</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="withdrawAccount">
            <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
            <asp:GridView ID="gvWithdrawAccont" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="FinanceConfigId">
                <Columns>
                    <asp:BoundField HeaderText="Finance Config  Id" DataField="FinanceConfigId" />
                    <asp:BoundField HeaderText="PaymentOption" DataField="PaymentOption" />
                    <asp:BoundField HeaderText="Account Email" DataField="AccountEmail" />
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                    <asp:BoundField HeaderText="Country" DataField="Country" />
                    <asp:BoundField HeaderText="City" DataField="City" />
                    <asp:BoundField HeaderText="Bank Name" DataField="BankOfName" />
                    <asp:BoundField HeaderText="Swift Code" DataField="SwiftCode" />
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
