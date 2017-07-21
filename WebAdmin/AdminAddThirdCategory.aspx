<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddThirdCategory.aspx.cs" Inherits="WebAdmin.AdminAddThirdCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtThirdCategory]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Category");
                    $('[id$=txtThirdCategory]').css("border", "1px solid #FF0000");
                    $('[id$=txtThirdCategory]').focus(function () {
                        $('[id$=txtThirdCategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=ddlSecondCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Category");
                    $('[id$=ddlSecondCategory]').css("border", "1px solid #FF0000");
                    $('[id$=ddlSecondCategory]').focus(function () {
                        $('[id$=ddlSecondCategory]').css("border", "1px solid #000000");
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
    <h2>Third Category</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="secondCategory">
            <div class="row">
                <div class="col-sm-7">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="">Category Name:</label>
                                <asp:TextBox ID="txtThirdCategory" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                            <asp:DropDownList ID="ddlSecondCategory" runat="server" class="form-control"></asp:DropDownList>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-success" OnClick="btnAdd_Click" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-sm-5">
                    <div class="form-inline">
                        <div class="form-group">
                            <label for="exampleInputEmail2">Category:</label>
                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div class="col-sm-offset-2 col-sm-10">
                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable mtop">
                        <asp:GridView ID="gvThirdCategory" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="ThirdCategoryId" AllowPaging="True" OnPageIndexChanging="gvThirdCategory_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Category Name" DataField="ThirdCategoryName" />
                                <asp:BoundField HeaderText="Second Category" DataField="SecondCategoryName" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument="" OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument="" OnClick="lnkbtnDelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
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
