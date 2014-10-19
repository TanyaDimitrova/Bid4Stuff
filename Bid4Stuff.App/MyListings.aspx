<%@ Page Title="My Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyListings.aspx.cs" Inherits="Bid4Stuff.App.MyListings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:HyperLink runat="server" ID ="create" CssClass="btn btn-primary" NavigateUrl="CreateItemListing">Create new listing</asp:HyperLink>
    <asp:ListView runat="server" ID="ItemListing" ItemType="Bid4Stuff.Models.Item"> 
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </LayoutTemplate>
        <ItemSeparatorTemplate>
                <hr />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <div class="product-description">
                <h4><%#: Item.Name %></h4>
                Price: <%#: String.Format("{0:c}", Item.Price) %>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
