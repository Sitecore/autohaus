var my = {};

var Facet = function(key, name, values) {
    this.key = key;
    this.name = name;
    this.values = values;
    this.selected = values.length == 1;
};

var FacetValue = function(name, count) {
    this.name = name;
    this.count = count;
    this.label = name + " (" + count + ")";
};

function Car(name, url) {
    this.fullmodelname = name;
    this.url = url;
}

my.vm = {
    facets: ko.observableArray([]),
    cars: ko.observableArray([]),
    total: ko.observable("0"),
    nextlink: ko.observable("")
};

ko.applyBindings(my.vm);

$(document).ready(function() {
    load();

    $("#more").click(function() {
        $.get(my.vm.nextlink(), function(data) {
            $.each(data.value, function(i, c) {
                my.vm.cars.push(new Car(c.FullModelName, c.FriendlyUrl));
            });
            my.vm.total(data["odata.count"]);
            my.vm.nextlink(data["odata.nextLink"]);
        });
    });
});

function showError(text) {
    $("#queryError").empty();
    $("#queryError").append(text);
    $("#queryError").show();
}

function load() {

    var query = createQuery();

    // reading all facets on the page
    var facetSet = [];
    $('div.facet').each(function(index) {
        var value = $(this).attr("data-facet-key");
        if (value && value.length) {
            facetSet.push(value);
        }
    });

    var facets = facetSet.join("|");

    var facetServiceUri = "/odata/Facets";
    var carServiceUri = "/odata/Cars?$inlinecount=allpages&$filter=";
    if (!query.length) {
        facetServiceUri += "?$expand=" + facets;
    } else {
        facetServiceUri += "?$filter=" + query + "&$expand=" + facets;
    }

    $.get(facetServiceUri, function(data) {
        my.vm.facets.removeAll();
        $.each(data.value, function(i, c) {
            var key = c.Key;
            var name = c.Name;
            var values = [];
            $.each(c.Values, function(y, f) {
                if (f.Name && f.Name.length) {
                    values.push(new FacetValue(f.Name, f.Count));
                }
            });
            my.vm.facets.push(new Facet(key, name, values));
        });
    });

    if (!query.length) {
        my.vm.cars.removeAll();
        return;
    }

    carServiceUri += query;

    $.get(carServiceUri, function(data) {
        my.vm.cars.removeAll();
        $.each(data.value, function(i, c) {
            my.vm.cars.push(new Car(c.FullModelName, c.FriendlyUrl));
        });

        my.vm.total(data["odata.count"]);
        my.vm.nextlink(data["odata.nextLink"]);
    });
}

function createQuery() {
    var query = "";

    var params = $.deparam.fragment();
    var i = 0;

    // TODO: need to check for the existense of the parameters other than 'orderby', 'top, 'skip', etc.
    // if there are only special parameters, need to skip

    for (param in params) {
        var key = param;
        var val = params[param];

        if (key && val) {
            // TODO: review this later. protecting odata specific keys
            if (i > 0 && key != "orderby" && key != "top" && key != "skip") {
                query += " and ";
            }

            //TODO: handle $take and $skip when added
            if (val == "yes") {
                query += key;
            } else if (val == "no") {
                query += "not(" + key + ")";
            } else if (key.match(/_from/)) {
                query += key.replace('_from', '') + " gt " + val + "";
            } else if (key.match(/_to/)) {
                query += key.replace('_to', '') + " lt " + val + "";
            } else if (key == "q") {
                query += "Content eq '" + val + "'";
                query += " or Name eq '" + val + "'";
            } else if (key != "orderby") {
                query += key + " eq '" + val + "'";
            } else if (val != "default") {
                query += "&$orderby=" + val;
            }

            i++;
        }
    }

    //console.log(query);
    return query;
}