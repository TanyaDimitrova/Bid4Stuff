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
                <EmptyItemTemplate>
                    <h2>No offers yet!</h2>
                </EmptyItemTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server">Name</th>
                                <th runat="server">Price</th>
                                <th runat="server">Start Date</th>
                                <th runat="server">End Date</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Price %></td>
                        <td><%#: Item.StartDate %></td>
                        <td><%#: Item.EndDate %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-5">
            <h2 class="text-center">Offers Ending Soon</h2>
            <asp:ListView ID="ListViewOffersEndingSoon" runat="server"
                          SelectMethod="ListViewOffersEndingSoon_GetData"
                          ItemType="Bid4Stuff.Models.Item"
                          DataKeyNames="Id">
                <EmptyItemTemplate>
                    <h2>No offers yet!</h2>
                </EmptyItemTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server">Name</th>
                                <th runat="server">Price</th>
                                <th runat="server">Start Date</th>
                                <th runat="server">End Date</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Price %></td>
                        <td><%#: Item.StartDate %></td>
                        <td><%#: Item.EndDate %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
