<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantCertificateGenerate.aspx.cs" Inherits="WebMerchant.MerchantCertificateGenerate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Exam Reports</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="examReport">
            <div class="row">
                <asp:Image ID="imgcertificate" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
