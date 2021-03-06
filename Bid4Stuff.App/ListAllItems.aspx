﻿<%@ Page Title="All offers" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ListAllItems.aspx.cs" Inherits="Bid4Stuff.App.ListAllItems" %>

<asp:Content ID="ContentAllItems" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <asp:ListView ID="ListViewItems" runat="server"
                SelectMethod="ListViewItems_GetData"
                ItemType="Bid4Stuff.App.Models.OfferViewModel"
                OnItemDataBound="ListViewItems_ItemDataBound">

                <EmptyDataTemplate>
                    <h3 class="text-center">No offers yet!</h3>
                </EmptyDataTemplate>

                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server"></th>
                                <th runat="server">
                                    <asp:LinkButton runat="server" CommandArgument="Name" CommandName="Sort">Name</asp:LinkButton>
                                </th>
                                <th runat="server">
                                    <asp:LinkButton runat="server" CommandArgument="Price" CommandName="Sort">Price</asp:LinkButton>
                                </th>
                                <th runat="server">
                                    <asp:LinkButton runat="server" CommandArgument="CategoryName" CommandName="Sort">Category</asp:LinkButton>
                                </th>
                                <th runat="server">
                                    <asp:LinkButton runat="server" CommandArgument="StartDate" CommandName="Sort">Added</asp:LinkButton>
                                </th>
                                <th runat="server">
                                    <asp:LinkButton runat="server" CommandArgument="TimeLeft" CommandName="Sort">Time Left</asp:LinkButton>
                                </th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td class="col-md-2">
                            <asp:Image ImageUrl='<%# Item.ImagePath %>' runat="server" CssClass="img-responsive" />
                        </td>
                        <td><a href='<%#: "ItemDetails.aspx?id=" + Item.ItemId  %>'><%#: Item.Name %></td>
                        <td><%#: Item.Price %></td>
                        <td><%#: Item.CategoryName%></td>
                        <td><%#: Item.StartDate %></td>
                        <td class="col-md-2">
                            <%#: Item.TimeLeft.Split()[0] +" "+ Item.TimeLeft.Split()[1]  %>
                            <div>
                                <asp:LinkButton Text="Bid" runat="server" ID="btnBidLAO" Visible="false" PostBackUrl='<%#"~/MakeBid.aspx?ItemId="+ Item.ItemId%>' class="btn btn-xs btn-info" />
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPagerCustomers" runat="server"
                PagedControlID="ListViewItems" PageSize="10"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false"
                        ShowPreviousPageButton="true" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="true"
                        ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
