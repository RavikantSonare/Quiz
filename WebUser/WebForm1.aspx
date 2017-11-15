<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebUser.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 500px; height: 487px; overflow: auto; margin-removed 0px;">
        <img src="resource/canvasimage.png" width="793px" height="787px" class="map" alt="Parliament" usemap="#Parliamentmap" id="ImageMap1" />
    </div>
    <map id="map" name="Parliamentmap">
        <area shape="poly" id="Area2" rel="0" coords="270,127,289,131,257,160,240,155" alt="ff" />
        <area shape="poly" id="Area3" rel="1" coords="289,131,303,132,275,163,257,160" alt="bb" />
        <area shape="poly" id="Area4" rel="1" coords="303,132,317,134,296,160,275,163" alt="bb" />
        <area shape="poly" id="Area5" rel="1" coords="317,134,329,138,312,167,296,160" alt="tg" />
        <area shape="poly" id="Area6" rel="1" coords="329,138,339,138,325,169,312,167" alt="hk" />
        <area shape="poly" id="Area7" rel="1" coords="339,138,354,140,340,170,325,169" alt="ui" />
        <area shape="poly" id="Area8" rel="1" coords="354,140,364,138,353,172,340,170" alt="oi" />
        <area shape="poly" id="Area9" rel="1" coords="364,138,374,141,365,172,353,172" alt="ry" />
        <area shape="poly" id="Area10" rel="1" coords="374,141,382,141,376,174,365,172" alt="iy" />
        <area shape="poly" id="Area11" rel="1" coords="382,141,394,143,389,175,376,174" alt="sf" />
        <area shape="poly" id="Area12" rel="1" coords="394,143,403,143,402,177,389,175" alt="rt" />
        <area shape="poly" id="Area13" rel="1" coords="403,143,415,143,415,178,402,177" alt="mn" />
    </map>
    <script type="text/javascript">
        $(function () {
            $('area').click(function (event) {
                var map = document.getElementById('map');
                var areas = map.getElementsByTagName('area');
                for (var i = 0; i < areas.length; i++) {
                    var area = areas[i];
                    var id = area.id;
                    var data = $('#' + id).data('maphilight') || {};
                    if (area.id == $(this)[0].id)
                        data.fillColor = '02FC1F'; // Sample color           
                    else data.fillColor = 'ff0000'; // Sample color           
                    $('#' + id).data('maphilight', data).trigger('alwaysOn.maphilight');
                }
            });
            $('.map').maphilight({ strokeColor: '808080', strokeWidth: 0, fill: 'ff0000', fillColor: 'ff0000', alwaysOn: true });
        });
    </script>
    <a rel="lightbox" href="#" title="a generated title">
        <img src="site.com/img" class="post-image" alt="a long description" />
    </a>
    <script>
        $(function () {
            $("a").each(function () {
                $(this).attr("title", $(this).find("img").attr("alt"));
            });
        });
    </script>
</asp:Content>
