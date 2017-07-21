<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminExamManage.aspx.cs" Inherits="WebAdmin.AdminExamManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
    <h2>Exam Manage</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="examManager">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-12">
                        <div class="col-sm-12">
                            <div class="col-sm-2">Exam Code</div>
                            <div class="col-sm-3">Second Category</div>
                            <div class="col-sm-3">Merchant Name</div>
                            <div class="col-sm-2">Level</div>
                            <div class="col-sm-2"></div>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox ID="txtExamCode" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtSecondCategoryName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtMerchantName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox ID="txtLevel" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click" />
                        </div>

                        <div class="col-sm-12" style="height: 10px">
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                        <asp:GridView ID="gvExamManage" class="table" AutoGenerateColumns="false" DataKeyNames="ExamCodeId" runat="server" AllowPaging="True" OnPageIndexChanging="gvExamManage_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ExamCode" HeaderText="Exam Code" />
                                <asp:BoundField DataField="SecondCategoryName" HeaderText="Second Category" />
                                <asp:BoundField DataField="MerchantName" HeaderText="Merchant Name" />
                                <asp:BoundField DataField="MerchantLevel" HeaderText="Level" />
                                <asp:TemplateField HeaderText="Active(Default is Actived)">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnactive" runat="server" CommandArgument='<%#Eval("IsActive") %>' OnClick="lnkbtnactive_Click">  <%# (Boolean.Parse(Eval("IsActive").ToString())) ? "Active" : "Inactive" %></asp:LinkButton>
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
