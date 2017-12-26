<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantMyExams.aspx.cs" Inherits="WebMerchant.MerchantMyExams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hidecolumn {
            display: none;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAddBundle]').click(function () {
                if ($('[id$=txtContent]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Content");
                    $('[id$=txtContent]').css("border", "1px solid #FF0000");
                    $('[id$=txtContent]').focus(function () {
                        $('[id$=txtContent]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                if ($('[id$=txtPrice]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Price");
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
    <h2>My Exams List</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="myExam">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-lg-3">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                </div>
                <div class="col-lg-12" style="height: 200px; overflow-y: scroll">
                    <asp:GridView ID="gvExamDetail" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvExamDetail_PageIndexChanging" DataKeyNames="ExamCodeId">
                        <Columns>
                            <asp:TemplateField HeaderText="Review" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnReview" runat="server" PostBackUrl='<%# String.Format("~/MerchantMyExams.aspx?exid={0}", Eval("ExamCodeId"))%>'>Review</asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdexamId" runat="server" Value='<%#Eval("ExamCodeId")%>' />
                                </ItemTemplate>

                                <HeaderStyle CssClass="hide"></HeaderStyle>

                                <ItemStyle CssClass="hide"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Exam Code" DataField="ExamCode" />
                            <asp:BoundField HeaderText="Exam Title" DataField="ExamTitle" />
                            <asp:BoundField HeaderText="Category" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="Test Time" DataField="TestTime" />
                            <asp:BoundField HeaderText="Valid Date" DataField="ValidDate" DataFormatString="{0:yyyy/MM/dd}" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Exam Simulator" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnGenerateExamSimulator" runat="server" CommandArgument='<%#Eval("ExamSimulator") %>' OnClick="lnkbtnGenerateExamSimulator_Click">Generate</asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exam Simulator Demo" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnGenerateExamSimulatorDemo" runat="server" CommandArgument='<%#Eval("ExamSimulatorDemo") %>' OnClick="lnkbtnGenerateExamSimulatorDemo_Click">Generate</asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Only Test Once" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnOnlyTestOnce" runat="server" CommandArgument='<%#Eval("OnlyTestOnce") %>' OnClick="lnkbtnOnlyTestOnce_Click"><%# (Boolean.Parse(Eval("OnlyTestOnce").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Print" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowprint" runat="server" CommandArgument='<%#Eval("AllowPrint") %>' OnClick="lnkbtnallowprint_Click"><%# (Boolean.Parse(Eval("AllowPrint").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allow Sales" HeaderStyle-CssClass="hidecolumn" ItemStyle-CssClass="hidecolumn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnallowsales" runat="server" OnClick="lnkbtnallowsales_Click" CommandArgument='<%#Eval("ExamCodeId")%>'><%# (Boolean.Parse(Eval("AllowSales").ToString())) ? "Yes" : "No" %></asp:LinkButton>
                                </ItemTemplate>

                                <HeaderStyle CssClass="hidecolumn"></HeaderStyle>

                                <ItemStyle CssClass="hidecolumn"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Config">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnexconfig" CssClass="clickvalue" myexmid='<%#Eval("ExamCodeId")%>' runat="server" CommandArgument='<%#Eval("ExamCodeId")%>' data-toggle="modal" data-target="#contact" data-original-title>Config</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Featured in selfs estore" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkfeatureestore" runat="server" />
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClick="btnExamdelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row mtop30">
                <h4>Bundle Exam Promotion</h4>
                <div class="col-lg-12">
                    <asp:Panel ID="pnlbundle" runat="server">
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="">Content:</label>
                                <asp:TextBox ID="txtContent" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">Price:</label>
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">Featured in self estore:</label>
                                <asp:CheckBox ID="chkfeatureestore" runat="server" />
                            </div>
                            <asp:Button ID="btnAddBundle" runat="server" Text="Add" class="btn btn-default" OnClick="btnAddBundle_Click" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-lg-12" style="height: 200px; overflow-y: scroll">
                    <asp:GridView ID="gridBundle" runat="server" class="table merchantLogin-table mtop10" AutoGenerateColumns="false" AllowPaging="True" DataKeyNames="BundleId">
                        <Columns>
                            <asp:BoundField HeaderText="Content" DataField="BundleContent" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnBundleEdit" runat="server" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');" OnClick="lnkbtnBundleEdit_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnBundleDelete" runat="server" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');" OnClick="lnkbtnBundleDelete_Click">Delete</asp:LinkButton>
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
    <script type="text/javascript">
        function getConfirmation(sender, title, message) {
            $("#spnTitle").text(title);
            $("#spnMsg").text(message);
            $('#modalPopUp').modal('show');
            var val = $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }

        $(document).ready(function () {
            $(".clickvalue").click(function () {
                var customID = $(this).attr('myexmid');
                $("#ContentPlaceHolder1_hfexamid").val(customID);
            });
        });
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
    <div class="row">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <%-- <a class="btn btn-primary btn-lg" data-toggle="modal" data-target="#vote" data-original-title>Vote Now!
        </a>
        <a class="btn btn-primary btn-lg" data-toggle="modal" data-target="#contact" data-original-title>Contact
        </a>--%>
        <div class="modal fade" id="contact" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="contactLabel">Estore Config</h4>
                    </div>
                    <div>
                        <div class="modal-body" style="padding: 5px;">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4" style="padding-bottom: 10px;">
                                    <label for="lblquestionno">Question Number</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-8" style="padding-bottom: 10px;">
                                    <asp:TextBox ID="txtQuestionno" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4" style="padding-bottom: 10px;">
                                    <label for="lblprice">Price</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-8" style="padding-bottom: 10px;">
                                    <asp:TextBox ID="txtEstoreExamPrice" TextMode="Number" min="0" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4" style="padding-bottom: 10px;">
                                    <label for="lblexampicture">Exam Picture</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-8" style="padding-bottom: 10px;">
                                    <asp:FileUpload ID="fuexampicture" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4">
                                    <label for="lblexamdescription">Exam Description</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-8" style="padding-bottom: 10px;">
                                    <asp:TextBox ID="txtExamDescription" TextMode="MultiLine" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="margin-bottom: -14px;">
                            <asp:HiddenField ID="hfexamid" runat="server" />
                            <asp:Button ID="btnestoreconfig" runat="server" Text="Add" CssClass="btn btn-success" />
                            <%-- <input type="submit" class="btn btn-success" value="Send" />
                            <!--<span class="glyphicon glyphicon-ok"></span>-->
                            <button style="float: right;" type="button" class="btn btn-default btn-close" data-dismiss="modal">Close</button>--%>
                        </div>

                        <script type="text/javascript">
                            //$(document).ready(function () {
                            $('#ContentPlaceHolder1_btnestoreconfig').click(function () {
                                var Questiono = $.trim($('#<%=txtQuestionno.ClientID %>').val());
                                var Price = $.trim($('#<%=txtEstoreExamPrice.ClientID %>').val());
                                var ExamPic = $.trim($('#<%=fuexampicture.ClientID %>').val());
                                var ExamDes = $.trim($('#<%=txtExamDescription.ClientID %>').val());
                                //$.ajax({
                                //    type: 'POST',
                                //    contentType: "application/json; charset=utf-8",
                                //    url: 'MerchantMyExams.aspx/InsertConfigData',
                                //    //  data: "{'Name':'" + Name + "', 'LName':'" + LName + "'}",
                                //    //async: false,
                                //    success: function (response) {
                                //        $('#txtUserName').val('');
                                //        $('#txtEmail').val('');
                                //        alert("Record Has been Saved in Database");
                                //    },
                                //    error: function () {
                                //        console.log('there is some error');
                                //    }
                                //});
                                PageMethods.InsertConfigData(Questiono, Price, ExamPic, ExamDes);
                            });
                            //  });
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
