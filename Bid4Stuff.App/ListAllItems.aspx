<%@ Page Title="MakeBid" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="ListAllItems.aspx.cs" Inherits="Bid4Stuff.App.ListAllItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceListAllItems">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />
            <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" SortExpression="ImagePath" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="OwnerId" HeaderText="OwnerId" SortExpression="OwnerId" />
            <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
            <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceListAllItems" runat="server" ConnectionString="<%$ ConnectionStrings:Bid4StuffConnection %>" SelectCommand="SELECT * FROM [Items]"></asp:SqlDataSource>
</asp:Content>
