<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacetSlider.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.FacetSlider" %>
<div id="<%# UniqueControlId %>" class="facet <%# Parameters["Span"] ?? "span2" %>">
    <label for="sliderlabel">
        <strong><%# Parameters["Title"] %></strong>
        <a class="close" data-remove="alert" style="display: none">&times;</a>
    </label>
    <input type="text" name="sliderlabel" style="background-color: transparent; border: 0; color: #999999; font-weight: bold;" />
    <div class="slider" data-facet-key="<%# Parameters["facet_Client Side Handle"] %>"></div>
</div>
<script>
    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("FacetSlider: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("FacetSlider: cannot find the root control");
            return;
        }

        var slider = $("#" + rootId + " div.slider");

        if (!slider.length) {
            console.error("FacetSlider: cannot find the slider control");
            return;
        }

        var input = $("#" + rootId + " input:first");

        if (!input.length) {
            console.error("FacetSlider: cannot find the input control");
            return;
        }

        var sliderResetting = false;

        var alert = $("#" + rootId + " a.close");

        $(slider).slider({
            min: <%# Parameters["Min"] %>,
            max: <%# Parameters["Max"] %>,
            step: <%# Parameters["Step"] %>,
            range: true,
            values: [<%# Parameters["MinSelected"] %>, <%# Parameters["MaxSelected"] %>],
            slide: function(event, ui) {
                $(input).val(ui.values[0] + " - " + ui.values[1] + " <%# Parameters["Units"] %>");
            },
            change: function(event, ui) {
                // reading this flag as a dirty hack to make sure that slider.change() is not called twice
                if (sliderResetting) {
                    return;
                }

                var state = {};
                for (var i = 0; i < ui.values.length; i++) {

                    // if the values are not min or max
                    if (i == 0 && ui.values[i] != $(slider).slider("option", "min") ||
                        i == 1 && ui.values[i] != $(slider).slider("option", "max")) {

                        var keySuffix = "from";
                        if (i == 1) {
                            keySuffix = "to";
                        }
                        var key = $(this).attr("data-facet-key") + "_" + keySuffix;
                        var val = ui.values[i];
                        state[key] = val;
                    }
                }

                if (Object.keys(state).length === 0) {
                    return;
                }

                $.bbq.pushState(state);
                if (alert.length) {
                    $(alert).show();
                }

                load();
            }
        });

        $("#" + rootId + " [data-remove]").on("click", function() {
            $(alert).hide();
            var keyfrom = $(slider).attr("data-facet-key") + "_from";
            var keyto = $(slider).attr("data-facet-key") + "_to";
            // setting this flag as a dirty hack to make sure that slider.change() is not called twice
            sliderResetting = true;
            $(slider).slider("values", 0, <%# Parameters["MinSelected"] %>);
            sliderResetting = false;
            $(slider).slider("values", 1, <%# Parameters["MaxSelected"] %>);
            $(input).val($(slider).slider("values", 0) + " - " + $(slider).slider("values", 1) + " <%# Parameters["Units"] %>");
            $.bbq.removeState(keyfrom, keyto);
            load();
        });

        $(input).val($(slider).slider("values", 0) + " - " + $(slider).slider("values", 1) + " <%# Parameters["Units"] %>");
    });
</script>