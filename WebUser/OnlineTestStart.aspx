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
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //Attach click event of button
            $("#btnRight").click(function (e) {
                //Pass the value from Listbox1 to Listbox2
                $("#Listbox1 > option:selected").each(function () {
                    $(this).remove().appendTo("#Listbox2");
                });
                e.preventDefault();
            });
            //Attach click event of button
            $("#btnleft").click(function (e) {
                //Pass the value from Listbox2 to Listbox1
                $("#Listbox2 > option:selected").each(function () {
                    $(this).remove().appendTo("#Listbox1");
                });
                e.preventDefault();
            });
        });
    </script>
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
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTime" runat="server" Text="Time:"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>--%>
            </div>
        </div>
        <asp:DataList ID="dlquesanswer" runat="server" RepeatLayout="Flow" DataKeyField="QAId" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="border: 1px solid #808080; min-height: 400px">
                    <asp:Panel ID="Panel1" runat="server" Enabled='<%# Eval("Event").ToString() != "SM" ? true : false %>'>
                        <asp:HiddenField ID="hfTestMode" runat="server" Value='<%#Eval("Event")%>' />
                        <div class="mtop10">
                            <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:RadioButtonList ID="rdbtnAnswerList" CssClass="radioboxlist" runat="server" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString() == "1" ? true : false %>' CommandArguments='<%#Eval("QAId")%>' OnSelectedIndexChanged="rdbtnAnswerList_SelectedIndexChanged"></asp:RadioButtonList>
                            <asp:CheckBoxList ID="chkboxAnswerList" CssClass="radioboxlist" runat="server" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString() == "2" ? true : false %>' CommandArguments='<%#Eval("QAId")%>' OnSelectedIndexChanged="chkboxAnswerList_SelectedIndexChanged"></asp:CheckBoxList>
                            <asp:Panel ID="pnlDragDrop" runat="server" Visible='<%# Eval("QuestionTypeId").ToString() == "4" ? true : false %>'>
                                <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
                                <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lbDrag" runat="server" Height="169px" Width="121px" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btn1" runat="server" Text=">" Width="45px" OnClick="btn1_Click" CommandArguments='<%#Eval("QAId")%>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btn3" runat="server" Text="<" Width="45px" OnClick="btn3_Click" CommandArguments='<%#Eval("QAId")%>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lbDrop" runat="server" Height="169px" Width="121px" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lbltxt" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <asp:Panel ID="Panel2" runat="server" Visible='<%# Eval("Event").ToString() == "SM" ? true : false %>'>
                            <div class="mtop10 clearfix">
                                <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Explanation")%>'></asp:Label>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
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
