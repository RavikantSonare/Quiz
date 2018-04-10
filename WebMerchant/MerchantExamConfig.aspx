<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantExamConfig.aspx.cs" Inherits="WebMerchant.MerchantExamConfig" ValidateRequest="false" UICulture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtExamCode]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Exam Code");
                    $('[id$=txtExamCode]').css("border", "1px solid #FF0000");
                    $('[id$=txtExamCode]').focus(function () {
                        $('[id$=txtExamCode]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtExamtitle]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Exam Title");
                    $('[id$=txtExamtitle]').css("border", "1px solid #FF0000");
                    $('[id$=txtExamtitle]').focus(function () {
                        $('[id$=txtExamtitle]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=drpTopCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Category");
                    $('[id$=drpTopCategory]').css("border", "1px solid #FF0000");
                    $('[id$=drpTopCategory]').focus(function () {
                        $('[id$=drpTopCategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=drpSecondCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Category");
                    $('[id$=drpSecondCategory]').css("border", "1px solid #FF0000");
                    $('[id$=drpSecondCategory]').focus(function () {
                        $('[id$=drpSecondCategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

                if ($('[id$=txtPassingPercentage]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Percentage Value");
                    $('[id$=txtPassingPercentage]').css("border", "1px solid #FF0000");
                    $('[id$=txtPassingPercentage]').focus(function () {
                        $('[id$=txtPassingPercentage]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtTestTime]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Test Time Value");
                    $('[id$=txtTestTime]').css("border", "1px solid #FF0000");
                    $('[id$=txtTestTime]').focus(function () {
                        $('[id$=txtTestTime]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtTestOption]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Test Option Value");
                    $('[id$=txtTestOption]').css("border", "1px solid #FF0000");
                    $('[id$=txtTestOption]').focus(function () {
                        $('[id$=txtTestOption]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtTestOption]').val() != "") {
                    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                    if (!regex.test($('[id$=txtTestOption]').val())) {
                        $('[id$=lblerror]').css("display", "block");
                        $('[id$=lblerror]').html("Some special character not allow");
                        $('[id$=txtTestOption]').css("border", "1px solid #FF0000");
                        $('[id$=txtTestOption]').focus(function () {
                            $('[id$=txtTestOption]').css("border", "1px solid #000000");
                            $('[id$=lblerror]').css("display", "none");
                        });
                        return false;
                    }
                }
            });

        });
    </script>
    <script type="text/javascript">
        function Validate(event) {
            var regex = new RegExp(/^[ A-Za-z0-9_@./#&$+-]*$/);
            var key = String.fromCharCode(event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
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
    <h2>Exam Config</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active mtop30" id="examManageQues">
            <asp:Panel ID="Panel1" runat="server">
                <div class="">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-3 control-label">Exam Code:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtExamCode" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword3" class="col-sm-3 control-label">Exam Title:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtExamtitle" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword3" class="col-sm-3 control-label">Category:</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="drpTopCategory" runat="server" class="form-control" OnSelectedIndexChanged="drpTopCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="drpSecondCategory" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-3 control-label">Passing Percentage:</label>
                            <div class="col-sm-4">
                                <div class="row">
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtPassingPercentage" runat="server" class="form-control" TextMode="Number" onkeyup="CheckFirstChar(event.keyCode, this)" min="0" max="100"></asp:TextBox>
                                    </div>
                                    <label for="" class="col-sm-2 control-label">%</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-3 control-label">Test Time (Min):</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtTestTime" runat="server" class="form-control" TextMode="Number" onkeyup="CheckFirstChar(event.keyCode, this)" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-3 control-label">Test Option:</label>
                            <div class="col-sm-6">
                                <label for="" class="col-sm-3 control-label">Random</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtTestOption" runat="server" class="form-control" TextMode="Number" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                                <label for="" class="col-sm-3 control-label">Questions</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-3 control-label">Valid Date:</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtdate" runat="server" TextMode="Date" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">
                                <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                            </div>
                            <div class="col-sm-offset-3 col-sm-3">
                                <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-default" OnClick="lnkbtnAdd_Click">Add</asp:LinkButton>
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click" Visible="false" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="btnReset_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="">
                <div class="salseReport">
                    <asp:GridView ID="gvExamDetail" runat="server" AutoGenerateColumns="false" class="table" DataKeyNames="ExamCodeId" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdexamId" runat="server" Value='<%#Eval("ExamCodeId")%>' />
                                </ItemTemplate>

                                <HeaderStyle CssClass="hide"></HeaderStyle>

                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Exam Title" DataField="ExamTitle" />
                            <asp:TemplateField HeaderText="Category">
                                <ItemTemplate>
                                    <%#Eval("TopCategoryName") %>/<%#Eval("SecondCategoryName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Passing Percentage">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassingPercentage" runat="server" Text=' <%# string.Format("{0:f0}{1}", Eval("PassingPercentage"),"%")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                            <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
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
