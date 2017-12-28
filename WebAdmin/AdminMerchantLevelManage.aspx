<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMerchantLevelManage.aspx.cs" Inherits="WebAdmin.AdminMerchantLevelManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function (e) {
                var focusSet = false;
                if ($('[id$=txtMerchantLevel]').val() == "") {
                    $('[id$=txtMerchantLevel]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtMerchantLevel]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtMerchantLevel]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Level</div>");
                    }
                    $('[id$=txtMerchantLevel]').focus(function () {
                        $('[id$=txtMerchantLevel]').css("border", "1px solid #000000");
                    });
                    e.preventDefault(); // prevent form from POST to server
                    focusSet = true;
                } else {
                    $('[id$=txtMerchantLevel]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=txtAnnualFee]').val() == "") {
                    $('[id$=txtAnnualFee]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtAnnualFee]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtAnnualFee]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Annual Fee</div>");
                    }
                    $('[id$=txtAnnualFee]').focus(function () {
                        $('[id$=txtAnnualFee]').css("border", "1px solid #000000");
                    });
                    e.preventDefault();
                } else {
                    $('[id$=txtAnnualFee]').parent().next(".validation").remove(); // remove it
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
    <h2>Merchant Level</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="merchantLevel">
            <div class="row">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="col-sm-5">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="exampleInputName2">Merchant Level:</label>
                                <asp:TextBox ID="txtMerchantLevel" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="exampleInputEmail2">Annual Fee:</label>
                                <asp:TextBox ID="txtAnnualFee" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-inline">
                            <div class="form-group">
                                <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click">Add</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                    </div>
                </asp:Panel>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable mtop">
                        <asp:GridView ID="gvMerchantLevel" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="MerchantLevelId" AllowPaging="True" OnPageIndexChanging="gvMerchantLevel_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Merchant Level" DataField="MerchantLevel" />
                                <asp:BoundField HeaderText="Annual Fee" DataField="AnnualFee" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');" OnClick="lnkbtnDelete_Click">Delete</asp:LinkButton>
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
    <div class="messagealert" id="alert_container">
    </div>
</asp:Content>
