<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="Library.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormViewBookDetails" runat="server"
        ItemType="Library.Models.Book"
        SelectMethod="FormViewBookDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%#: Page.Title %></h1>
                <p class="book-author"><i>by <%#: Item.Author %></i></p>
                <p class="book-author"><i>ISBN <%#: Item.Isbn%></i></p>
                <p class="book-isbn">
                    <i>Web site:
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a>
                    </i>
                </p>
            </header>
            <div class="row-fluid">
                <div class="col-md-12 book-description">
                    <p>
                        <%#: Item.Description %>
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
