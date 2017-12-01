<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantLogin.aspx.cs" Inherits="WebMerchant.MerchantLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide {
            display: none;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnRequest]').click(function () {
                if ($('[id$=txtcategory]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Category");
                    $('[id$=txtcategory]').css("border", "1px solid #FF0000");
                    $('[id$=txtcategory]').focus(function () {
                        $('[id$=txtcategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=drpTopcategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Top Category");
                    $('[id$=drpTopcategory]').css("border", "1px solid #FF0000");
                    $('[id$=drpTopcategory]').focus(function () {
                        $('[id$=drpTopcategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
            });
        });
        function CheckFirstChar(key, txt) {
            if (key == 32 && txt.value.length <= 0) {
                return false;
            }
            else if (txt.value.length > 0) {
                if (txt.value.charCodeAt(0) == 32) {
                    txt.value = txt.value.substring(1, txt.value.length);
                    return true;
                }
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Merchant Dashboard</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvMerchantDetail" runat="server" class="table" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvMerchantDetail_PageIndexChanging">
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
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>

                </div>
                <div class="col-sm-12">
                    <div class="form-inline mbtm20">
                        <div class="form-group">
                            <label for="">Request Add New Category:</label>
                            <asp:TextBox ID="txtcategory" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <asp:DropDownList ID="drpTopcategory" runat="server" class="form-control mlr"></asp:DropDownList>
                        <asp:Button ID="btnRequest" runat="server" Text="Request" class="btn btn-default" OnClick="btnRequest_Click" />
                        <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                    </div>

                </div>


            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table merchantLogin-table mtop10" DataKeyNames="ExamCodeId" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Review">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnReview" runat="server" PostBackUrl='<%# String.Format("~/MerchantLogin.aspx?exid={0}", Eval("ExamCodeId"))%>'>Review</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdexamId" runat="server" Value='<%#Eval("ExamCodeId")%>' />
                                </ItemTemplate>

                                <HeaderStyle CssClass="hide"></HeaderStyle>

                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                            <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:TemplateField HeaderText="Exam Simulator">
                                <ItemTemplate>
                                    <a href="#"><%#Eval("ExamSimulator") %></a>
                                    <%--<asp:LinkButton ID="lnkbtnGenerateExamSimulator" CommandArgument='<%#Eval("ExamSimulator") %>' runat="server">Generate</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exam Simulator Demo">
                                <ItemTemplate>
                                    <a href="#"><%#Eval("ExamSimulatorDemo") %></a>
                                    <%--<asp:LinkButton ID="lnkbtnGenerateExamSimulatorDemo" CommandArgument='<%#Eval("ExamSimulatorDemo") %>' runat="server">Generate</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Only Test Once">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnOnlytestOnce" runat="server" CommandArgument='<%#Eval("OnlyTestOnce") %>' OnClick="lnkbtnOnlytestOnce_Click"><%# (Boolean.Parse(Eval("OnlyTestOnce").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Print">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowprint" runat="server" CommandArgument='<%#Eval("AllowPrint") %>' OnClick="lnkbtnallowprint_Click"><%# (Boolean.Parse(Eval("AllowPrint").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Sales">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowsales" runat="server" CommandArgument='<%#Eval("AllowSales") %>' OnClick="lnkbtnallowsales_Click"><%# (Boolean.Parse(Eval("AllowSales").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Price">
                                <ItemTemplate>
                                    <%# String.Format("{0}{1}","$",Eval("Price"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>


    </div>
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
</asp:Content>
