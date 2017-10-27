<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Estore.index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumbs Styles -->
    <section class="irs-ip-breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-lg-offset-3 text-center">
                    <h1 class="irs-bc-title">Courses</h1>
                </div>
            </div>
        </div>
    </section>

    <!-- Breadcrumbs html -->
    <section class="irs-ip-brdcrumb">
        <div class="container">
            <div class="row"></div>
        </div>
    </section>



    <!-- Social Media Section -->
    <section class="irs-client">
        <div class="container">
            <div class="row irs-mrgnt">
                <div class="col-md-2 col-md-offset-2 clearfix animatedParent">
                    <div class="irs-clients-thumb text-center animated growIn">
                        Total Merchant<p>
                            <asp:Label ID="lblMerchantCount" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="col-md-2 clearfix animatedParent">
                    <div class="irs-clients-thumb text-center animated growIn">
                        Total Students<p>
                            <asp:Label ID="lblUserCount" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="col-md-2 clearfix animatedParent">
                    <div class="irs-clients-thumb text-center animated growIn">
                        Total Exams<p>
                            <asp:Label ID="lblExamCount" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="col-md-2 clearfix animatedParent">
                    <div class="irs-clients-thumb text-center animated growIn">
                        Total Questions<p>
                            <asp:Label ID="lblQuestionCount" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
