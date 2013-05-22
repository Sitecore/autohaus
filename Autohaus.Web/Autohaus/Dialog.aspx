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
    <title></title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width">

    <link rel="stylesheet" href="/autohaus/css/bootstrap.min.css">
    <style>
        body {
            padding-bottom: 40px;
            padding-top: 60px;
        }
    </style>
    <link rel="stylesheet" href="/autohaus/css/bootstrap-responsive.min.css">
    <link rel="stylesheet" href="/autohaus/css/main.css">
    <link rel="stylesheet" href="/autohaus/css/docs.css">

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js"> </script>
    <script> window.jQuery || document.write('<script src="/autohaus/js/vendor/jquery-1.8.3.js"><\/script>') </script>
    <script src="/autohaus/js/vendor/bootstrap.js"> </script>
    <script src="/autohaus/js/vendor/jquery.tmpl.min.js" type="text/javascript"> </script>
    <script src="/autohaus/js/main.js"> </script>
    <script src="/autohaus/js/vendor/modernizr-2.6.2-respond-1.1.0.min.js"> </script>
</head>
<body>
    <!--[if lt IE 7]>
        <p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to improve your experience.</p>
    <![endif]-->

    <!-- This code is taken from http://twitter.github.com/bootstrap/examples/hero.html -->

    <sc:Placeholder runat="server" Key="content" />
</body>
</html>