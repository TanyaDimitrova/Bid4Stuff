<%@ Page Title="More details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemDetails.aspx.cs" Inherits="Bid4Stuff.App.ItemDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-10 col-md-offset-1">
            <asp:DetailsView CssClass="table" ID="DetailsViewItems" ItemType="Bid4Stuff.Models.Item" runat="server" BorderStyle="None" BorderColor="#EFEFEF" AutoGenerateRows="False">
                <Fields>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="row row-md-2">
                                <img src="<%#: Item.ImagePath.Substring(1) %>" class="img-tumbnail col-md-4" />
                                <div class="col-md-4">
                                    <h3 class="span-bold">Description: </h3>
                                    <%#: Item.Description %>
                                    <p>
                                        <h3 class="span-bold  ">Owner contact: </h3>
                                    <%#: Item.Owner.UserName %>
                                    </p>
                                    <p>
                                        <h3 class="span-bold  ">Published on: </h3>
                                    <%#: Item.StartDate %>
                                    </p>
                                    <p>
                                        <h3 class="span-bold  ">Ends on: </h3>
                                    <%#: Item.EndDate %>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <p>
                                <asp:LinkButton Text="Bid" runat="server" ID="btnBid" Visible="false" PostBackUrl='<%#"~/MakeBid.aspx?ItemId="+ Item.Id%>' CssClass="btn btn-lg btn-info" />
                            </p>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
    </div>
</asp:Content>
