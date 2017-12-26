<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantUserGroup.aspx.cs" Inherits="WebMerchant.MerchantUserGroup" %>

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
                if ($('[id$=txtGroupName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter GroupName");
                    $('[id$=txtGroupName]').css("border", "1px solid #FF0000");
                    $('[id$=txtGroupName]').focus(function () {
                        $('[id$=txtGroupName]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=ddlTopCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select TopCategory");
                    $('[id$=ddlTopCategory]').css("border", "1px solid #FF0000");
                    $('[id$=ddlTopCategory]').focus(function () {
                        $('[id$=ddlTopCategory]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }

                if ($('[id$=ddlSecondCategory]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Second Category");
                    $('[id$=ddlSecondCategory]').css("border", "1px solid #FF0000");
                    $('[id$=ddlSecondCategory]').focus(function () {
                        $('[id$=ddlSecondCategory]').css("border", "1px solid #000000");
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add User Group</h2>
    <hr />
    <asp:Panel ID="pnlusergroup" runat="server">
        <div class="tab-content">
            <div class="tab-pane active" id="myUser">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Group Name</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Category:</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlTopCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTopCategory_SelectedIndexChanged"></asp:DropDownList>
                                    <div class="mtop10">
                                        <asp:CheckBox ID="chkAll" Text="Check All" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlSecondCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSecondCategory_SelectedIndexChanged"></asp:DropDownList>
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
                                <label for="" class="col-sm-3 control-label">Access Option:</label>
                                <div class="col-sm-5">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:CheckBoxList ID="chklistAccessoption" runat="server" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="clearfix col-sm-12 mtop10">
                        <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="GroupId" AllowPaging="True" OnPageIndexChanging="gvGroup_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Group Id" DataField="GroupId" Visible="false" />
                                <asp:BoundField HeaderText="GroupName" DataField="GroupName" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("GroupId") %>' OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument='<%#Eval("GroupId") %>' OnClick="lnkbtnDelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
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
