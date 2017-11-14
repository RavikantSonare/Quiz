<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="OnlineTestReport.aspx.cs" Inherits="WebUser.OnlineTestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .progress[style*="display: block;"] {
            display: inline !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 outer" style="min-height: 100px; background-color: #083C64; color: white; font-size: large">
            <div class="col-lg-4" style="text-align: left"></div>
            <div class="col-lg-4">
                Exam:<asp:Label ID="lblExamCode" runat="server"></asp:Label>
            </div>
            <div class="col-lg-4" style="text-align: right">
            </div>
        </div>
        <div class="col-lg-12" align="center" style="border: 1px solid #808080; min-height: 400px">
            <div class="col-lg-12 mtop30">
                <asp:Label ID="lblResultMsg" runat="server" Font-Size="23px"></asp:Label>
            </div>
            <div class="col-lg-12 mbtm20">
                <h1>Examination Score Report</h1>
            </div>
            <div class="col-lg-12 mbtm20">
                <asp:Label ID="lblExamName" runat="server" Font-Size="23px"></asp:Label>
            </div>
            <div class="col-lg-12 mbtm20">
                <div class="col-lg-6" align="right">
                    <asp:Label ID="lbldatehead" runat="server" Text="Date:" Font-Size="18px"></asp:Label>
                    <asp:Label ID="lbldate" runat="server" Font-Size="16px"></asp:Label>
                </div>
                <div class="col-lg-6" align="left">
                    <asp:Label ID="lbltimehead" runat="server" Text="Time:" Font-Size="18px"></asp:Label>
                    <asp:Label ID="lbltime" runat="server" Font-Size="16px"></asp:Label>
                </div>
                <div class="col-lg-12 mtop10"></div>
                <div class="col-lg-6" align="right">
                    <asp:Label ID="lblpassingscorehead" runat="server" Text="Passing Score:" Font-Size="18px"></asp:Label>
                    <asp:Label ID="lblpassingscore" runat="server" Text="600" Font-Size="16px"></asp:Label>
                </div>
                <div class="col-lg-6" align="left">
                    <asp:Label ID="lblyourscorehead" runat="server" Text="Your Score:" Font-Size="18px"></asp:Label>
                    <asp:Label ID="lblyourscore" runat="server" Text="700" Font-Size="16px"></asp:Label>
                </div>
            </div>
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                <div class="progress skill-bar" id="pbpassingvalue" runat="server">
                </div>
                <div class="progress skill-bar" id="pbresultvalue" runat="server">
                </div>
            </div>
            <div class="col-lg-3"></div>
        </div>
    </div>
    <div class="col-lg-12" align="center">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=btnLoad]').bind('click', function () {
                    var progress = setInterval(function () {
                        var $bar = $('.progress-bar,progress-bar-danger');
                        if ($bar.width() >= 400) {
                            clearInterval(progress);
                            $('.progress').removeClass('active');
                        } else {
                            $bar.width(40);
                            // $bar.width($bar.width() + 40);
                        }
                        $bar.text($bar.width() / 4 + "%");
                    }, 540);
                });
            });
            $(document).ready(function () {
                //Id of your button control either it is server  control or simple html control
                $("[id*='btnLoad']").click();
            });
        </script>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="pnl1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnLoad" Text="Load Data" runat="server" OnClick="LoadData" Style="display: none;" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnl1" class="progress">
            <ProgressTemplate>
                <div style="margin-top: 20px; width: 400px;">
                    <div class="progress progress-striped active">
                        <div class="progress-bar" style="width: 0%;">
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="pnl1">
            <ProgressTemplate>
                <div style="margin-top: 20px; width: 400px;">
                    <div class="progress progress-striped active">
                        <div class="progress-bar-danger" style="width: 0%;">
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </div>

    <style>
        .progress {
            height: 35px;
        }

            .progress .skill {
                font: normal 12px "Open Sans Web";
                line-height: 35px;
                padding: 0;
                margin: 0 0 0 20px;
                text-transform: uppercase;
            }

                .progress .skill .val {
                    float: right;
                    font-style: normal;
                    margin: 0 20px 0 0;
                }

        .progress-bar {
            text-align: left;
            transition-duration: 3s;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('.progress .progress-bar').css("width",
                      function () {
                          return $(this).attr("aria-valuenow") + "%";
                      }
              )
        });

    </script>
</asp:Content>
