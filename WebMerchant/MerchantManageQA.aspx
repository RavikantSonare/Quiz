<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantManageQA.aspx.cs" Inherits="WebMerchant.MerchantManageQA" ValidateRequest="false" EnableEventValidation="false" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnAdd], [id$=btnMultiAdd], [id$=btnVacantAdd], [id$=btnHotspotAdd], [id$=btnDragdropAdd],[id$=btnScenarioAdd]').click(function () {
                if ($('[id$=ddlExamCode]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Exam ");
                    $('[id$=ddlExamCode]').css("border", "1px solid #FF0000");
                    if ($('[id$=ddlExamCode]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=ddlExamCode]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please select exam</div>");
                    }
                    $('[id$=ddlExamCode]').focus(function () {
                        $('[id$=ddlExamCode]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                } else {
                    $('[id$=ddlExamCode]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=ddlQuestionType]').val() == null) {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Select Type");
                    $('[id$=ddlQuestionType]').css("border", "1px solid #FF0000");
                    if ($('[id$=ddlQuestionType]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=ddlQuestionType]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please select type</div>");
                    }
                    $('[id$=ddlQuestionType]').focus(function () {
                        $('[id$=ddlQuestionType]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                } else {
                    $('[id$=ddlQuestionType]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=txtScore]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Score");
                    $('[id$=txtScore]').css("border", "1px solid #FF0000");
                    if ($('[id$=txtScore]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=txtScore]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter score</div>");
                    }
                    $('[id$=txtScore]').focus(function () {
                        $('[id$=txtScore]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                } else {
                    $('[id$=txtScore]').parent().next(".validation").remove(); // remove it
                }
                if ($('[id$=ftxtQuestion]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Question");
                    $('[id$=ftxtQuestion]').css("border", "1px solid #FF0000");
                    if ($('[id$=ftxtQuestion]').parent().next(".validation").length == 0) // only add if not added
                    {
                        $('[id$=ftxtQuestion]').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter question</div>");
                    }
                    $('[id$=ftxtQuestion]').focus(function () {
                        $('[id$=ftxtQuestion]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                else {
                    $('[id$=ftxtQuestion]').parent().next(".validation").remove(); // remove it
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Question</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="manageQues">
            <div class="row">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="col-sm-12">
                        <div class="form-horizontal mtop30">

                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Exam Code:</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlExamCode" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnImport" runat="server" Text="Import Questions" CssClass="btn btn-default" OnClick="btnImport_Click" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Question Type:</label>
                                <div class="col-sm-2">
                                    <div class="mtop10">
                                        <asp:DropDownList ID="ddlQuestionType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestionType_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Score:</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txtScore" runat="server" CssClass="form-control" TextMode="Number" min="1" max="100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Question</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="summernote form-control"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="prevVaile" />
                                    <asp:HiddenField runat="server" ID="hftxtquestion" />
                                </div>
                            </div>
                            <asp:Panel ID="pnlSingleSelect" runat="server" Visible="false">
                                <asp:PlaceHolder runat="server" ID="ctrlPlaceholderTextBox"></asp:PlaceHolder>
                            </asp:Panel>
                            <asp:Panel ID="pnlHotspot" runat="server" Visible="false">
                                <link href="img_mapjs/main.css" rel="stylesheet" />
                                <%-- <noscript>
    <div id="noscript">
        Please, enable javascript in your browser
    </div>
</noscript>--%>

                                <div id="wrapper">
                                    <header id="header">
                                        <nav id="nav" class="clearfix">
                                            <ul>
                                                <li id="save" style="display: none;"><a href="#">save</a></li>
                                                <li id="load" style="display: none;"><a href="#">load</a></li>
                                                <li id="from_html" style="display: none;"><a href="#">from html</a></li>
                                                <li id="rectangle"><a href="#">rectangle</a></li>
                                                <li id="circle" style="display: none;"><a href="#">circle</a></li>
                                                <li id="polygon" style="display: none;"><a href="#">polygon</a></li>
                                                <li id="edit"><a href="#">edit</a></li>
                                                <li id="to_html"><a href="#">to html</a></li>
                                                <li id="preview" style="display: none;"><a href="#">preview</a></li>
                                                <li id="clear"><a href="#">clear</a></li>
                                                <li id="new_image"><a href="#">new image</a></li>
                                                <li id="show_help" style="display: none;"><a href="#">?</a></li>
                                            </ul>
                                        </nav>
                                        <div id="coords"></div>
                                        <div id="debug"></div>
                                    </header>
                                    <div id="image_wrapper">
                                        <div id="image">
                                            <asp:HiddenField ID="hdimage" runat="server" />
                                            <img src="" alt="#" id="img" />
                                            <svg xmlns="http://www.w3.org/2000/svg" version="1.2" baseProfile="tiny" id="svg"></svg>
                                        </div>
                                    </div>
                                </div>

                                <!-- For html image map code -->
                                <div id="code" class="col-sm-offset-2">
                                    <span class="close_button" title="close"></span>
                                    <div id="code_content" runat="server"></div>
                                    <asp:TextBox ID="txtmaphtml" runat="server" Style="display: none;"></asp:TextBox>
                                    <asp:TextBox ID="txtimage" runat="server" Style="display: none;"></asp:TextBox>
                                </div>

                                <!-- Edit details block -->
                                <div id="edit_details">
                                    <h5>Attributes</h5>
                                    <span class="close_button" title="close"></span>
                                    <p>
                                        <label for="href_attr">href</label>
                                        <input type="text" id="href_attr" />
                                    </p>
                                    <p>
                                        <label for="alt_attr">alt</label>
                                        <input type="text" id="alt_attr" />
                                    </p>
                                    <p>
                                        <label for="title_attr">title</label>
                                        <input type="text" id="title_attr" />
                                    </p>
                                    <button id="save_details">Save</button>
                                </div>

                                <!-- From html block -->
                                <div id="from_html_wrapper">
                                    <form id="from_html_form">
                                        <h5>Loading areas</h5>
                                        <span class="close_button" title="close"></span>
                                        <p>
                                            <label for="code_input">Enter your html code:</label>
                                            <textarea id="code_input"></textarea>
                                        </p>
                                        <button id="load_code_button">Load</button>
                                    </form>
                                </div>

                                <!-- Get image form -->
                                <div id="get_image_wrapper">
                                    <div id="get_image">
                                        <span title="close" class="close_button"></span>
                                        <div id="loading">Loading</div>
                                        <div id="file_reader_support">
                                            <label>Drag an image</label>
                                            <div id="dropzone">
                                                <span class="clear_button" title="clear">x</span>
                                                <img src="" alt="preview" id="sm_img" />
                                            </div>
                                            <b>or</b>
                                        </div>
                                        <div style="display: none;">
                                            <label for="url">type a url</label>
                                            <span id="url_wrapper">
                                                <span class="clear_button" title="clear">x</span>
                                                <input type="text" id="url" />
                                            </span>
                                        </div>
                                        <button id="button" class="btn btn-primary">OK</button>
                                    </div>
                                </div>

                                <!-- Help block -->
                                <div id="overlay"></div>
                                <div id="help">
                                    <span class="close_button" title="close"></span>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3" id="divHotspot">
                                    </div>
                                </div>
                                <script src="img_mapjs/summerHTMLImageMapCreator.js"></script>
                            </asp:Panel>
                            <asp:Panel ID="pnladdAnswertxtbox" runat="server" Visible="false">
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-3">
                                        <asp:Button ID="btnAddAnswerSingle" runat="server" Text="Add Answer" CssClass="btn btn-default" OnClick="btnAddAnswerSingle_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlETS" runat="server">
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-5">
                                        <label class="btn-bs-file btn btn-default">
                                            Exhibit
                                          <asp:FileUpload ID="fuSingleExhibit" runat="server" />
                                        </label>
                                        <label class="btn-bs-file btn btn-default">
                                            Topology
                                          <asp:FileUpload ID="fuSingleTopology" runat="server" />
                                        </label>
                                        <label class="btn-bs-file btn btn-default">
                                            Scenario
                                          <asp:FileUpload ID="fuSingleScenario" runat="server" />
                                        </label>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">Explanation</label>
                                <div class="col-sm-9">
                                    <asp:HiddenField ID="hfExhibit" runat="server" />
                                    <asp:HiddenField ID="hfTopology" runat="server" />
                                    <asp:HiddenField ID="hfScenario" runat="server" />
                                    <asp:HiddenField ID="hftxtExplanation" runat="server" />
                                    <asp:TextBox ID="txtExplanation" runat="server" CssClass="summernote form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-3">
                                    <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="btn btn-default" OnClick="btnAdd_Click">Add</asp:LinkButton>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click" ValidationGroup="single" Visible="false" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="btnReset_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-3 col-sm-9" style="display: none;">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label">Exam code:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-5">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="row">
                <div class="clearfix col-sm-12 mtop10" style="max-height: 400px; overflow-y: scroll;">
                    <asp:GridView ID="gvQuestionManage" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="QAId" OnPageIndexChanging="gvQuestionManage_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Question">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Question")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="QuestionType" HeaderText="Question Type" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%#Eval("QAId")%>' OnClick="lbtnEdit_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%#Eval("QAId")%>' OnClick="lbtnDelete_Click" OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
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
    <script>
        $(document).on("click", "#ContentPlaceHolder1_btnAdd", function () {
            $("#preview").trigger("click");
        });
    </script>
</asp:Content>
