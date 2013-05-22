$(document).ready(function() {

    setTimeout(showPopovers, 5000);

    $('.cb-slideshow').click(function() {
        hidePopovers();
    });

    $('.hero-unit').click(function() {
        hidePopovers();
    });

    $('.nav').click(function() {
        hidePopovers();
    });

});

function showPopovers() {
    if (!$("#getstarted").hasClass('active')) {

        var popovers = $("a.getstarted").sort(function() { return 0.5 - Math.random(); });
        $('.getstarted-menu').show();
        $(popovers).each(function(index, value) {
            $(this).delay(1000 * (index + 1)).queue(function(next) {
                $(value).popover('show', { animation: true });
                next();
            });
            $(this).delay(4000 * (index + 1)).queue(function(next) {
                $(value).popover('hide', { animation: true });
                next();
            });
        });
    }
}

function hidePopovers() {
    $('a.getstarted').popover('hide');
    $("#getstarted").removeClass('active');
    $('.getstarted-menu').hide();
}