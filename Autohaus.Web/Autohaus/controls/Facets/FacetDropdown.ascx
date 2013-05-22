<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacetDropdown.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.FacetDropdown" %>
<div id="<%# UniqueControlId %>" class="facet <%# Parameters["Span"] %>" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>">
    <label>
        <strong>
            <%# Parameters["Title"] %>
        </strong>
        <a class="close" data-remove="alert" style="display: none">&times;</a>
    </label>
    <select data-facet-key="<%# Parameters["facet_Client Side Handle"] %>" class="filter selectpicker span11" data-bind="foreach: { data: facets, as: 'facet' }">
        <!-- ko if: facet.key == '<%# Parameters["facet_Client Side Handle"] %>' -->
        <!-- ko if: !facet.selected -->
        <option>Not Selected</option>
        <!-- /ko -->
        <!-- ko foreach: facet.values -->
        <option data-bind="attr: { value: name }, text: label">
        </option>
        <!-- /ko -->
        <!-- /ko -->
    </select>
</div>

<script>
    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("FacetDropdown: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("FacetDropdown: cannot find the root control");
            return;
        }

        var select = $("#" + rootId + " select:first");

        // this confuses knockout. TODO
        //$(select).selectpicker({
        //     style: '<%# Parameters["CSS"] ?? "btn" %>',
        //    size: 'auto'
        //  });

        var alert = $("#" + rootId + " a.close");

        $(select).change(function() {
            var state = {};
            var key = $(this).attr("data-facet-key");
            var val = $(this).attr("value");
            state[key] = val;
            $.bbq.pushState(state);
            if (alert.length) {
                $(alert).show();
            }
            load();
        });

        $("#" + rootId + " [data-remove]").on("click", function() {
            $(this).hide();
            var key = $(select).attr("data-facet-key");
            $.bbq.removeState(key);
            load();
        });
    });
</script>