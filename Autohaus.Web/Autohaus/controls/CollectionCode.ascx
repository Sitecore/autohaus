<%@ Control Language="C#" AutoEventWireup="true" %>

<div class="alert alert-info">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <strong>Did you know?</strong>
    You can edit this query by simply editing this page using Page Editor.
</div>

<div class="row-fluid">
    <div class="span12">
        <pre class="prettyprint">using (var context = Sitecore.ContentSearch.SearchManager.GetIndex("sitecore_web_index").CreateSearchContext()) {<br />&nbsp;&nbsp;&nbsp;<sc:Text runat="server" Field="CollectionCode" /><br />}</pre>
    </div>
</div>