<%@ Page Title="MakeBid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeBid.aspx.cs" Inherits="Bid4Stuff.App.MakeBid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Make bid for item
        <asp:Literal ID="LiteralItemName" Text="" runat="server" />
    </h2>
    <div class="input-group">
        <asp:Label ID="LabelBidPrice" runat="server" Text="Price" AssociatedControlID="InputBidPrice" class="input-group-addon"/>
        <asp:TextBox ID="InputBidPrice" runat="server" CssClass="form-control"/>
        <asp:Button Text="Make Bid" ID="ButtonMakeBid" runat="server" OnClick="ButtonMakeBid_Click" CssClass="btn btn-info"/>
    </div>
</asp:Content>

