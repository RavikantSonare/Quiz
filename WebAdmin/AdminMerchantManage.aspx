<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMerchantManage.aspx.cs" Inherits="WebAdmin.AdminMerchantManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Merchant Manage</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="merchantManager">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvMerchantManage" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="MerchantId" OnRowDataBound="gvMerchantManage_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvMerchantManage_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Merchant Name" DataField="MerchantName" />
                            <asp:BoundField HeaderText="Country" DataField="Country" />
                            <asp:BoundField HeaderText="Province/State" DataField="State" />
                            <asp:BoundField HeaderText="Mobile No." DataField="Telephone" />
                            <asp:BoundField HeaderText="Level" DataField="MerchantLevel" />
                            <asp:TemplateField HeaderText="Valid Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblvaliddate" runat="server"><%# Eval("StartDate", "{0:dd/M/yyyy}")%>-<%# Eval("EndDate", "{0:dd/M/yyyy}")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active(Default is Actived)">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdactive" runat="server" Value='<%#Eval("ActiveStatus") %>' />
                                    <asp:LinkButton ID="lnkbtnactive" runat="server" CommandArgument='<%#Eval("ActiveStatus") %>' OnClick="lnkbtnactive_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnmodify" runat="server" Text="Modify" CssClass="btn btn-primary" CommandArgument='<%#Eval("MerchantId") %>' OnClick="btnmodify_Click" />
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
