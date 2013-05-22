<%@ Control Language="C#" AutoEventWireup="true" %>

<div class="row-fluid">
    <sc:placeholder key="facets" runat="server"></sc:placeholder>
</div>
<hr />
<div class="row-fluid">
    <div class="span12">
        <sc:placeholder key="search-options" runat="server"></sc:placeholder>
    </div>
</div>
<sc:Sublayout runat="server" Path="/autohaus/controls/facets/AlertArea.ascx" />
<sc:Sublayout runat="server" Path="/autohaus/controls/facets/Results.ascx" />
<script type="text/javascript" src="/autohaus/js/browse-interactive.js"> </script>