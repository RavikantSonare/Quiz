<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebAdmin.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Admin Dashboard</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="topCategory">
            <asp:GridView ID="gvExamDetail" runat="server" AutoGenerateColumns="false" class="table" DataKeyNames="ExamCodeId" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                    <asp:BoundField HeaderText="Second Categroy" DataField="SecondCategoryName" />
                    <asp:BoundField HeaderText="Merchant Name" DataField="MerchantName" />
                    <asp:BoundField HeaderText="Level" DataField="MerchantLevel" />
                    <asp:TemplateField HeaderText="Active (Default is Active)">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnactive" runat="server" CommandArgument='<%#Eval("IsActive") %>' OnClick="lnkbtnactive_Click">  <%# (Boolean.Parse(Eval("IsActive").ToString())) ? "Active" : "Inactive" %></asp:LinkButton>
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
