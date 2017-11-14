<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebUser.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Dashboard</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="UserId" runat="server" Value='<%#Eval("UserId")%>' />
                                </ItemTemplate>
                                <HeaderStyle CssClass="hide"></HeaderStyle>
                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                            <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:TemplateField HeaderText="Study Mode">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnStudyNow" runat="server" Text="Study Now" class="btn btn-default" CommandArgument='<%#Eval("ExamCode")%>' Visible='<%# !(Convert.ToBoolean(Eval("OnlyTestOnce"))) %>' OnClick="btnTestMode_Click" />--%>
                                    <asp:Button ID="btnStudyNow" runat="server" Text="Study Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnStudyNow_Click" Enabled='<%# Eval("QuestionCount").ToString() != "0" ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Real Test Mode">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnTestMode" runat="server" Text="Test Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCode")%>' Visible='<%# !(Convert.ToBoolean(Eval("OnlyTestOnce"))) %>' OnClick="btnTestMode_Click" />--%>
                                    <asp:Button ID="btnTestMode" runat="server" Text="Test Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnTestMode_Click" Enabled='<%# Eval("QuestionCount").ToString() != "0" ? true : false %>' />
                                    <asp:Label ID="lblemptymsg" runat="server" Text="Question not available" ForeColor="Red" Visible='<%# Eval("QuestionCount").ToString() == "0" ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test Once">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnTestMode" runat="server" Text="Test Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCode")%>' Visible='<%# !(Convert.ToBoolean(Eval("OnlyTestOnce"))) %>' OnClick="btnTestMode_Click" />--%>
                                    <asp:Button ID="btnTestOnce" runat="server" Text="Do Real Test" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnTestMode_Click" Enabled='<%# Eval("QuestionCount").ToString() != "0" ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>

                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvExamReport" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField HeaderText="Test Date" DataField="ExamGivenDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="Score" DataField="Score" />
                            <asp:BoundField HeaderText="Pass/Fail" DataField="Result" />
                           <%-- <asp:TemplateField HeaderText="Question Print">
                                <ItemTemplate>
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-default" Visible='<%# (Convert.ToBoolean(Eval("AllowPrint"))) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Digital Certificate">
                                <ItemTemplate>
                                    <asp:Button ID="btnDownload" runat="server" Text="Download" class="btn btn-default" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
