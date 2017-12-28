<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantWithDraw.aspx.cs" Inherits="WebMerchant.MerchantWithDraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnRequest]').click(function () {
                if ($('[id$=txtWithDraw]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter WithDraw Amount");
                    $('[id$=txtWithDraw]').css("border", "1px solid #FF0000");
                    $('[id$=txtWithDraw]').focus(function () {
                        $('[id$=txtWithDraw]').css("border", "1px solid #000000");
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
    <h2>Finance Withdraw</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="withdraw">
            <div class="row">
                <div class="col-sm-12">
                    <h5>Your Currently Balance: $
                        <asp:Label ID="lblcurrbal" runat="server"></asp:Label></h5>
                </div>
                <div class="form-inline">
                    <label for="" class="col-sm-1 control-label">WithDraw:</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtWithDraw" runat="server" class="form-control" TextMode="Number" onkeyup="CheckFirstChar(event.keyCode, this)" min="0"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 clearfix">
                        <asp:Button ID="btnRequest" runat="server" Text="Request" class="btn btn-default" OnClick="btnRequest_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-default" OnClick="btnReset_Click" />
                    </div>
                    <div class="col-sm-12" style="height: 10px">
                    </div>
                    <div class="col-sm-offset-2 col-sm-8">
                        <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <h5>Finance Report</h5>
                    <asp:GridView ID="gvWithDraw" runat="server" AutoGenerateColumns="false" class="table" AllowPaging="True" OnPageIndexChanging="gvWithDraw_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Date" DataField="OrderDate" />
                            <asp:BoundField HeaderText="WithDraw Amount" DataField="Amount" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <%# (Boolean.Parse(Eval("OrderStatus").ToString())) ? "Finished" : "Processing" %>
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
    <div class="messagealert" id="alert_container">
    </div>
</asp:Content>
