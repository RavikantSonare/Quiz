<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OnlineTestBegin.aspx.cs" Inherits="WebUser.OnlineTestBegin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .outer {
            /*outline: 1px solid #eee;*/
            display: table;
            width: 100%;
        }

            .outer > p {
                display: table-cell;
                height: 200px;
                vertical-align: middle;
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 onlineexamheader">
            <div class="col-lg-4 simulatorname">Xexam Simulator</div>
            <div class="col-lg-4">
                <h4 class="examnameh4">
                    <asp:Label ID="lblExamName" runat="server" Text='<%#Eval("ExamCode")%>'></asp:Label>
                </h4>
            </div>
            <div class="col-lg-4" style="text-align: right">
            </div>
        </div>
        <div style="text-align: center">
            <asp:DataList ID="dlexamdetail" runat="server" RepeatLayout="Flow">
                <ItemTemplate>
                    <div class="col-lg-12" style="border: 1px solid #808080; min-height: 400px">
                        <h2>
                            <asp:Label ID="lblExamName" runat="server" Text='<%#string.Format("{0}  {1}",Eval("SecondCategoryName"),Eval("ExamCode")) %>'></asp:Label>
                        </h2>
                        <div class="outer">
                            <p>Exam Description.....</p>
                        </div>
                    </div>
                    <div class="col-lg-12 diagonal_lines_pattern" style="border: 1px solid #808080; border-top: 0">
                        <asp:Button ID="btnreadytobegin" runat="server" Text="I am ready to begin" CommandArgument='<%#Eval("ExamCodeId") %>' CssClass="btn btn-square btn-success" OnClick="btnreadytobegin_Click" />
                    </div>
                </ItemTemplate>
            </asp:DataList>

        </div>
    </div>
</asp:Content>
