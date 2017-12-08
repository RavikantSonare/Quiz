<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OnlineTestStart.aspx.cs" Inherits="WebUser.OnlineTestStart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12 onlineexamheader">
            <div class="col-lg-4 simulatorname">Xexam Simulator</div>
            <div class="col-lg-4">
                <h4 class="examnameh4">
                    <asp:Label ID="lblExamName" runat="server" Text=''></asp:Label>
                </h4>
            </div>
            <div class="col-lg-4" style="text-align: right">
            </div>
        </div>
        <div class="col-lg-12 onlineexamheader-two">
            <div class="col-lg-4" style="text-align: left">
                <b>Question</b>
                <asp:Label ID="lblOutofTotalQuestion" runat="server"></asp:Label>
                of
                <asp:Label ID="lblTotalQuestion" runat="server"></asp:Label>
            </div>
            <div class="col-lg-4">
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
            <div class="col-lg-4" style="text-align: right"></div>
        </div>
        <asp:DataList ID="dlquesanswer" runat="server" RepeatLayout="Flow" DataKeyField="QAId" OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                <div class="col-lg-12" style="border: 1px solid #808080; min-height: 400px">
                    <asp:Panel ID="Panel1" runat="server" Enabled='<%# Eval("Event").ToString() != "SM" ? true : false %>'>
                        <asp:HiddenField ID="hfTestMode" runat="server" Value='<%#Eval("Event")%>' />
                        <div class="mtop10">
                            <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                        </div>
                        <div class="mtop10">
                            <asp:Image ID="imgETS" runat="server" Visible='<%#Eval("Exhibit") == DBNull.Value ||Eval("Topology") == DBNull.Value ||Eval("Scenario") == DBNull.Value ? false : true %>' ImageUrl='<%#String.Format("http://quizmerchant.mobi96.org/resource/{0}{1}{2}",Eval("Exhibit"),Eval("Topology"),Eval("Scenario"))%>' />
                        </div>
                        <div class="col-lg-12">
                            <asp:RadioButtonList ID="rdbtnAnswerList" CssClass="radioboxlist" runat="server" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString()=="1" || Eval("QuestionTypeId").ToString()== "3" || Eval("QuestionTypeId").ToString()== "6" ? true : false %>' CommandArguments='<%#Eval("QAId")%>' OnSelectedIndexChanged="rdbtnAnswerList_SelectedIndexChanged"></asp:RadioButtonList>
                            <asp:CheckBoxList ID="chkboxAnswerList" CssClass="radioboxlist" runat="server" RepeatLayout="Flow" Visible='<%# Eval("QuestionTypeId").ToString() == "2" ? true : false %>' CommandArguments='<%#Eval("QAId")%>' OnSelectedIndexChanged="chkboxAnswerList_SelectedIndexChanged"></asp:CheckBoxList>
                            <asp:Panel ID="pnlDragDrop" runat="server" Visible='<%# Eval("QuestionTypeId").ToString() == "4" ? true : false %>'>
                                <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
                                <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lbDrag" runat="server" Height="200px" Width="250px" SelectionMode="Multiple"></asp:ListBox>
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
                                            <asp:ListBox ID="lbDrop" runat="server" Height="200px" Width="250px" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lbltxt" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlHotSpot" runat="server" Visible='<%# Eval("QuestionTypeId").ToString() == "5" ? true : false %>'>
                                <asp:ImageMap ID="imgHotSpot" runat="server" CssClass="map">
                                </asp:ImageMap>
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
            <FooterTemplate>
                <asp:Label Visible='<%#bool.Parse((dlquesanswer.Items.Count==0).ToString())%>'
                    runat="server" ID="lblNoRecord" Text="No qestion found!"></asp:Label>
            </FooterTemplate>
        </asp:DataList>
        <div class="col-lg-12 diagonal_lines_pattern" style="border: 1px solid #808080; border-top: 0">
            <div class="col-lg-6" style="margin-top: 8px">
                <div class="col-lg-4">
                    <asp:Button ID="btnprevious" runat="server" Text="Previous" CssClass="btn bg-primary btn-block btn-square" OnClick="btnprevious_Click" />
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="btn bg-primary btn-block btn-square" OnClick="btnnext_Click" />
                </div>
            </div>
            <div class="col-lg-6 " style="margin-top: 8px">
                <div class="col-lg-4 pull-right">
                    <asp:Button ID="btnEndExam" runat="server" Text="End Exam" CssClass="btn bg-primary btn-block btn-square" OnClick="btnEndExam_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function setCordinator(QuestionID, AnswerId) {
            PageMethods.setCordinator(QuestionID, AnswerId);
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('area').click(function (event) {
                var map = document.getElementById('ImageMapContentPlaceHolder1_dlquesanswer_imgHotSpot_0');
                var areas = map.getElementsByTagName('area');
                for (var i = 0; i < areas.length; i++) {
                    var area = areas[i];
                    var id = area.alt;
                    var data = $('#' + id).data('maphilight') || {};
                    if (area.alt == $(this)[0].alt)
                        data.fillColor = '0000ff'; // Sample color           
                    else data.fillColor = 'ff0000'; // Sample color           
                    $($(this)[0].alt).data('maphilight', data).trigger('alwaysOn.maphilight');
                }
            });
            $('.map').maphilight({ strokeColor: '808080', strokeWidth: 0, fill: 'ff0000', fillColor: 'ff0000', alwaysOn: true });
        });
    </script>
</asp:Content>
