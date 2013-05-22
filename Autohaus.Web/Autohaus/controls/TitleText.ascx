<%@ Control Language="C#" AutoEventWireup="true" %>

<div class="page-header">
    <h1>
        <sc:text runat="server" field="Title"></sc:text>
    </h1>
    <p class="lead">
        <sc:text field="Abstract" runat="server" />
    </p>
</div>
<sc:text field="Text" runat="server" />