$(document).ready(function() {

    $('a.pop').popover();
    $('a.tool').tooltip();

    $("[data-theme]").on("click", function() {
        var themeKey = $(this).attr("data-theme");
        var themePath = "/autohaus/css/bootstrap.min.css";
        if (themeKey.length) {
            themePath = "/autohaus/css/themes/" + themeKey + "/bootstrap.min.css";
        }
        $('#theme[rel=stylesheet]').attr('href', themePath);
        if (localStorage) {
            localStorage["theme"] = themePath;
        }
    });

});