<%@ Page Title="My Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyListings.aspx.cs" Inherits="Bid4Stuff.App.MyListings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:HyperLink runat="server" ID ="create" CssClass="btn btn-primary" NavigateUrl="CreateItemListing">Create new listing</asp:HyperLink>
</asp:Content>
