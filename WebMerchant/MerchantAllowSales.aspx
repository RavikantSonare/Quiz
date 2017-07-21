<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantAllowSales.aspx.cs" Inherits="WebMerchant.MerchantAllowSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#submenu1').slideToggle();
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtTotalQuestion]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please enter total question");
                    $('[id$=txtTotalQuestion]').css("border", "1px solid #FF0000");
                    $('[id$=txtTotalQuestion]').focus(function () {
                        $('[id$=txtTotalQuestion]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtPrice]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please enter price");
                    $('[id$=txtPrice]').css("border", "1px solid #FF0000");
                    $('[id$=txtPrice]').focus(function () {
                        $('[id$=txtPrice]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Merchant Sales</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="examManageQues">
            <asp:Panel ID="Panel1" runat="server">
                <div class="">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-3 control-label">Total Question:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtTotalQuestion" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword3" class="col-sm-3 control-label">Price:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword3" class="col-sm-3 control-label">Self Description:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtSelfDescription" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">
                                <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                            </div>
                            <div class="col-sm-offset-3 col-sm-3">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-default" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-default" OnClick="btnReset_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="">
                <div class="salseReport">
                    <asp:GridView ID="gvAllowSales" runat="server" AutoGenerateColumns="false" class="table" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gvAllowSales_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id")%>' />
                                </ItemTemplate>

                                <HeaderStyle CssClass="hide"></HeaderStyle>

                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="No of Question" DataField="NoofQuestion" />
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                            <asp:BoundField HeaderText="Self Description" DataField="SelfDescription" />
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
