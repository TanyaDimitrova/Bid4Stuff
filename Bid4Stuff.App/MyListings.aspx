<%@ Page Title="My Listings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyListings.aspx.cs" Inherits="Bid4Stuff.App.MyListings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:HyperLink runat="server" ID="create" CssClass="btn btn-primary" NavigateUrl="CreateItemListing">Create new listing</asp:HyperLink>
    <asp:ListView runat="server" ID="ItemListing" ItemType="Bid4Stuff.Models.Item">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </LayoutTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <div class="product-description">
                <h4><a href='<%#: "ItemDetails.aspx?id=" + Item.Id  %>'><%#: Item.Name %></a></h4>
                Price: <%#: String.Format("{0:c}", Item.Price) %>
            </div>

        </ItemTemplate>

    </asp:ListView>
    <div class="pager-container text-center">
        <asp:DataPager runat="server" ID="MyListingsPager" PagedControlID="ItemListing" PageSize="5">
            <Fields>
                <asp:NextPreviousPagerField
                    ShowFirstPageButton="true"
                    ShowLastPageButton="false"
                    ShowPreviousPageButton="true"
                    ShowNextPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField
                    ShowFirstPageButton="false"
                    ShowLastPageButton="true"
                    ShowPreviousPageButton="false"
                    ShowNextPageButton="true" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>
