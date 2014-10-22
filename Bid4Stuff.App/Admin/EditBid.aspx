<%@ Page
    Title="Bid Editor"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EditBid.aspx.cs"
    Inherits="Bid4Stuff.App.Admin.EditBid" %>

<asp:Content ID="BidEditor" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="form-horizontal">
            <fieldset>
                <legend>Bid Editor</legend>
                <div class="form-group">
                    <asp:Label Text="Item Name" runat="server" AssociatedControlID="ItemNameTextBox" class="col-lg-2 control-label" />
                    <div class="col-lg-10">
                        <asp:TextBox runat="server" ID="ItemNameTextBox" Text="" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Item Price" runat="server" AssociatedControlID="ItemPriceTextBox" class="col-lg-2 control-label" />
                    <div class="col-lg-10">
                        <asp:TextBox runat="server" ID="ItemPriceTextBox" Text="" class="form-control"/>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Item bidding end date" runat="server" AssociatedControlID="BidEndDate" class="col-lg-2 control-label" />
                    <div class="col-xs-10">
                        <asp:Calendar ID="BidEndDate" runat="server" EnableViewState="true"></asp:Calendar>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:LinkButton
                            ID="CancelEditBtn"
                            Text="Cancel"
                            class="btn btn-default"
                            runat="server"
                            OnClick="CancelEditBtn_Click"
                            OnClientClick="return confirm('Are you sure you want to stop editting following bid?');" />

                        <asp:LinkButton
                            ID="SaveEditBtn"
                            Text="Save Changes"
                            class="btn btn-primary"
                            runat="server"
                            OnClick="SaveEditBtn_Click" />
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
