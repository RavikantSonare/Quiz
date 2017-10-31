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
    <div class="row" style="text-align: center">
        <asp:DataList ID="dlexamdetail" runat="server" RepeatLayout="Flow">
            <ItemTemplate>
                <h2>
                    <asp:Label ID="lblExamName" runat="server" Text='<%#Eval("ExamCode")%>'></asp:Label>
                </h2>
                <div class="outer">
                    <p>Exam Description.....</p>
                </div>
                <asp:Button ID="btnreadytobegin" runat="server" Text="I am ready to begin" CommandArgument='<%#Eval("ExamCodeId") %>' CssClass="btn btn-success" OnClick="btnreadytobegin_Click" />
            </ItemTemplate>
        </asp:DataList>

    </div>
</asp:Content>
