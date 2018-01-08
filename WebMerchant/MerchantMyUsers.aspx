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

        $(function () {
            $("[id*=chklistAccessoptionGroup]").bind("click", function () {
                var CHKgrp = document.getElementById("<%=chklistAccessoptionGroup.ClientID%>");
                var checkboxgrp = CHKgrp.getElementsByTagName("input");
                if (checkboxgrp[2].checked) {
                    //alert("Selected = " + label[i].innerHTML + checkbox[i].value);
                    for (var i = 0; i < checkboxgrp.length; i++) {
                        if (checkboxgrp[i].value != 3) {
                            checkboxgrp[i].checked = false;
                            checkboxgrp[i].disabled = true;
                        }
                    }
                }
                else {
                    for (var i = 0; i < checkboxgrp.length; i++) {
                        if (checkboxgrp[i].value != 3) {
                            checkboxgrp[i].disabled = false;
                        }
                    }
                }
            });
        });


        $(function () {
            $("[id*=chklistAccessoption]").bind("click", function () {
                var CHK = document.getElementById("<%=chklistAccessoption.ClientID%>");
                var checkbox = CHK.getElementsByTagName("input");
                var label = CHK.getElementsByTagName("label");
                if (checkbox[2].checked) {
                    //alert("Selected = " + label[i].innerHTML + checkbox[i].value);
                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].value != 3) {
                            checkbox[i].checked = false;
                            checkbox[i].disabled = true;
                        }
                    }
                }
                else {
                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].value != 3) {
                            checkbox[i].disabled = false;
                        }
                    }
                }
            });
        });
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd]').click(function () {
                if ($('[id$=txtRealName]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter RealName");
                    $('[id$=txtRealName]').css("border", "1px solid #FF0000");
                    $('[id$=txtRealName]').focus(function () {
                        $('[id$=txtRealName]').css("border", "1px solid #000000");
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
                } if ($('[id$=txtEmailAddress]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Email Id");
                    $('[id$=txtEmailAddress]').css("border", "1px solid #FF0000");
                    $('[id$=txtEmailAddress]').focus(function () {
                        $('[id$=txtEmailAddress]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if (!ValidateEmail($('[id$=txtEmailAddress]').val())) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Valid Email Id");
                    $('[id$=txtEmailAddress]').css("border", "1px solid #FF0000");
                    $('[id$=txtEmailAddress]').focus(function () {
                        $('[id$=txtEmailAddress]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=ddlStudnetGroup]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Student Group");
                    $('[id$=ddlStudnetGroup]').css("border", "1px solid #FF0000");
                    $('[id$=ddlStudnetGroup]').focus(function () {
                        $('[id$=ddlStudnetGroup]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
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
                //if ($('[id$=ddlCategory]').val() == null) {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Please Select Category");
                //    $('[id$=ddlCategory]').css("border", "1px solid #FF0000");
                //    $('[id$=ddlCategory]').focus(function () {
                //        $('[id$=ddlCategory]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}
                //if ($('[id$=ddlSecondCategory]').val() == null) {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Please Select Second Category");
                //    $('[id$=ddlSecondCategory]').css("border", "1px solid #FF0000");
                //    $('[id$=ddlSecondCategory]').focus(function () {
                //        $('[id$=ddlSecondCategory]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}

                <%--var checkBoxList = document.getElementById("<%=chkExamCodeList.ClientID %>");
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
                }--%>
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
    <script type="text/javascript">
        $(function () {
            $("[id*=chkAllGroup]").bind("click", function () {
                if ($(this).is(":checked")) {
                    $("[id*=chkExamCodeListGroup] input").attr("checked", "checked");
                } else {
                    $("[id*=chkExamCodeListGroup] input").removeAttr("checked");
                }
            });
            $("[id*=chkExamCodeListGroup] input").bind("click", function () {
                if ($("[id*=chkExamCodeListGroup] input:checked").length == $("[id*=chkExamCodeListGroup] input").length) {
                    $("[id*=chkAllGroup]").attr("checked", "checked");
                } else {
                    $("[id*=chkAllGroup]").removeAttr("checked");
                }
            });
        });


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAddGroup]').click(function () {
                if ($('[id$=txtGroupName]').val() == "") {
                    $('[id$=lblerrorGroup]').css("display", "block");
                    $('[id$=lblerrorGroup]').html("Please Enter GroupName");
                    $('[id$=txtGroupName]').css("border", "1px solid #FF0000");
                    $('[id$=txtGroupName]').focus(function () {
                        $('[id$=txtGroupName]').css("border", "1px solid #000000");
                        $('[id$=lblerrorGroup]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=ddlTopCategoryGruop]').val() == null) {
                    $('[id$=lblerrorGroup]').css("display", "block");
                    $('[id$=lblerrorGroup]').html("Please Select TopCategory");
                    $('[id$=ddlTopCategoryGruop]').css("border", "1px solid #FF0000");
                    $('[id$=ddlTopCategoryGruop]').focus(function () {
                        $('[id$=ddlTopCategoryGruop]').css("border", "1px solid #000000");
                        $('[id$=lblerrorGroup]').css("display", "none");
                    });
                    return false;
                }

                if ($('[id$=ddlSecondCategoryGroup]').val() == null) {
                    $('[id$=lblerrorGroup]').css("display", "block");
                    $('[id$=lblerrorGroup]').html("Please Select Second Category");
                    $('[id$=ddlSecondCategoryGroup]').css("border", "1px solid #FF0000");
                    $('[id$=ddlSecondCategoryGroup]').focus(function () {
                        $('[id$=ddlSecondCategoryGroup]').css("border", "1px solid #000000");
                        $('[id$=lblerrorGroup]').css("display", "none");
                    });
                    return false;
                }

                <%--var checkBoxList = document.getElementById("<%=chkExamCodeListGroup.ClientID %>");
                var checkboxes = checkBoxList.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxes.length; i++) {
                    if (checkboxes[i].checked) {
                        isValid = true;
                        $('[id$=chkExamCodeListGroup]').css("border", "none");
                        $('[id$=lblerrorGroup]').css("display", "none");
                        break;
                    }
                    else if (i == (checkboxes.length - 1)) {

                        $('[id$=lblerrorGroup]').css("display", "block");
                        $('[id$=lblerrorGroup]').html("Please Select Atlest one Exam");
                        $('[id$=chkExamCodeListGroup]').css("border", "1px solid #FF0000");
                        $('[id$=chkExamCodeListGroup]').focus(function () {
                            $('[id$=chkExamCodeListGroup]').css("border", "1px solid #000000");
                            $('[id$=lblerrorGroup]').css("display", "none");
                        });
                        return false;
                    }
                }--%>

                <%--var checkBoxList2 = document.getElementById("<%=chklistAccessoptionGroup.ClientID %>");
                var checkboxes2 = checkBoxList2.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxes2.length; i++) {
                    if (checkboxes2[i].checked) {
                        isValid = true;
                        $('[id$=chklistAccessoptionGroup]').css("border", "none");
                        $('[id$=lblerrorGroup]').css("display", "none");
                        break;
                    }
                    else if (i == (checkboxes2.length - 1)) {

                        $('[id$=lblerrorGroup]').css("display", "block");
                        $('[id$=lblerrorGroup]').html("Please Select Access Option");
                        $('[id$=chklistAccessoptionGroup]').css("border", "1px solid #FF0000");
                        $('[id$=chklistAccessoptionGroup]').focus(function () {
                            $('[id$=chklistAccessoptionGroup]').css("border", "1px solid #000000");
                            $('[id$=lblerrorGroup]').css("display", "none");
                        });
                        return false;
                    }
                }--%>
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
    <div>
        <div>
            <asp:Button Text="Add New User" BorderStyle="None" ID="Tab_1" CssClass="Initial" runat="server"
                OnClick="Tab1_Click" />
            <asp:Button Text="Add User Group" BorderStyle="None" ID="Tab_2" CssClass="Initial" runat="server"
                OnClick="Tab2_Click" />
        </div>
        <div style="background-color: #fff; border: solid 1px">
            <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:Panel ID="pnlMyuser" runat="server" CssClass="pnlcls">
                        <div class="tab-content">
                            <div class="tab-pane active" id="myUser">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Real Name:</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox ID="txtRealName" runat="server" CssClass="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Access Password:</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Email Address:</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Student Group:</label>
                                                <div class="col-sm-3">
                                                    <asp:DropDownList ID="ddlStudnetGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStudnetGroup_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Valid Time:</label>
                                                <div class="col-sm-3">
                                                    <asp:TextBox ID="txtValidTime" runat="server" CssClass="form-control" TextMode="DateTimeLocal" onkeyup="CheckFirstChar(event.keyCode, this)" Style="padding: 6px 6px;"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-1">
                                                    To
                                                </div>
                                                <div class="col-sm-3">
                                                    <asp:TextBox ID="txtValidTimeto" runat="server" CssClass="form-control" TextMode="DateTimeLocal" onkeyup="CheckFirstChar(event.keyCode, this)" Style="padding: 6px 6px;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <asp:Panel ID="pnlgroupsection" runat="server" Visible="false">
                                                <div class="form-group">
                                                    <label for="" class="col-sm-3 control-label">Category:</label>
                                                    <div class="col-sm-2">
                                                        <asp:DropDownList ID="ddlTopCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTopCategory_SelectedIndexChanged"></asp:DropDownList>
                                                        <div class="mtop10">
                                                            <asp:CheckBox ID="chkAll" Text="Select All" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <asp:DropDownList ID="ddlSecondCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSecondCategory_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="" class="col-sm-3 control-label">Exam:</label>
                                                    <div class="col-sm-3">
                                                        <div style="overflow-y: scroll; width: 550px; height: 125px">
                                                            <asp:CheckBoxList ID="chkExamCodeList" runat="server" RepeatColumns="4" CssClass="chktable">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="" class="col-sm-3 control-label">Access Option:</label>
                                                    <div class="col-sm-5">
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <asp:CheckBoxList ID="chklistAccessoption" runat="server" RepeatDirection="Horizontal" CssClass="chktable">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                            <div class="col-sm-3">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                                </div>
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click">Add</asp:LinkButton>
                                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="btnReset_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Panel ID="pnlusergroup" runat="server" CssClass="pnlcls">
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
                                                    <asp:DropDownList ID="ddlTopCategoryGruop" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTopCategoryGruop_SelectedIndexChanged"></asp:DropDownList>
                                                    <div class="mtop10">
                                                        <asp:CheckBox ID="chkAllGroup" Text="Check All" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:DropDownList ID="ddlSecondCategoryGroup" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSecondCategoryGroup_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Exam:</label>
                                                <div class="col-sm-3">
                                                    <div style="overflow-y: scroll; width: 550px; height: 125px">
                                                        <asp:CheckBoxList ID="chkExamCodeListGroup" runat="server" RepeatColumns="4" CssClass="chktable">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="form-group">
                                                <label for="" class="col-sm-3 control-label">Access Option:</label>
                                                <div class="col-sm-5">
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <asp:CheckBoxList ID="chklistAccessoptionGroup" runat="server" RepeatDirection="Horizontal" CssClass="chktable">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <label id="lblerrorGroup" runat="server" style="display: none; color: #D8000C;"></label>
                                                </div>
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <asp:LinkButton ID="lnkbtnAddGroup" runat="server" CssClass="btn btn-default" OnClick="btnAddGroup_Click">Add</asp:LinkButton>
                                                    <asp:Button ID="btnResetGroup" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="btnResetGroup_Click" />
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
                                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("GroupId") %>' OnClick="lnkbtnEditGroup_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument='<%#Eval("GroupId") %>' OnClick="lnkbtnDeleteGroup_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
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
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="row">
        <div class="clearfix col-sm-12 mtop10">
            <asp:GridView ID="gvMyUser" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="UserId" OnRowDataBound="gvMyUser_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvMyUser_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="User Id" DataField="UserId" Visible="false" />
                    <asp:BoundField HeaderText="Login Email" DataField="EmailId" />
                    <asp:BoundField HeaderText="Access Password" DataField="AccessPassword" />
                    <asp:TemplateField HeaderText="ValidTime">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "ValidTime")%>
                    -
                    <%# DataBinder.Eval(Container.DataItem, "ValidTimeTo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ExamCode" DataField="ExamCode" />
                    <asp:BoundField HeaderText="Access Option" DataField="AccsessOptionval" />
                    <asp:BoundField HeaderText="RealName" DataField="UserName" />
                    <asp:BoundField HeaderText="Access Group" DataField="GroupName" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnEdit" runat="server" CommandArgument='<%#Eval("UserId") %>' OnClick="lnkbtnEdit_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
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
