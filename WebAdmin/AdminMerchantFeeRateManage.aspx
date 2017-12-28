<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMerchantFeeRateManage.aspx.cs" Inherits="WebAdmin.AdminMerchantFeeRateManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtMerchantFeeRate]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Fee Rate Value");
                    $('[id$=txtMerchantFeeRate]').css("border", "1px solid #FF0000");
                    $('[id$=txtMerchantFeeRate]').focus(function () {
                        $('[id$=txtMerchantFeeRate]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

                if ($('[id$=ddlMerchantLevel]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Merchant Level");
                    $('[id$=ddlMerchantLevel]').css("border", "1px solid #FF0000");
                    $('[id$=ddlMerchantLevel]').focus(function () {
                        $('[id$=ddlMerchantLevel]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Merchant Fee Rate</h2>
    <hr />
    <div class="tab-content top-category-content">
        <div class="tab-pane active" id="merchantFreeRate">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <div class="form-inline">
                        <div class="form-group">
                            <label for="exampleInputName2">Merchant Fee Rate:</label>
                            <asp:TextBox ID="txtMerchantFeeRate" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                        </div>
                        <asp:DropDownList ID="ddlMerchantLevel" runat="server" class="form-control"></asp:DropDownList>
                        <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click">Add</asp:LinkButton>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="topCategoryTable mtop">
                        <asp:GridView ID="gvMerchantFeeRate" runat="server" class="table" AutoGenerateColumns="false" DataKeyNames="MerchantFeeRateId" AllowPaging="True" OnPageIndexChanging="gvMerchantFeeRate_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Merchant Fee Rate" DataField="MerchantFeeRate" />
                                <asp:BoundField HeaderText="Merchant Level" DataField="MerchantLevel" />
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
