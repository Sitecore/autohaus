<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderBy.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.OrderBy" %>
<div id="<%# UniqueControlId %>" class="<%# Parameters["Span"] %> pull-right">
    <label>
        <strong><%# Parameters["Title"] ?? Parameters["facet_Name"] %></strong>
    </label>
    <select data-facet-key="orderby" class="selectpicker span12">
        <option value="default">Default</option>
        <option value="<%# Parameters["facet_Parameters"] %> desc"><%# Parameters["facet_Name"] %> DESC</option>
        <option value="<%# Parameters["facet_Parameters"] %> asc"><%# Parameters["facet_Name"] %> ASC</option>
    </select>
</div>
<script> $(function() {

    var rootId = '<%# UniqueControlId %>';
    if (!rootId.length) {
        console.error("OrderBy: cannot find the root id");
        return;
    }

    var root = $("#" + rootId);
    if (!root.length) {
        console.error("OrderBy: cannot find the root control");
        return;
    }

    var select = $("#" + rootId + " select:first");

    if (!select.length) {
        console.error("OrderBy: cannot find the select control");
        return;
    }

    $(select).change(function() {
        var state = {};
        var key = $(this).attr("data-facet-key");
        var val = $(this).attr("value");
        state[key] = val;
        $.bbq.pushState(state);
        load();
    });

    $(seleselectpicker({
        style: #
        Parameters[
        "CSS"];
%
>
    ',;
    size: o;
    ';
});
)
; </script>