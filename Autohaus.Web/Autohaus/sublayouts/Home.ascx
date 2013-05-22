<%@ Control Language="C#" AutoEventWireup="true" %>
<sc:placeholder runat="server" key="home-top" />
<div class="container">
    <sc:sublayout runat="server" path="/autohaus/sublayouts/navbar.ascx" />
    <form id="mainform" runat="server">
        <sc:placeholder runat="server" key="content" />
    </form>
    <div id="push"></div>
</div>