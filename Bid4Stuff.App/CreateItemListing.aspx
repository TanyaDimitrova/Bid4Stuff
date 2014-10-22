<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItemListing.aspx.cs" Inherits="Bid4Stuff.App.CreateItemListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Item Listing</h2>
    <br />
    <div class="input-group">
    <asp:Label ID="ItemName" runat="server" Text="Name" AssociatedControlID="ItemNameInput" class="input-group-addon"/>
    <asp:TextBox ID="ItemNameInput" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="lblCategory" runat="server" Text="Category" AssociatedControlID="DropDownListCategory" class="input-group-addon"/>
    <asp:DropDownList ID="DropDownListCategory" DataValueField="Id" DataTextField="Name" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="ItemDescription" runat="server" Text="Description" AssociatedControlID="ItemDescriptionInput" class="input-group-addon"/>
    <asp:TextBox ID="ItemDescriptionInput" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="ItemImage" runat="server" Text="Image" AssociatedControlID="ItemImageInput" class="input-group-addon"/>
    <asp:FileUpload ID="ItemImageInput" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="ItemPrice" runat="server" Text="Price" AssociatedControlID="ItemPriceInput" class="input-group-addon"/>
    <asp:TextBox ID="ItemPriceInput" runat="server" CssClass="form-control"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" AssociatedControlID="StartDateInput" class="input-group-addon"/>
    <asp:Calendar ID="StartDateInput" runat="server" CssClass="form-control" EnableViewState="true"/>
    </div>
    <br />
    <div class="input-group">
    <asp:Label ID="lblEndDate" runat="server" Text="End Date" AssociatedControlID="EndDateInput" class="input-group-addon"/>
    <asp:Calendar ID="EndDateInput" runat="server" CssClass="form-control"  EnableViewState="true"/>

    </div>
    <br />
    <asp:Button ID="ButtonSubmit" runat="server" 
        Text="Submit" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary"/>
</asp:Content>
