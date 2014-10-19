<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItemListing.aspx.cs" Inherits="Bid4Stuff.App.CreateItemListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Item Listing</h2>
    <br />
    <div class="input-group">
    <asp:Label ID="ItemName" runat="server" Text="Name" AssociatedControlID="ItemNameInput" class="input-group-addon"/>
    <asp:TextBox ID="ItemNameInput" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <asp:Button ID="ButtonSubmit" runat="server" 
        Text="Submit" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary"/>
</asp:Content>
