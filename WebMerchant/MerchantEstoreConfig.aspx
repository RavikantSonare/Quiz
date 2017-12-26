<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantEstoreConfig.aspx.cs" Inherits="WebMerchant.MerchantEstoreConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Estore Config</h2>
    <hr />
    <asp:Panel ID="pnlEstoreConfig" runat="server">
        <form class="form-horizontal">
            <div class="form-group row">
                <label for="lblQuestionNumber" class="control-label col-xs-2">Question Number:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtQuestionNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblPrice" class="control-label col-xs-2">Price:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblExamPicture" class="control-label col-xs-2">Exam Picture:</label>
                <div class="col-xs-5">
                    <asp:FileUpload ID="fuExamPicture" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblPicture" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblExamDescription" class="control-label col-xs-2">Exam Description:</label>
                <div class="col-xs-5">
                    <asp:TextBox ID="txtExamdescriptino" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-xs-offset-2 col-xs-10">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" />
                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                </div>
            </div>
        </form>

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
    </asp:Panel>
</asp:Content>
