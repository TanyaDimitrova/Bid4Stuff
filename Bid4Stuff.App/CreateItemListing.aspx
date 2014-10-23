<%@ Page
    Title="Create Item"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="CreateItemListing.aspx.cs"
    Inherits="Bid4Stuff.App.CreateItemListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>New Item Listing</h2>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="ItemName" runat="server" Text="Name" AssociatedControlID="ItemNameInput" CssClass="col-lg-2 control-label" />
                <div class="col-lg-10">
                    <asp:TextBox ID="ItemNameInput" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="ItemDescription" runat="server" Text="Description" AssociatedControlID="ItemDescriptionInput" CssClass="col-lg-2 control-label" />
                <div class="col-lg-10">
                    <asp:TextBox ID="ItemDescriptionInput" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="ItemPrice" runat="server" Text="Price" AssociatedControlID="ItemPriceInput" CssClass="col-lg-2 control-label" />
                <div class="col-lg-10">
                    <asp:TextBox ID="ItemPriceInput" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblEndDate" runat="server" Text="End Date" AssociatedControlID="EndDateInput" CssClass="col-lg-2 control-label" />
                <div class="col-lg-10">
                    <asp:Calendar ID="EndDateInput" runat="server" EnableViewState="true" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCategory" runat="server" Text="Category" AssociatedControlID="DropDownListCategory" CssClass="col-lg-2 control-label" />
                <div class="col-lg-4">
                    <asp:DropDownList
                        ID="DropDownListCategory"
                        DataValueField="Id"
                        DataTextField="Name"
                        runat="server"
                        CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="ItemImage" runat="server" Text="Image" AssociatedControlID="ItemImageInput" CssClass="col-lg-2 control-label" />
                <div class="col-lg-4">
                    <asp:FileUpload ID="ItemImageInput" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button
                        ID="ButtonCancel"
                        runat="server"
                        Text="Cancel"
                        OnClick="ButtonCancel_Click"
                        CssClass="btn btn-default" />
                    <asp:Button
                        ID="ButtonSubmit"
                        runat="server"
                        Text="Submit"
                        OnClick="ButtonSubmit_Click"
                        CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
