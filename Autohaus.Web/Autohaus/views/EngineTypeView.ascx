<%@ Control Language="C#" AutoEventWireup="true" Inherits="Autohaus.Web.UI.Controls.DynamicQueryControl" %>
<asp:Panel ID="alert" class="alert alert-success" runat="server" Visible="False">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <asp:Label runat="server" ID="resultMessage"></asp:Label>
</asp:Panel>
<asp:Repeater runat="server" ID="carsRepeater">
    <HeaderTemplate>
        <table class="table table-striped">
        <thead>
            <tr>
                <th>Model Name</th>
                <th>Engine</th>
                <th>Fuel Type</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href="<%# Eval("FriendlyUrl") %>"><%# Eval("FullModelName") %></a>
            </td>
            <td><%# Eval("EngineDescription") %></td>
            <td><%# Eval("EngineFuel") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </tbody></table>
    </FooterTemplate>
</asp:Repeater>