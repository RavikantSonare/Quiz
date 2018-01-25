<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantCertificate.aspx.cs" Inherits="WebMerchant.MerchantCertificate" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=btnSave]').click(function () {
                //if ($('[id$=fuTemplatePicture]').val() == "") {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Please Select Image");
                //    $('[id$=fuTemplatePicture]').css("border", "1px solid #FF0000");
                //    $('[id$=fuTemplatePicture]').focus(function () {
                //        $('[id$=fuTemplatePicture]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}
                //var val = $('[id$=fuTemplatePicture]').val();
                //if (!val.match(/(?:gif|jpg|png|bmp)$/)) {
                //    $('[id$=lblerror]').css("display", "block");
                //    $('[id$=lblerror]').html("Input file path is not an image!");
                //    $('[id$=fuTemplatePicture]').css("border", "1px solid #FF0000");
                //    $('[id$=fuTemplatePicture]').focus(function () {
                //        $('[id$=fuTemplatePicture]').css("border", "1px solid #000000");
                //        $('[id$=lblerror]').css("display", "none");
                //    });
                //    return false;
                //}
                if ($('[id$=txtCertificateTitle]').val() == "") {
                    $('[id$=lblerror]').css("display", "block");
                    $('[id$=lblerror]').html("Please Enter Title");
                    $('[id$=txtCertificateTitle]').css("border", "1px solid #FF0000");
                    $('[id$=txtCertificateTitle]').focus(function () {
                        $('[id$=txtCertificateTitle]').css("border", "1px solid #000000");
                        $('[id$=lblerror]').css("display", "none");
                    });
                    return false;
                }
                //if ($('[id$=txtCertificateTitle]').val() != "") {
                //    var regex = new RegExp(/^[0-9a-zA-Z_@./#&$\_]+$/);
                //    if (!regex.test($('[id$=txtCertificateTitle]').val())) {
                //        $('[id$=lblerror]').css("display", "block");
                //        $('[id$=lblerror]').html("Some special character not allow");
                //        $('[id$=txtCertificateTitle]').css("border", "1px solid #FF0000");
                //        $('[id$=txtCertificateTitle]').focus(function () {
                //            $('[id$=txtCertificateTitle]').css("border", "1px solid #000000");
                //            $('[id$=lblerror]').css("display", "none");
                //        });
                //        return false;
                //    }
                //}
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
    <h2>Exam Reports</h2>
    <hr />
    <div class="tab-content">
        <div class="tab-pane active" id="examReport">
            <div class="row">
                <div class="col-sm-12 mtop30">
                    <asp:GridView ID="gvExamReport" runat="server" AutoGenerateColumns="false" class="table examreport-table" OnRowDataBound="gvExamReport_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvExamReport_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Exam Report Id" DataField="ExamReportId" Visible="false" />
                            <asp:TemplateField HeaderText="UserName">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUserName" runat="server" Text='<%#Eval("UserName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField HeaderText="UserName" DataField="UserName" />--%>
                            <asp:BoundField HeaderText="CategoryName" DataField="SecondCategoryName" />
                            <asp:BoundField HeaderText="ExamCode" DataField="ExamCode" />
                            <asp:TemplateField HeaderText="Result">
                                <ItemTemplate>
                                    <%# (Boolean.Parse(Eval("Result").ToString())) ? "Pass" : "Fail" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <ItemTemplate>
                                    <asp:Label ID="lblScore" runat="server" Text=' <%# string.Format("{0:f0}{1}", Eval("Score"),"%")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AllowPrint">
                                <ItemTemplate>
                                    <%# (Boolean.Parse(Eval("AllowPrint").ToString())) ? "Yes" : "No" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Digital Certificate">
                                <ItemTemplate>
                                    <asp:DropDownList ID="drpTemplate" runat="server" class="form-control"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn btn-default" Enabled='<%# (Boolean.Parse(Eval("Result").ToString()))%>' OnClick="btnGenerate_Click" CommandArgument='<%#Eval("ExamReportId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.#">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNo" runat="server" CssClass="form-control" Enabled='<%# (Boolean.Parse(Eval("Result").ToString()))%>' onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Option">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnresultdelete" runat="server" Visible='<%# (Convert.ToBoolean(Eval("Result"))==true? false:true) %>' CommandArgument='<%#Eval("ExamId")%>' OnClick="lnkbtnresultdelete_Click">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <h2>Record not found...</h2>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <asp:Panel ID="pnlCertificate" runat="server" Visible="false">
                    <link href="img_mapjs/main.css" rel="stylesheet" />
                    <div id="wrapper">
                        <header id="header">
                            <nav id="nav" class="clearfix">
                                <ul>
                                    <li id="save" style="display: none;"><a href="#">save</a></li>
                                    <li id="load" style="display: none;"><a href="#">load</a></li>
                                    <li id="from_html" style="display: none;"><a href="#">from html</a></li>
                                    <li id="rectangle"><a href="#">NameBox</a></li>
                                    <li id="rectangle1"><a href="#">DateBox</a></li>
                                    <li id="circle" style="display: none;"><a href="#">circle</a></li>
                                    <li id="polygon" style="display: none;"><a href="#">polygon</a></li>
                                    <li id="edit"><a href="#">edit</a></li>
                                    <li id="to_html" style="display: none;"><a href="#">to html</a></li>
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
                    <script src="img_mapjs/summerHTMLImageMapCreatorCertificate.js"></script>
                    <div class="col-sm-12">
                        <h5>Template Setting: For Eg.</h5>
                        <div class="form-horizontal">
                            <%--<div class="form-group">
                                <label for="" class="col-sm-2 control-label">Template Picture:</label>
                                <div class="col-sm-4">
                                    <asp:FileUpload ID="fuTemplatePicture" runat="server" class="form-control" accept="image/*" />
                                    <asp:Label ID="lblimg" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label">Certificate Title:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtCertificateTitle" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label">Name:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label">Date:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtDate" runat="server" class="form-control" onkeyup="CheckFirstChar(event.keyCode, this)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" style="display: none;">
                                <label for="" class="col-sm-2 control-label">Sample:</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblsamplemsg" runat="server" Text="Review for the picture which include 2 fields (UserName and Certificate Title)"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label"></label>
                                <div class="col-sm-10">
                                    <label id="lblerror" runat="server" style="display: none; color: #D8000C;"></label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-2 control-label"></label>
                                <div class="col-sm-6">
                                    <asp:LinkButton ID="lnkbtnSave" runat="server" CssClass="btn btn-default" OnClick="btnSave_Click">Save to Template</asp:LinkButton>
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-default" OnClick="btnReset_Click" />
                                </div>
                            </div>

                            <asp:GridView ID="gvCertificateTemplate" class="table" AutoGenerateColumns="false" runat="server" DataKeyNames="CertificateId" AllowPaging="True" OnPageIndexChanging="gvCertificateTemplate_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:BoundField HeaderText="Certificate Id" DataField="CertificateId" Visible="false" />
                                    <asp:BoundField HeaderText="Certificate Title" DataField="CertificateTitle" />
                                    <asp:TemplateField HeaderText="Template Picture">
                                        <ItemTemplate>
                                            <asp:Image ID="imgTemplatePicture" runat="server" ImageUrl='<%# Eval("CertificatePic","~/TemplateImage/{0}") %>' Width="100" Height="70" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click" CommandArgument='<%#Eval("CertificateId")%>' OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to edit this record?');">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClick="lnkbtnDelete_Click" CommandArgument='<%#Eval("CertificateId")%>' OnClientClick="return getConfirmation(this, 'Please confirm','Are you sure you want to delete?');">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <h2>Record not found...</h2>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
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
