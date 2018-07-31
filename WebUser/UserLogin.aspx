<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebUser.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Dashboard</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="">
            <div class="row">
                <div class="col-lg-12 mbtm20">
                    <div class="form-group">
                        <label for="" class="col-sm-2 control-label">Exam code:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-5">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="clearfix mtop10" style="max-height: 300px; overflow-y: scroll;">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" OnRowDataBound="gvExamDetail_RowDataBound">
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
                            <asp:BoundField HeaderText="User Valid Date" DataField="ValidTimeTo" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:TemplateField HeaderText="Study Mode">
                                <ItemTemplate>
                                    <asp:Button ID="btnStudyNow" runat="server" Text="Study Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnStudyNow_Click" Visible='<%# !Convert.ToBoolean(Eval("OnlineTest")) == true ? false : true %>' Enabled='<%# Eval("QuestionCount").ToString() != "0" ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Real Test Mode">
                                <ItemTemplate>
                                    <asp:Button ID="btnTestMode" runat="server" Text="Test Now" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnTestMode_Click" Visible='<%# !Convert.ToBoolean(Eval("OnlineTest")) == true ? false : true %>' Enabled='<%# Eval("QuestionCount").ToString() != "0" ? true : false %>' />
                                    <asp:Label ID="lblemptymsg" runat="server" Text="Question not available" ForeColor="Red" Visible='<%# Eval("QuestionCount").ToString() == "0" ? true : false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test Once">
                                <ItemTemplate>
                                    <asp:Button ID="btnTestOnce" runat="server" Text="Do Real Test" CssClass="btn btn-default" CommandArgument='<%#Eval("ExamCodeId")%>' OnClick="btnTestOnce_Click" Enabled='<%# Eval("TestOnce")%>' Visible='<%# !Convert.ToBoolean(Eval("OnlineTest")) == true ? true : false %>' />
                                    <asp:HiddenField ID="hdaccesoption" runat="server" Value='<%#Eval("AccessOption")%>' />
                                    <asp:HiddenField ID="hdoto" runat="server" Value='<%#Eval("TestOnce")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm-12 mtop30">
                <asp:GridView ID="gvExamReport" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField HeaderText="Test Date" DataField="ExamGivenDate" DataFormatString="{0:yyyy/MM/dd}" />
                        <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                        <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                        <asp:BoundField HeaderText="Score" DataField="Score" />
                        <asp:TemplateField HeaderText="Result">
                            <ItemTemplate>
                                <%# (Convert.ToBoolean(Eval("Result"))==true?"Pass":"Fail") %>
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
    <div class="messagealert" id="alert_container">
    </div>
</asp:Content>
