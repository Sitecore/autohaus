<%@ Control Language="C#" AutoEventWireup="true" %>
<div class="row-fluid">
    <div class="span12">
        <table id="carsTable" class="table table-striped" data-bind="visible: cars().length > 0">
            <thead>
                <tr>
                    <th>Full Model Name</th>
                </tr>
            </thead>
            <tbody data-bind="foreach: cars">
                <tr>
                    <td>
                        <a data-bind="attr: { href: url }, text: fullmodelname"/>
                    </td>
                </tr>
            </tbody>
        </table>
        <button id="more" class="btn btn-large btn-block" type="button" data-bind="visible: cars().length > 0 && nextlink() && nextlink().length != 0">More</button>
    </div>
</div>