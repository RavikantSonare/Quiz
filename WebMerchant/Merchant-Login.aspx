<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="Merchant-Login.aspx.cs" Inherits="WebMerchant.Merchant_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvMerchantDetail" runat="server" class="table" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdMerchantId" runat="server" Value='<%#Eval("MerchantId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Valid Date" DataField="EndDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField HeaderText="Merchant Name" DataField="MerchantName" />
                            <asp:BoundField HeaderText="Login" DataField="UserName" />
                            <asp:BoundField HeaderText="Currently Level" DataField="MerchantLevel" />
                            <asp:TemplateField HeaderText="Upgrade">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnUpgrade" runat="server">Upgrade</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renewal">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnRenewal" runat="server">Renewal</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                <div class="col-sm-12">
                    <div class="form-inline mbtm20">
                        <div class="form-group">
                            <label for="">Request Add New Categoary:</label>
                            <asp:TextBox ID="txtcategory" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <asp:DropDownList ID="drpTopcategory" runat="server" class="form-control mlr"></asp:DropDownList>
                        <asp:Button ID="btnRequest" runat="server" Text="Request" class="btn btn-default" />
                    </div>
                    <div>(Merchant Login default show as like this)</div>
                </div>


            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table merchantLogin-table mtop10"></asp:GridView>
                    <table class="table merchantLogin-table mtop10">
                        <thead>
                            <tr>
                                <td>Review</td>
                                <td>Exam Code</td>
                                <td>Categoary</td>
                                <td>Test Time</td>
                                <td>Valid Date</td>
                                <td>Exam Simulator</td>
                                <td>Exam Simulator Demo</td>
                                <td>Only Test Once</td>
                                <td>Allow Print</td>
                                <td>Allow Sales</td>
                                <td>Item Price</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Review</td>
                                <td>300-120</td>
                                <td>Cisco</td>
                                <td>120 Min</td>
                                <td>2018/1/8</td>
                                <td>Generate</td>
                                <td>Generate</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>$50</td>
                            </tr>
                            <tr>
                                <td>Review</td>
                                <td>300-120</td>
                                <td>Cisco</td>
                                <td>120 Min</td>
                                <td>2018/1/8</td>
                                <td>Generate</td>
                                <td>Generate</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>$50</td>
                            </tr>
                            <tr>
                                <td>Review</td>
                                <td>300-120</td>
                                <td>Cisco</td>
                                <td>120 Min</td>
                                <td>2018/1/8</td>
                                <td>Generate</td>
                                <td>Generate</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>$50</td>
                            </tr>
                            <tr>
                                <td>Review</td>
                                <td>300-120</td>
                                <td>Cisco</td>
                                <td>120 Min</td>
                                <td>2018/1/8</td>
                                <td>Generate</td>
                                <td>Generate</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>Yes/No</td>
                                <td>$50</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="clearfix col-sm-12">
                    <p>Lorem Ipsum is simply dummy text of the printing and Lorem Ipsum has...  </p>
                    <p>Lorem Ipsum is simply dummy text of the printing and Lorem Ipsum hasLorem Ipsum is simply dummy text of the printing and Lorem Ipsum has</p>
                    <p>Lorem Ipsum is simply dummy text of the printing and Lorem Ipsum has...  </p>
                    <p>Lorem Ipsum is simply dummy text of the printing and Lorem Ipsum hasLorem Ipsum is simply dummy text of the printing and Lorem Ipsum has</p>
                </div>
            </div>
        </div>
        <div class="tab-pane" id="addExam">Add Exams</div>
        <div class="tab-pane" id="myExam">My Exams</div>
        <div class="tab-pane" id="myUser">My Users</div>
        <div class="tab-pane" id="examReport">Exam Reports</div>
        <div class="tab-pane" id="salesReport">Sales Reports</div>
        <div class="tab-pane" id="financeReport">Finance Reports</div>
        <div class="tab-pane" id="config">Config</div>

    </div>
</asp:Content>
