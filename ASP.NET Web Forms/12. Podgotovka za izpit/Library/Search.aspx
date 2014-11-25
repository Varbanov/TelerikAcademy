<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Library.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <%: Page.Title %>
        <asp:Literal  ID="LiteralSarchQuery" runat="server"
             Mode="Encode">
        </asp:Literal>
    </h1>

    <asp:Repeater ID="RepeaterBooks" runat="server"
         SelectMethod="RepeaterBooks_GetData" ItemType="Library.Models.Book">
       <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink NavigateUrl='<%# string.Format("~/BookDetails.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkBook" Text="<%# GetTitle(Item) %>" />
                (Category: <%#: Item.Category.Name %>)                 
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>


    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
