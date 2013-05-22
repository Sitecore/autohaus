<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacetBooleanDropdown.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.FacetBooleanDropdown" %>
<div id="<%# UniqueControlId %>" class="facet <%# Parameters["Span"] ?? "span2" %>" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>">
    <label>
        <strong><%# Parameters["Title"] %></strong>
        <a class="close" data-remove="alert" style="display: none">&times;</a>
    </label>
    <select data-facet-key="<%# Parameters["facet_Client Side Handle"] %>" class="selectpicker span12" data-bind="foreach: { data: facets, as: 'facet' }">
        <!-- ko if: facet.key == '<%# Parameters["facet_Client Side Handle"] %>' -->
        <!-- ko if: !facet.selected -->
        <option><%# Parameters["DefaultLabel"] %></option>
        <!-- /ko -->
        <!-- ko foreach: facet.values -->
            <!-- ko if: $data.name == "1" -->
                <option value="yes" data-bind="text: '<%# Parameters["TrueLabel"] %>' + ' (' + $data.count + ')'">
                </option>
            <!-- /ko -->
            <!-- ko if: $data.name == "0" -->
                <option value="no" data-bind="text: '<%# Parameters["FalseLabel"] %>' + ' (' + $data.count + ')'">
                </option>
            <!-- /ko -->
        <!-- /ko -->
        <!-- /ko -->
    </select>
</div>
<script>
    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("FacetBooleanDropdown: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("FacetBooleanDropdown: cannot find the root control");
            return;
        }

        var select = $("#" + rootId + " select:first");

        if (!select.length) {
            console.error("FacetBooleanDropdown: cannot find the select control");
            return;
        }
        
        var alert = $("#" + rootId + " a.close");

        $(select).change(function() {
            var state = {};
            var key = $(this).attr("data-facet-key");
            var val = $(this).attr("value");

            if (val.length > 0) {
                state[key] = val;
                $.bbq.pushState(state);
                if (alert.length) {
                    $(alert).show();
                }
                load();
            } else {
                $.bbq.removeState(key);
                load();
            }
        });
        
        $("#" + rootId + " [data-remove]").on("click", function () {
            $(this).hide();
            var key = $(select).attr("data-facet-key");
            $.bbq.removeState(key);
            load();
        });

    });

</script>