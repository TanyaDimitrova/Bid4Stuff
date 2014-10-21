<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bid4Stuff.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Timer runat="server" id="UpdateTimer" interval="1000"
               ontick="UpdateTimer_Tick" />
    <div class="jumbotron">
        <h1 class="text-center">Welcome to Bid4Stuff!</h1>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-1">
            <h2 class="text-center">Latest Added Offers</h2>
            <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger controlid="UpdateTimer"
                                              eventname="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:ListView ID="ListViewLatestAddedOffers" runat="server"
                                  SelectMethod="ListViewLatestAddedOffers_GetData"
                                  ItemType="Bid4Stuff.App.Models.OfferViewModel"
                        OnItemDataBound="ListViewLatestAddedOffers_ItemDataBound">
                        <EmptyDataTemplate>
                            <h3 class="text-center">No offers yet!</h3>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table class="table table-striped table-hover">
                                <thead>
                                    <tr runat="server">
                                        <th runat="server"></th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Price</th>
                                        <th runat="server">Added</th>
                                        <th runat="server">Time Left</th>
                                    </tr>
                                </thead>
                                <tr runat="server" id="itemPlaceholder" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="col-md-2">
                                    <asp:Image ImageUrl='<%# Item.ImagePath %>' runat="server" CssClass="img-responsive"/>
                                </td>
                                <td><%#: Item.Name %></td>
                                <td><%#: Item.Price %></td>
                                <td><%#: Item.StartDate %></td>
                                <td class="col-md-4 text-center">
                                    <%#: Item.TimeLeft %>
                                    <div>
                                        <asp:button text="Bid" runat="server" ID="btnBidLAO" Visible="false" OnClick="btnBidLAO_Click" class="btn btn-xs btn-info"/>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-5">
            <h2 class="text-center">Offers Ending Soon</h2>
            <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger controlid="UpdateTimer"
                                              eventname="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:ListView ID="ListViewOffersEndingSoon" runat="server"
                                  SelectMethod="ListViewOffersEndingSoon_GetData"
                                  ItemType="Bid4Stuff.App.Models.OfferViewModel"
                        OnItemDataBound="ListViewOffersEndingSoon_ItemDataBound">
                        <EmptyDataTemplate>
                            <h3 class="text-center">No offers yet!</h3>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table class="table table-striped table-hover">
                                <thead>
                                    <tr runat="server">
                                        <th runat="server"></th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Price</th>
                                        <th runat="server">Added</th>
                                        <th runat="server">End Date</th>
                                    </tr>
                                </thead>
                                <tr runat="server" id="itemPlaceholder" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="col-md-2">
                                    <asp:Image ImageUrl='<%# Item.ImagePath %>' runat="server" CssClass="img-responsive"/>
                                </td>
                                <td><%#: Item.Name %></td>
                                <td><%#: Item.Price %></td>
                                <td><%#: Item.StartDate %></td>
                                <td class="col-md-4 text-center">
                                    <%#: Item.TimeLeft %>
                                    <div>
                                        <asp:button text="Bid" runat="server" ID="btnBidOES" Visible="false" OnClick="btnBidOES_Click" class="btn btn-xs btn-info"/>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
