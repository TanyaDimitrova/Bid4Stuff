<%@ Page Title="MakeBid" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeBid.aspx.cs" Inherits="Bid4Stuff.App.MakeBid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Make bid for <strong>
            <asp:Literal ID="LiteralItemName" Text="" runat="server" />
        </strong>
    </h2>
    <br />
    <h2>
        Current top price: <strong>
            <asp:Literal ID="LiteralItemPrice" Text="" runat="server" />
        </strong>
    </h2>
    <h2>Current Bids</h2>
    <div class="row">
        <div class="col-md-4">
            <asp:ListView ID="ListViewCurrentBids" runat="server"
                          SelectMethod="ListViewCurrentBids_GetData"
                          ItemType="Bid4Stuff.Models.Bid">
                <EmptyDataTemplate>
                    <h3 class="text-center">No bids yet!</h3>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <thead>
                            <tr runat="server">
                                <th runat="server" class="text-center">Price</th>
                                <th runat="server" class="text-center">Time</th>
                                <th runat="server" class="text-center">User</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="text-center"><%#: Item.Price %></td>
                        <td class="text-center"><%#: Item.Time %></td>
                        <td class="text-center"><%#: Item.User.UserName %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <br />
    <div class="input-group">
        <asp:Label ID="LabelBidPrice" runat="server" Text="Price" AssociatedControlID="InputBidPrice" class="input-group-addon"/>
        <asp:TextBox ID="InputBidPrice" runat="server" CssClass="form-control"/>
        <asp:Button Text="Make Bid" ID="ButtonMakeBid" runat="server" OnClick="ButtonMakeBid_Click" CssClass="btn btn-info"/>
    </div>
</asp:Content>

