<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bid4Stuff.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">Welcome to Bid4Stuff!</h1>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            <h2 class="text-center">Latest Added Offers</h2>
            <asp:ListView ID="ListViewLatestAddedOffers" runat="server"
                          SelectMethod="ListViewLatestAddedOffers_GetData"
                          ItemType="Bid4Stuff.Models.Item"
                          DataKeyNames="Id">
                <EmptyDataTemplate>
                    <h3 class="text-center">No offers yet!</h3>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server"></th>
                                <th runat="server">Name</th>
                                <th runat="server">Price</th>
                                <th runat="server">Added</th>
                                <th runat="server">Time Left</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <td class="col-md-2">
                        <asp:Image ImageUrl='<%# Item.ImagePath %>' runat="server" CssClass="img-responsive"/>
                    </td>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Price %></td>
                    <td><%#: Item.StartDate %></td>
                    <td><%#: string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds.", (Item.EndDate - DateTime.Now).Days, (Item.EndDate - DateTime.Now).Hours, (Item.EndDate - DateTime.Now).Minutes, (Item.EndDate - DateTime.Now).Seconds) %></td>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-5">
            <h2 class="text-center">Offers Ending Soon</h2>
            <asp:ListView ID="ListViewOffersEndingSoon" runat="server"
                          SelectMethod="ListViewOffersEndingSoon_GetData"
                          ItemType="Bid4Stuff.Models.Item"
                          DataKeyNames="Id">
                <EmptyDataTemplate>
                    <h3 class="text-center">No offers yet!</h3>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server"></th>
                                <th runat="server">Name</th>
                                <th runat="server">Price</th>
                                <th runat="server">Added</th>
                                <th runat="server">End Date</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <td class="col-md-2">
                        <asp:Image ImageUrl='<%# Item.ImagePath %>' runat="server" CssClass="img-responsive"/>
                    </td>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Price %></td>
                    <td><%#: Item.StartDate %></td>
                    <td><%#: string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds.", (Item.EndDate - DateTime.Now).Days, (Item.EndDate - DateTime.Now).Hours, (Item.EndDate - DateTime.Now).Minutes, (Item.EndDate - DateTime.Now).Seconds) %></td>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
