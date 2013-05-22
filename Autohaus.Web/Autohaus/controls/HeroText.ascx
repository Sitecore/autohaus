<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="hero-unit">
    <div class="row-fluid">
        <div class="span12">
            <h1>
                <sc:Text runat="server" Field="Title" />
            </h1>
            <sc:Text runat="server" Field="Text" />
        </div>
    </div>
</div>