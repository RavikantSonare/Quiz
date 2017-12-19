<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantMyExams.aspx.cs" Inherits="WebMerchant.MerchantMyExams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hidecolumn {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Exams List</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="myExam">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-lg-3">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                </div>
                <div class="col-lg-12" style="height: 200px; overflow-y: scroll">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging" DataKeyNames="ExamCodeId">
                        <Columns>
                            <asp:TemplateField HeaderText="Review" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnReview" runat="server" PostBackUrl='<%# String.Format("~/MerchantMyExams.aspx?exid={0}", Eval("ExamCodeId"))%>'>Review</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdexamId" runat="server" Value='<%#Eval("ExamCodeId")%>' />
                                </ItemTemplate>

                                <HeaderStyle CssClass="hide"></HeaderStyle>

                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Exam Title" DataField="ExamTitle" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                            <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn" />
                            <asp:TemplateField HeaderText="Exam Simulator" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnGenerateExamSimulator" runat="server" CommandArgument='<%#Eval("ExamSimulator") %>' OnClick="lnkbtnGenerateExamSimulator_Click">Generate</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exam Simulator Demo" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnGenerateExamSimulatorDemo" runat="server" CommandArgument='<%#Eval("ExamSimulatorDemo") %>' OnClick="lnkbtnGenerateExamSimulatorDemo_Click">Generate</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Only Test Once" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnOnlyTestOnce" runat="server" CommandArgument='<%#Eval("OnlyTestOnce") %>' OnClick="lnkbtnOnlyTestOnce_Click"><%# (Boolean.Parse(Eval("OnlyTestOnce").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Print" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowprint" runat="server" CommandArgument='<%#Eval("AllowPrint") %>' OnClick="lnkbtnallowprint_Click"><%# (Boolean.Parse(Eval("AllowPrint").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Sales" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowsales" runat="server" OnClick="lnkbtnallowsales_Click" CommandArgument='<%#Eval("ExamCodeId")%>'><%# (Boolean.Parse(Eval("AllowSales").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Config">
                                <ItemTemplate>
                                    <asp:Button ID="btnExamConfig" runat="server" Text="Config" CssClass="btn btn-default" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Featured in selfs estore" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkfeatureestore" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnExamdelete" runat="server" Text="Delete" CssClass="btn btn-default" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row mtop30">
                <h4>Bundle Exam Promotion</h4>
                <div class="col-lg-12">
                    <asp:Panel ID="pnlbundle" runat="server">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="">Content:</label>
                                <asp:TextBox ID="txtContent" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">Price:</label>
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">Featured in selfs estore:</label>
                                <asp:CheckBox ID="chkfeatureestore" runat="server" />
                            </div>
                            <asp:Button ID="btnAddBundle" runat="server" Text="Add" class="btn btn-default" OnClick="btnAddBundle_Click" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-lg-6" style="height: 200px; overflow-y: scroll">
                    <asp:GridView ID="gridBundle" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" AllowPaging="True" DataKeyNames="BundleId">
                        <Columns>
                            <asp:BoundField HeaderText="Content" DataField="BundleContent" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnBundleEdit" runat="server" Text="Edit" CssClass="btn btn-default" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnBundleDelete" runat="server" Text="Delete" CssClass="btn btn-default" />
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
