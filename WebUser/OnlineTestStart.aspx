﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OnlineTestStart.aspx.cs" Inherits="WebUser.OnlineTestStart" %>

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

        .FormatRadioButtonList label {
            margin-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 outer" style="min-height: 100px; background-color: #083C64; color: white; font-size: large">
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Exam:<asp:Label ID="lblExamCode" runat="server"></asp:Label></div>
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                Question:<asp:Label ID="lblOutofTotalQuestion" runat="server" Text="1"></asp:Label>
                /
                <asp:Label ID="lblTotalQuestion" runat="server"></asp:Label>
            </div>
            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
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
        <%--<asp:FormView ID="FormView1" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="border: 1px solid #808080">
                    <asp:HiddenField ID="hfQuestionId" runat="server" Value='<%#Eval("QAId")%>' />
                    <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                    <asp:RadioButtonList ID="rdbtnAnswerOption" runat="server" DataSource='<%#Eval("AnswerList")%>' DataTextField="Answer" DataValueField="AnswerId" RepeatLayout="Flow"></asp:RadioButtonList>
                </div>
            </ItemTemplate>
        </asp:FormView>--%>
        <asp:DataList ID="dlquesanswer" runat="server" RepeatLayout="Flow">
            <ItemTemplate>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="border: 1px solid #808080; height: 250px">
                    <asp:HiddenField ID="hfQuestionId" runat="server" Value='<%#Eval("QAId")%>' />
                    <div style="margin-top: 20px;">
                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="margin-top: 20px">
                        <asp:RadioButtonList ID="rdbtnAnswerOption" runat="server" DataSource='<%#Eval("AnswerList")%>' DataTextField="Answer" DataValueField="AnswerId" RepeatLayout="Flow" CssClass="FormatRadioButtonList"></asp:RadioButtonList>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="text-align: left; margin-top: 20px">
            <asp:Button ID="btnprevious" runat="server" Text="Previous" CssClass="btn bg-primary" />
        </div>
        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="text-align: right; margin-top: 20px">
            <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="btn bg-primary" />
        </div>
    </div>
</asp:Content>
