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
                            <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
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
                                    <asp:LinkButton ID="lnkbtnmodify" runat="server" CommandArgument='<%#Eval("MerchantId") %>' OnClick="btnmodify_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');" CssClass="btn btn-primary">Modify</asp:LinkButton>
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
</asp:Content>
