<%@ Page Language="C#" AutoEventWireup="True" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
    <html class="no-js">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Autohaus: Sitecore Demo Site</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width">

    <link id="theme" rel="stylesheet" href="/autohaus/css/themes/default/bootstrap.min.css">
    <link rel="stylesheet" href="/autohaus/css/font-awesome.min.css">
    <link rel="stylesheet" href="/autohaus/css/bootstrap-responsive.min.css">
    <link rel="stylesheet" href="/autohaus/css/ui-lightness/jquery-ui-1.10.2.custom.min.css">
    <link rel="stylesheet" href="/autohaus/css/bootstrap-select.min.css">
    <link rel="stylesheet" href="/autohaus/css/prettify.css">
    <link rel="stylesheet" href="/autohaus/css/custom-theme/jquery-ui-1.10.0.custom.css">
    <link rel="stylesheet" href="/autohaus/css/custom-theme/jquery.ui.1.10.0.ie.css">
    <link rel="stylesheet" href="/autohaus/css/site.css">

    <sc:PlaceHolder runat="server" key="css"></sc:PlaceHolder>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js"> </script>
    <script> window.jQuery || document.write('<script src="/autohaus/js/vendor/jquery-1.8.3.js"><\/script>') </script>
    <script>
        if (localStorage) {
            var theme = localStorage.theme;
            if (theme && theme.length) {
                $('#theme[rel=stylesheet]').attr('href', theme);
            }
        }
    </script>
    <script src="/autohaus/js/vendor/jquery-ui-1.10.2.custom.min.js"> </script>
    <script src="/autohaus/js/vendor/bootstrap.js"> </script>
    <script src="/autohaus/js/vendor/bootstrap-select.min.js"> </script>
    <script src="/autohaus/js/main.js"> </script>
    <script src="/autohaus/js/vendor/knockout-2.2.0.js"> </script>
    <script src="/autohaus/js/vendor/knockout.mapping-latest.js"> </script>
    <script src="/autohaus/js/vendor/datajs-1.1.0.min.js"> </script>
    <script src="/autohaus/js/vendor/modernizr-2.6.2-respond-1.1.0.min.js"> </script>
    <script src="/autohaus/js/vendor/prettify.js"> </script>
    <script src="/autohaus/js/vendor/lang-n.js"> </script>
    <script src="/autohaus/js/vendor/jquery.ba-bbq.min.js"> </script>
    <sc:PlaceHolder runat="server" key="js"></sc:PlaceHolder>
</head>
<body onload=" prettyPrint() ">
    <sc:Placeholder runat="server" Key="body" />
</body>
</html>