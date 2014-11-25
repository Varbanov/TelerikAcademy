<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Library.Books" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%#: Page.Title %></h1>
        <div class="search-button">
            <div class="form-search">
                <div class="input-append">
                    <asp:TextBox ID="TextBoxSearchParam" runat="server"
                        CssClass="col-md-3 search-query">

                    </asp:TextBox>
                    <asp:LinkButton ID="LinkButtonSearch"
                        Text="Search" OnClick="LinkButtonSearch_Click"
                        CssClass="btn btn-primary" runat="server" />
                </div>
            </div>
        </div>
    </div>



    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="Library.Models.Category"
        SelectMethod="ListViewCategories_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2>
                    <%#: Item.Name %>
                </h2>
                <asp:ListView ID="RepeaterBooks" runat="server"
                    ItemType="Library.Models.Book" DataSource="<%# Item.Books %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        No books in this category.
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink
                                Text='<%# string.Format(@"""{0} by <i>{1}</i>""", Item.Title, Item.Author)  %>'
                                NavigateUrl='<%#: string.Format("~/BookDetails.aspx?id={0}", Item.Id) %>' runat="server" />
                        </li>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </ItemTemplate>
    </asp:ListView>

    <%-- <asp:Repeater ID="RepeaterCategories" runat="server"
        ItemType="Library.Models.Category"
        SelectMethod="RepeaterCategories_GetData">
        <ItemTemplate>
            <%#: Item.Name %>
        </ItemTemplate>
    </asp:Repeater>--%>
</asp:Content>
