<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="Autohaus.Web.UI.Controls.Facets.SearchBox" %>

<div id="<%# UniqueControlId %>" class="<%# Parameters["Span"] %> form-search" style="margin-bottom: 20px;">
    <label>
        <strong><%# Parameters["Title"] ?? Parameters["facet_Name"] %></strong>
    </label>
    <div class="input-append">
        <form class="form-search">
            <input id="searchbox" data-facet-key="q" class="search-query <%# Parameters["CSS"] %>" type="text">
            <a id="searchbutton" class="btn btn-primary btn-medium">
                <i class="icon-search icon-large"></i>&nbsp;&nbsp;
                Search
            </a>
        </form>
    </div>
</div>

<script>

    $(function() {

        var rootId = '<%# UniqueControlId %>';
        if (!rootId.length) {
            console.error("SearchBox: cannot find the root id");
            return;
        }

        var root = $("#" + rootId);
        if (!root.length) {
            console.error("SearchBox: cannot find the root control");
            return;
        }

        var searchbox = $("#" + rootId + " #searchbox");

        if (!searchbox.length) {
            console.error("SearchBox: cannot find the search box control");
            return;
        }

        var searchbutton = $("#" + rootId + " #searchbutton");

        if (!searchbutton.length) {
            console.error("SearchBox: cannot find the search button control");
            return;
        }

        $(searchbox).keypress(function(event) {
            if (event.keyCode == 13) {
                search($(searchbox));
            }
            return null;
        });

        $(searchbutton).click(function(event) {
            search($(searchbox));
        });

        var currentState = $.bbq.getState("q");
        if (currentState && currentState.length) {
            $(searchbox).val(currentState);
        }
    });

    function search(input) {
        var state = {};
        var key = $(input).attr("data-facet-key");
        var val = $(input).attr("value");
        state[key] = val;
        $.bbq.pushState(state);
        load();
        return false;
    }
</script>