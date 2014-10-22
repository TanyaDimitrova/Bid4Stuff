<%@ Page Title="Bid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bid.aspx.cs" Inherits="Bid4Stuff.App.Bid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Make bid for item
        <asp:Literal Text="" runat="server" />
    </h2>
    <div class="input-group">
        <asp:Label ID="LabelBidPrice" runat="server" Text="Price" AssociatedControlID="InputBidPrice" class="input-group-addon"/>
        <asp:TextBox ID="InputBidPrice" runat="server" CssClass="form-control"/>
        <asp:Button Text="Make Bid" ID="ButtonMakeBid" runat="server" CssClass="btn btn-info"/>
    </div>
</asp:Content>

