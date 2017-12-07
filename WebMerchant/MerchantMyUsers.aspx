<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantMyUsers.aspx.cs" Inherits="WebMerchant.MerchantMyUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                if ($(this).is(":checked")) {
                    $("[id*=chkExamCodeList] input").attr("checked", "checked");
                } else {
                    $("[id*=chkExamCodeList] input").removeAttr("checked");
                }
            });
            $("[id*=chkExamCodeList] input").bind("click", function () {
                if ($("[id*=chkExamCodeList] input:checked").length == $("[id*=chkExamCodeList] input").length) {
                    $("[id*=chkAll]").attr("checked", "checked");
                } else {
                    $("[id*=chkAll]").removeAttr("checked");
                }
            });
        });
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtUserName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter UserName");
                    $('[id$=txtUserName]').css("border", "1px solid #FF0000");
                    $('[id$=txtUserName]').focus(function () {
                        $('[id$=txtUserName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                } if (!ValidateEmail($('[id$=txtUserName]').val())) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Valid Email Id");
                    $('[id$=txtUserName]').css("border", "1px solid #FF0000");
                    $('[id$=txtUserName]').focus(function () {
                        $('[id$=txtUserName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtPassword]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Password");
                    $('[id$=txtPassword]').css("border", "1px solid #FF0000");
                    $('[id$=txtPassword]').focus(function () {
                        $('[id$=txtPassword]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=ddlCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Category");
                    $('[id$=ddlCategory]').css("border", "1px solid #FF0000");
                    $('[id$=ddlCategory]').focus(function () {
                        $('[id$=ddlCategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

                var checkBoxList = document.getElementById("<%=chkExamCodeList.ClientID %>");
                var checkboxes = checkBoxList.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxes.length; i++) {
                    if (checkboxes[i].checked) {
                        isValid = true;
                        $('[id$=chkExamCodeList]').css("border", "none");
                        $('[id$=lblerror]').css("display", "none");
                        break;
                    }
                    else if (i == (checkboxes.length - 1)) {

                        $('[id$=lblerror]').css("display", "block");
                        $('[id$=lblerror]').html("Please Select Atlest one Exam");
                        $('[id$=chkExamCodeList]').css("border", "1px solid #FF0000");
                        $('[id$=chkExamCodeList]').focus(function () {
                            $('[id$=chkExamCodeList]').css("border", "1px solid #000000");
                            $('[id$=lblerror]').css("display", "none");
                        });
                        return false;
                    }
                }

                if ($('[id$=txtValidTime]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Valid DateTime");
                    $('[id$=txtValidTime]').css("border", "1px solid #FF0000");
                    $('[id$=txtValidTime]').focus(function () {
                        $('[id$=txtValidTime]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtValidTimeto]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Valid DateTime");
                    $('[id$=txtValidTimeto]').css("border", "1px solid #FF0000");
                    $('[id$=txtValidTimeto]').focus(function () {
                        $('[id$=txtValidTimeto]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

                var checkBoxList2 = document.getElementById("<%=chklistAccessoption.ClientID %>");
                var checkboxes2 = checkBoxList2.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxes2.length; i++) {
                    if (checkboxes2[i].checked) {
                        isValid = true;
                        $('[id$=chklistAccessoption]').css("border", "none");
                        $('[id$=lblerror]').css("display", "none");
                        break;
                    }
                    else if (i == (checkboxes2.length - 1)) {

                        $('[id$=lblerror]').css("display", "block");
                        $('[id$=lblerror]').html("Please Select Access Option");
                        $('[id$=chklistAccessoption]').css("border", "1px solid #FF0000");
                        $('[id$=chklistAccessoption]').focus(function () {
                            $('[id$=chklistAccessoption]').css("border", "1px solid #000000");
                            $('[id$=lblerror]').css("display", "none");
                        });
                        return false;
                    }
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

        function ValidateEmail(email) {
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Users</h2>
    <hr />
    <asp:Panel ID="pnlMyuser" runat="server">
        <div class="tab-content">
            <div class="tab-pane active" id="myUser">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Email Id (User Name):</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Access Password:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Category:</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                    <div class="mtop10">
                                        <asp:CheckBox ID="chkAll" Text="Select All" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Exam:</label>
                                <div class="col-sm-3">
                                    <div style="overflow-y: scroll; width: 200px; height: 125px">
                                        <asp:CheckBoxList ID="chkExamCodeList" runat="server">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Valid Time:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtValidTime" runat="server" class="form-control" TextMode="DateTimeLocal" onkeyup="CheckFirstChar(event.keyCode, this)" Style="padding: 6px 6px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-1">
                                    To
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtValidTimeto" runat="server" class="form-control" TextMode="DateTimeLocal" onkeyup="CheckFirstChar(event.keyCode, this)" Style="padding: 6px 6px;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Access Option:</label>
                                <div class="col-sm-5">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <asp:CheckBoxList ID="chklistAccessoption" runat="server">
                                                <asp:ListItem Text="Online" Value="Online" />
                                                <asp:ListItem Text="Offline" Value="Offline" />
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="col-sm-3">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-default" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-default" OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="clearfix col-sm-12 mtop10">
                        <asp:GridView ID="gvMyUser" runat="server" AutoGenerateColumns="false" class="table" DataKeyNames="UserId" OnRowDataBound="gvMyUser_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvMyUser_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="User Id" DataField="UserId" Visible="false" />
                                <asp:BoundField HeaderText="UserName/RealName" DataField="UserName" />
                                <asp:BoundField HeaderText="AccessPassword" DataField="AccessPassword" />
                                <asp:BoundField HeaderText="ExamCode" DataField="ExamCode" />
                                <asp:TemplateField HeaderText="ValidTime">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "ValidTime")%>
                    -
                    <%# DataBinder.Eval(Container.DataItem, "ValidTimeTo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="AccessOption" DataField="AccessOption" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("UserId") %>' OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument='<%#Eval("UserId") %>' OnClick="lnkbtnDelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
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
    </asp:Panel>
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
