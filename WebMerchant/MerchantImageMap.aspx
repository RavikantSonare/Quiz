<%@ Page Title="" Language="C#" MasterPageFile="~/Merchant.Master" AutoEventWireup="true" CodeBehind="MerchantImageMap.aspx.cs" Inherits="WebMerchant.MerchantImageMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Question</h2>
    <hr />
    <link href="imagemapping/main.css" rel="stylesheet" />
    <%-- <noscript>
    <div id="noscript">
        Please, enable javascript in your browser
    </div>
</noscript>

    <div id="wrapper">
        <header id="header">
            <nav id="nav" class="clearfix">
                <ul>
                    <li id="save"><a href="#">save</a></li>
                    <li id="load"><a href="#">load</a></li>
                    <li id="from_html"><a href="#">from html</a></li>
                    <li id="rectangle"><a href="#">rectangle</a></li>
                    <li id="circle"><a href="#">circle</a></li>
                    <li id="polygon"><a href="#">polygon</a></li>
                    <li id="edit"><a href="#">edit</a></li>
                    <li id="to_html"><a href="#">to html</a></li>
                    <li id="preview"><a href="#">preview</a></li>
                    <li id="clear"><a href="#">clear</a></li>
                    <li id="new_image"><a href="#">new image</a></li>
                    <li id="show_help"><a href="#">?</a></li>
                </ul>
            </nav>
            <div id="coords"></div>
            <div id="debug"></div>
        </header>
        <div id="image_wrapper">
            <div id="image">
                <img src="" alt="#" id="img" />
                <svg xmlns="http://www.w3.org/2000/svg" version="1.2" baseProfile="tiny" id="svg"></svg>
            </div>
        </div>
    </div>

    <!-- For html image map code -->
    <div id="code">
        <span class="close_button" title="close"></span>
        <div id="code_content"></div>
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
            <label for="url">type a url</label>
            <span id="url_wrapper">
                <span class="clear_button" title="clear">x</span>
                <input type="text" id="url" />
            </span>
            <button id="button">OK</button>
        </div>
    </div>

    <!-- Help block -->
    <div id="overlay"></div>
    <div id="help">
        <span class="close_button" title="close"></span>
    </div>

    <script src="imagemapping/summerHTMLImageMapCreator.js"></script>--%>


    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


</asp:Content>
