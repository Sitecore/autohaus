<%@ Control Language="C#" AutoEventWireup="true" %>

<div class="row-fluid">
    <div id="sidebar" class="span3 bs-docs-sidebar">
        <div class="span12"></div>
        <sc:placeholder key="facets" runat="server"></sc:placeholder>
    </div>
    <div class="span9">
        <div class="row-fluid">
            <div class="span12">
                <sc:placeholder key="search-options" runat="server"></sc:placeholder>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">
                <sc:sublayout runat="server" path="/autohaus/controls/facets/AlertArea.ascx" />
            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">
                <sc:sublayout runat="server" path="/autohaus/controls/facets/Results.ascx" />
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" src="/autohaus/js/browse-interactive.js"> </script>