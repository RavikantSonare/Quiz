<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMerchantConfig.aspx.cs" Inherits="WebAdmin.AdminMerchantConfig" EnableEventValidation="false" %>

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
                if ($('[id$=txtPrice]').val() == "") {
                    $('[id$=txtPrice]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtPrice]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtPrice]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Price</div>");
                    }
                    $('[id$=txtPrice]').focus(function () {
                        $('[id$=txtPrice]').css("border", "1px solid #000000");
                    });
                    e.preventDefault();
                } else {
                    $('[id$=txtPrice]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=txtExamCount]').val() == "") {
                    $('[id$=txtExamCount]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtExamCount]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtExamCount]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Exam Count</div>");
                    }
                    $('[id$=txtExamCount]').focus(function () {
                        $('[id$=txtExamCount]').css("border", "1px solid #000000");
                    });
                    e.preventDefault();
                } else {
                    $('[id$=txtExamCount]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=txtStudentCount]').val() == "") {
                    $('[id$=txtStudentCount]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtStudentCount]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtStudentCount]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Student Count</div>");
                    }
                    $('[id$=txtStudentCount]').focus(function () {
                        $('[id$=txtStudentCount]').css("border", "1px solid #000000");
                    });
                    e.preventDefault();
                } else {
                    $('[id$=txtStudentCount]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=txtShopperFee]').val() == "") {
                    $('[id$=txtShopperFee]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtShopperFee]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtShopperFee]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter Shopper Fee</div>");
                    }
                    $('[id$=txtShopperFee]').focus(function () {
                        $('[id$=txtShopperFee]').css("border", "1px solid #000000");
                    });
                    e.preventDefault();
                } else {
                    $('[id$=txtShopperFee]').parent().next(".validation").remove(); // remove it
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
                    <form class="form-horizontal">
                        <div class="form-group row">
                            <label for="merchantlevel" class="control-label col-xs-2">Merchant Level:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtMerchantLevel" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Price:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Exam Count:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtExamCount" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Student Count:</label>
                            <div class="col-xs-5">
                                <asp:TextBox ID="txtStudentCount" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Shopper Fee:</label>
                            <div class="col-xs-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txtShopperFee" runat="server" class="form-control" TextMode="Number" min="0" Text="0"></asp:TextBox>
                                    <span class="input-group-addon">%</span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2">Extra Permission:</label>
                            <div class="col-xs-5">
                                <asp:CheckBoxList ID="chkQuestionType" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="table-condensed"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="inputPassword" class="control-label col-xs-2"></label>
                            <div class="col-xs-5">
                                <asp:CheckBoxList ID="chkExtraPermission" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="table-condensed"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-xs-offset-2 col-xs-10">
                                <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click">Add</asp:LinkButton>
                                <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                            </div>
                        </div>
                    </form>
                </asp:Panel>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable">
                        <asp:GridView ID="gvMerchantLevel" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="MerchantLevelId" AllowPaging="True" OnPageIndexChanging="gvMerchantLevel_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Merchant Level" DataField="MerchantLevel" />
                                <asp:BoundField HeaderText="Annual Fee" DataField="AnnualFee" />
                                <asp:BoundField HeaderText="Exam Count" DataField="ExamCount" />
                                <asp:BoundField HeaderText="Student Count" DataField="StudentCount" />
                                <asp:BoundField HeaderText="Shopper Fee" DataField="ShopperFee" />
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
