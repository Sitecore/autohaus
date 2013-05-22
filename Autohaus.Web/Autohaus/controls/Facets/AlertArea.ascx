<%@ Control Language="C#" AutoEventWireup="true" %>
<div class="row-fluid">
    <div class="span12">
        <div class="alert alert-success" data-bind="visible: cars().length > 0">
            <button data-dismiss="alert" class="close" type="button">×</button>
            Displaying (<strong><span data-bind="text: cars().length"></span></strong>) out of (<strong><span data-bind="text: total"></span></strong>) cars
        </div>
        <div class="alert alert-info" data-bind="visible: cars().length <= 0">
            <button data-dismiss="alert" class="close" type="button">×</button>
            <strong>No results.</strong> Please use the facets to refine your search.
        </div>
    </div>
</div>