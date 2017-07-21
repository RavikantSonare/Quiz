<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantMyExams.aspx.cs" Inherits="WebMerchant.MerchantMyExams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Exams</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="myExam">
            <div class="row">
                <asp:GridView ID="gvExamDetail" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging" DataKeyNames="ExamCodeId">
                    <Columns>
                        <asp:TemplateField HeaderText="Review">
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
                        <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                        <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                        <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" />
                        <asp:TemplateField HeaderText="Exam Simulator">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnGenerateExamSimulator" runat="server" CommandArgument='<%#Eval("ExamSimulator") %>' OnClick="lnkbtnGenerateExamSimulator_Click">Generate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Exam Simulator Demo">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnGenerateExamSimulatorDemo" runat="server" CommandArgument='<%#Eval("ExamSimulatorDemo") %>' OnClick="lnkbtnGenerateExamSimulatorDemo_Click">Generate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Only Test Once">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnOnlyTestOnce" runat="server" CommandArgument='<%#Eval("OnlyTestOnce") %>' OnClick="lnkbtnOnlyTestOnce_Click"><%# (Boolean.Parse(Eval("OnlyTestOnce").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Allow Print">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnallowprint" runat="server" CommandArgument='<%#Eval("AllowPrint") %>' OnClick="lnkbtnallowprint_Click"><%# (Boolean.Parse(Eval("AllowPrint").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Allow Sales">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnallowsales" runat="server" OnClick="lnkbtnallowsales_Click" CommandArgument='<%#Eval("ExamCodeId")%>'><%# (Boolean.Parse(Eval("AllowSales").ToString())) ? "Yes" : "No" %></asp:LinkButton>
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
