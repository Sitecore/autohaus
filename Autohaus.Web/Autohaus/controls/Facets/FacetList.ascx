<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacetList.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.FacetList" %>

<div id="<%# UniqueControlId %>" class="facet <%# Parameters["Span"] %>" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>">
    <div class="row-fluid">
        <div class="span12">
            <a class="close" data-remove="alert" style="display: none">&times;</a>
            <strong><%# Parameters["Title"] %></strong>
        </div>
    </div>
    <div class="row-fluid">
        <ul class="nav nav-list bs-docs-sidenav" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>" data-bind="foreach: { data: facets, as: 'facet' }">
            <!-- ko if: facet.key == '<%# Parameters["facet_Client Side Handle"] %>' -->
            <!-- ko foreach: facet.values -->
            <li data-bind="attr: { id: name }"><a><i class="icon-chevron-right"></i><span data-bind="    text: label"></span></a></li>
            <!-- /ko -->
            <!-- /ko -->
        </ul>
    </div>
</div>

<script>
    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("FacetList: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("FacetList: cannot find the root control");
            return;
        }

        var ul = $("#" + rootId + " ul:first");

        var alert = $("#" + rootId + " a.close");

        $(ul).on('click', 'li', function() {
            var state = {};
            var key = $(ul).attr("data-facet-key");
            var val = this.id;
            state[key] = val;
            $.bbq.pushState(state);
            if (alert.length) {
                $(alert).show();
            }
            load();
        });

        $("#" + rootId + " [data-remove]").on("click", function() {
            $(this).hide();
            var key = $(ul).attr("data-facet-key");
            $.bbq.removeState(key);
            load();
        });
    });
</script>