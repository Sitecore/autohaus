<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoBar.ascx.cs" Inherits="Autohaus.Web.UI.Controls.InfoBar" %>
<div class="btn-group" data-toggle="buttons-checkbox">
    <a href="#" class="pop btn btn-medium btn-inverse" data-placement="bottom" data-toggle="popover" title="" data-content="<%= VersionInfo %>" data-original-title="Autohaus Version">
        <i class="icon-info-sign"></i>
    </a>
    <a id="getstarted" href="#" class="tool btn btn-medium btn-inverse" data-toggle="tooltip" data-placement="bottom" title="Get Started">
        <i class="icon-question-sign"></i>
    </a>
</div>
<script>
    $(function() {

        $("#getstarted").on("click", function() {
            if ($(this).hasClass('active')) {
                $('a.getstarted').popover('hide', { animation: true });
            } else {
                $('.getstarted-menu').show();
                $('a.getstarted').popover('show', { animation: true });
            }
        });
    });
</script>