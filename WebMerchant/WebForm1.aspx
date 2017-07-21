<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebMerchant.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <style type="text/css">
        table.table-style-two {
            font-family: verdana, arial, sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #3A3A3A;
            border-collapse: collapse;
        }

            table.table-style-two th {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #517994;
                background-color: #B2CFD8;
            }

            table.table-style-two tr:hover td {
                background-color: #DFEBF1;
            }

            table.table-style-two td {
                border-width: 0px;
                padding: 8px;
                border-style: solid;
                border-color: #517994;
                background-color: #ffffff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnAddNew" Text="Add Q/A" OnClick="btnAddNew_Click" /><br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <div id="divAdd" runat="server" visible="False" style="font-family: sans-serif; font-size: smaller;">
            <table class="table-style-two" style="vert-align: top;">
                <tr>
                    <td colspan="4"><b>Dynamically Create Textboxes using ASP.Net - Question and Answer</b></td>
                </tr>
                <tr>
                    <td><b>Question</b></td>
                    <td><b>Answer</b></td>
                    <td></td>

                </tr>
                <tr valign="top">
                    <td>

                       
                        <asp:Panel ID="pnlQuestion" runat="server" ViewStateMode="Enabled">
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="pnlAnswer" runat="server">
                        </asp:Panel>
                    </td>
                    <td>
                        <div>
                            <asp:ImageButton ID="imgAdd" OnClick="AddTextBox" Width="26" Height="26" ImageUrl="add.png" runat="server" />
                        </div>
                    </td>

                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnGet" runat="server" Text="Save" OnClick="GetTextBoxValues" />
                        &nbsp;&nbsp;
                        <asp:Button runat="server" ID="Cancel" Text="Cancel" OnClick="Cancel_Click" />
                    </td>
                </tr>

            </table>
        </div>
        <br />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red" Text=""></asp:Label>
    </div>
</asp:Content>
