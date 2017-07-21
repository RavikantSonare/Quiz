<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddTopCategory.aspx.cs" Inherits="WebAdmin.AdminAddTopCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtCategoryName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Category");
                    $('[id$=txtCategoryName]').css("border", "1px solid #FF0000");
                    $('[id$=txtCategoryName]').focus(function () {
                        $('[id$=txtCategoryName]').css("border", "1px solid #000000");
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
    <h2>Top Category</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="topCategory">
            <div class="row">
                <div class="col-sm-6">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="exampleInputName2">Category Name:</label>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-sm-6">
                    <div class="form-inline">
                        <div class="form-group">
                            <label for="exampleInputEmail2">Category:</label>
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSeach" runat="server" Text="Search" class="btn btn-info" OnClick="btnSeach_Click" />
                    </div>
                </div>
                <div class="col-sm-offset-2 col-sm-10">
                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable mtop">
                        <asp:GridView ID="gvTopCategory" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="TopCategoryId" AllowPaging="True" OnPageIndexChanging="gvTopCategory_PageIndexChanging" PageSize="10">
                            <Columns>
                                <asp:BoundField HeaderText="Category Name" DataField="TopCategoryName" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClick="lnkbtnDelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <h2>Record not found...</h2>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <%-- <asp:ListView ID="ListView1" runat="server" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                            <LayoutTemplate>
                                <table>
                                    <tr>
                                        <th>Category Name</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <th><%#Eval("TopCategoryName")%></th>
                                    <th>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server">Edit</asp:LinkButton></th>
                                    <th>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton></th>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                    ShowNextPageButton="false" />
                                <asp:NumericPagerField ButtonType="Link" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function getConfirmation(sender, title, message) {
            $("#spnTitle").text(title);
            $("#spnMsg").text(message);
            $('#modalPopUp').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
    </script>
    <div id="modalPopUp" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <span id="spnTitle"></span>
                    </h4>
                </div>
                <div class="modal-body">
                    <p>
                        <span id="spnMsg"></span>.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                    <button type="button" id="btnConfirm" class="btn btn-danger">
                        Yes, please</button>
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
