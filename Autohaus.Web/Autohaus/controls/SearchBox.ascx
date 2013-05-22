<%@ Control Language="C#" AutoEventWireup="true" %>
<div id="search-area" class="navbar-search pull-right">
    <div class="input-append">
        <input id="searchbox" type="text" class="span3" placeholder="Search here..." autocomplete="off" />
        <a href="#" class="getstarted" data-placement="bottom" data-toggle="popover" data-content="Use this search box to test drive typeahead search. It's implemented via NGram analyzer and using .StartsWith() call on FullModelName property." data-original-title="Typeahead Search"></a>
        <button id="searchButton" type="submit" class="btn btn-primary btn-medium">
            <i class="icon-search icon-large"></i>&nbsp;&nbsp;
            Search
        </button>
    </div>
</div>

<script language="javascript">

    $(document).ready(function() {
        var count = 10;
        var labels, mapped;
        $('#searchbox').typeahead({
            source: function(query, process) {
                $.get('/api/search/starts', { s: query, top: count - 1 }, function(data) {
                    labels = [];
                    mapped = {};
                    $.each(data, function(index, value) {
                        mapped[value.Name] = value.Url;
                        labels.push(value.Name);
                    });
                    process(labels);
                }, 'json');
            },
            highlighter: function(item) {
                var regex = new RegExp('(' + this.query + ')', 'gi');
                return item.replace(regex, "<strong>$1</strong>");
            },
            updater: function(queryLabel) {
                if (queryLabel == "#") {
                    return;
                }
                window.location.replace(mapped[queryLabel]);
            },
            matcher: function(item) {
                if (item.toLowerCase().indexOf("query returned") != -1) {
                    return true;
                }
                if (item.toLowerCase().indexOf(this.query.trim().toLowerCase()) != -1) {
                    return true;
                }
            },
            minLength: 3,
            items: count
        });

        $("#searchButton").click(function(event) {
            if ($("#searchbox").val()) {
                window.location.replace("/autohaus/search#q=" + $("#searchbox").val());
            }
            return false;
        });

        $("#searchbox").keyup(function(event) {
            if (event.keyCode == 13) {
                $("#searchButton").click();
            }
        });

        $('#searchbox').focus();

    });
</script>