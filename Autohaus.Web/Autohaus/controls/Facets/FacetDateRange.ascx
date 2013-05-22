<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacetDateRange.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.FacetDateRange" %>
<div id="<%# UniqueControlId %>" class="facet <%# Parameters["Span"] ?? "span2" %>">
    <strong><%# Parameters["Title"] %></strong>
    <div class="control-group">
        <div class="controls">
            <div class="input-append">
                <input type="text" placeholder="<%# Parameters["FromLabel"] %>" class="from" name="from" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>" />
                <span class="add-on"><i class="icon-calendar"></i></span>
            </div>
            <a class="close" data-remove-from="alert" style="display: none">&times;</a>
        </div>
    </div>
    <div class="control-group">
        <div class="controls">
            <div class="input-append">
                <input type="text" placeholder="<%# Parameters["ToLabel"] %>" class="to" name="to" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>" />
                <span class="add-on"><i class="icon-calendar"></i></span>
            </div>
            <a class="close" data-remove-to="alert" style="display: none">&times;</a>
        </div>
    </div>
</div>
<script>
    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("FacetDateRange: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("FacetDateRange: cannot find the root control");
            return;
        }

        var from = $("#" + rootId + " input.from");

        if (!from.length) {
            console.error("FacetDateRange: cannot find the 'from' control");
            return;
        }

        var to = $("#" + rootId + " input.to");

        if (!to.length) {
            console.error("FacetDateRange: cannot find the 'to' control");
            return;
        }

        $(from).datepicker({
            defaultDate: "<%# Parameters["DefaultFromDate"] %>",
            dateFormat: "yy-mm-dd",
            changeMonth: false,
            numberOfMonths: <%# Parameters["NumberOfMonths"] %>,
            onSelect: function(selectedDate) {
                //console.log("Selected date: " + selectedDate + "; input's current value: " + this.value);
                var state = {};
                var key = $(this).attr("data-facet-key") + "_from";
                state[key] = "datetime'" + selectedDate + "'";
                $.bbq.pushState(state);

                var alert = $("#" + rootId + " [data-remove-from]");

                if (alert.length) {
                    $(alert).show();
                }
                // goes to the server - can be quite expensive
                load();
            },
        });
        $(to).datepicker({
            defaultDate: "<%# Parameters["DefaultToDate"] %>",
            dateFormat: "yy-mm-dd",
            changeMonth: false,
            numberOfMonths: <%# Parameters["NumberOfMonths"] %>,
            onSelect: function(selectedDate) {
                //console.log("Selected date: " + selectedDate + "; input's current value: " + this.value);
                var state = {};
                var key = $(this).attr("data-facet-key") + "_to";
                state[key] = "datetime'" + selectedDate + "'";
                $.bbq.pushState(state);

                var alert = $("#" + rootId + " [data-remove-to]");
                if (alert.length) {
                    $(alert).show();
                }
                // goes to the server - can be quite expensive
                load();
            },
        });

        $("#" + rootId + " [data-remove-to]").on("click", function() {
            $(this).hide();
            var key = $(to).attr("data-facet-key") + "_to";
            $.bbq.removeState(key);
            $(to).val('');
            load();
        });

        $("#" + rootId + " [data-remove-from]").on("click", function() {
            $(this).hide();
            var key = $(from).attr("data-facet-key") + "_from";
            $.bbq.removeState(key);
            $(from).val('');
            load();
        });
    });
</script>