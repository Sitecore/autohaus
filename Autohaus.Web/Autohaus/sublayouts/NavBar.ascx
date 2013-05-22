<%@ Control Language="C#" AutoEventWireup="true" %>
<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="navbar-inner" style="background-image: url('/autohaus/img/carbon.png'); background-repeat: repeat-x;">
        <div class="container">
            <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </a>
            <div class="nav-collapse collapse">
                <sc:sublayout runat="server" path="/autohaus/controls/infobar.ascx" />
                <sc:sublayout runat="server" path="/autohaus/controls/mainnav.ascx" />
                <sc:sublayout runat="server" path="/autohaus/controls/themeselector.ascx" />
                <sc:sublayout runat="server" path="/autohaus/controls/search.ascx" />
            </div>
        </div>
    </div>
</div>