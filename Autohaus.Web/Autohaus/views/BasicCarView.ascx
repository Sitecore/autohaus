<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicCarView.ascx.cs" Inherits="Autohaus.Web.UI.Controls.DynamicQueryControl" %>
<asp:Panel id="alert" class="alert alert-success" runat="server" Visible="False">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <asp:Label runat="server" ID="resultMessage"></asp:Label>
</asp:Panel>
<asp:Repeater runat="server" ID="carsRepeater">
    <HeaderTemplate>
        <table class="table table-striped table-hover">
        <thead>
            <tr>
                <th>Model Name</th>
            </tr>
        </thead>
        <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href="<%# Eval("FriendlyUrl") %>"><%# Eval("FullModelName") %></a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </tbody></table>
    </FooterTemplate>
</asp:Repeater>