<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantSalesReports.aspx.cs" Inherits="WebMerchant.MerchantSalesReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sales Reports</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="salesReport">
            <div class="row">
                <div class="salseReport">
                    <asp:GridView ID="gvSalesReports" runat="server" AutoGenerateColumns="false" class="table" ShowFooter="true" AllowPaging="True" OnPageIndexChanging="gvSalesReports_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="OrderId" DataField="OrderId" Visible="false" />
                            <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" Visible="false" />
                            <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="ExamCode" DataField="ExamCode" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <%# (Boolean.Parse(Eval("OrderStatus").ToString())) ? "Confirmed" : "Processing" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblprice" runat="server" Text=' <%# string.Format("{0}{1}", "$",Eval("Price"))%>' DataFormatString="{0:N2}"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FeeRate">
                                <ItemTemplate>
                                    <%# string.Format("{0}{1}", Eval("MerchantFeeRate") ,"%")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NetAmount">
                                <ItemTemplate>
                                    <asp:Label ID="lblNetAmount" runat="server" Text=' <%# string.Format("{0}{1}", "$",Eval("NetAmount"))%>' DataFormatString="{0:N2}"></asp:Label>
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
    <div class="col-lg-12">
        <textarea name="text" class="summernote" id="contents" title="Contents" runat="server"></textarea>
    </div>
</asp:Content>
