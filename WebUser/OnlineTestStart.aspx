<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OnlineTestStart.aspx.cs" Inherits="WebUser.OnlineTestStart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .outer {
            /*outline: 1px solid #eee;*/
            display: table;
            width: 100%;
        }

            .outer > div {
                display: table-cell;
                vertical-align: middle !important;
                text-align: center;
                margin-top: 30px;
            }

        .radioboxlist radioboxlistStyle {
            font-size: x-large;
            padding-right: 20px;
        }

        .radioboxlist label {
            color: #3E3928;
            padding-left: 6px;
            padding-right: 16px;
            padding-top: 2px;
            padding-bottom: 2px;
            white-space: nowrap;
            clear: left;
            margin-right: 10px;
            margin-left: 10px;
        }

            .radioboxlist label:hover {
                color: #083C64;
            }

        input:checked + label {
            color: #083C64;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 outer" style="min-height: 100px; background-color: #083C64; color: white; font-size: large">
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" style="text-align: left">Exam:<asp:Label ID="lblExamCode" runat="server"></asp:Label></div>
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                Question:
                <asp:Label ID="lblOutofTotalQuestion" runat="server"></asp:Label>
                /
                <asp:Label ID="lblTotalQuestion" runat="server"></asp:Label>
            </div>
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" style="text-align: right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTime" runat="server" Text="Time:"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
            </div>
        </div>
        <asp:DataList ID="dlquesanswer" runat="server" RepeatLayout="Flow" DataKeyField="QAId" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="border: 1px solid #808080; min-height: 400px">
                    <asp:HiddenField ID="hfQuestionId" runat="server" Value='<%#Eval("QAId")%>' />
                    <div style="margin-top: 20px;">
                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="margin-top: 20px">
                        <%-- <asp:RadioButtonList ID="rdbtnAnswerOption" CssClass="radioboxlist" runat="server" DataSource='<%#Eval("AnswerList")%>' DataTextField="Answer" DataValueField="AnswerId" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString() == "1" ? true : false %>'>
                        </asp:RadioButtonList>
                        <asp:CheckBoxList ID="chkbtnAnswerOption" CssClass="radioboxlist" runat="server" DataSource='<%#Eval("AnswerList")%>' DataTextField="Answer" DataValueField="AnswerId" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString() == "2" ? true : false %>'></asp:CheckBoxList>--%>
                        <asp:RadioButtonList ID="RadioButtonList1" CssClass="radioboxlist" runat="server" RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="text-align: left; margin-top: 20px">
            <asp:Button ID="btnprevious" runat="server" Text="Previous" CssClass="btn bg-primary" OnClick="btnprevious_Click" />
        </div>
        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="text-align: right; margin-top: 20px">
            <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="btn bg-primary" OnClick="btnnext_Click" />
        </div>
    </div>
</asp:Content>
