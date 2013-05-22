<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataQueryRenderer.ascx.cs" Inherits="Autohaus.Web.UI.Controls.DataQueryRenderer" %>
<%@ Assembly Name="Sitecore.ContentSearch" %>
<%@ Import Namespace="Sitecore.ContentSearch.SearchTypes" %>
<asp:Panel id="alert" class="alert alert-success" runat="server" Visible="False">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <asp:Label runat="server" ID="resultMessage"></asp:Label>
</asp:Panel>
<asp:Repeater runat="server" ID="carsRepeater" ItemType="Sitecore.ContentSearch.SearchTypes.SitecoreUISearchResultItem">
    <HeaderTemplate>
        <table class="table table-striped">
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Name %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </tbody></table>
    </FooterTemplate>
</asp:Repeater>