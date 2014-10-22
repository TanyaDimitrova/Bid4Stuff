<%@ Page
    Title="AdminArea"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AdminArea.aspx.cs"
    EnableEventValidation="false"
    Inherits="Bid4Stuff.App.Admin.AdminArea" %>

<asp:Content ID="AdminAreaData" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Manage User Bids</h1>
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Item Name</th>
                    <th>Item Price</th>
                    <th>Bid's Date & Time
                    </th>
                    <th>Bidder</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView
                    ID="BidsListView"
                    runat="server"
                    ItemType="Bid4Stuff.Models.Bid">
                    <ItemTemplate>
                        <tr class="info">
                            <td><%#: Item.Item.Name %></td>
                            <td><%#: String.Format("{0:c}", Item.Price) %></td>
                            <td><%#: Item.Time.ToString("dd MMM yyyy") %></td>
                            <td><%#: Item.User.UserName %></td>
                            <td>
                                <asp:LinkButton
                                    ID="EditItem"
                                    runat="server"
                                    class="btn btn-info"
                                    CommandName="Edit"
                                    OnCommand="EditItem_Command"
                                    CommandArgument="<%# Item.Id %>"
                                    Text="Edit" />
                                <asp:LinkButton
                                    ID="DeleteItem"
                                    runat="server"
                                    class="btn btn-danger"
                                    CommandName="Delete"
                                    OnCommand="DeleteItem_Command"
                                    CommandArgument="<%# Item.Id %>"
                                    OnClientClick="return confirm('Are you sure you want to delete following bid?');"
                                    Text="Delete" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
        </table>
    </div>
</asp:Content>
