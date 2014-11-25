<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NewsExam.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>News</h1>

    <asp:ListView ID="ListViewArticles"
        runat="server"
        ItemType="NewsExam.Models.Article"
        SelectMethod="ListViewArticles_GetData">
        <LayoutTemplate>
            <h2>Most popular articles</h2>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>'
                        Text='<%#: Item.Title %>' runat="server"></asp:HyperLink>
                    <small><%#: Item.Category.Name %></small>
                </h3>
                <p>
                    <%# Item.Content.Substring(0, Item.Content.Length > 300 ? 300 : Item.Content.Length - 1) + "..." %>
                </p>
                <p><%#: string.Format("Likes: {0}", Item.Likes.Count) %></p>
                <div>
                    <i><%#: string.Format("by {0} created on {1}", Item.AppUser.UserName, Item.DateCreated) %></i>

                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:ListView ID="ListViewCategories"
        runat="server"
        ItemType="NewsExam.Models.Category"
        SelectMethod="ListViewCategories_GetData"
         GroupItemCount="2">
        <LayoutTemplate>
            <h2>All categories</h2>
            <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
        </LayoutTemplate>
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView ID="ListViewArticlesByCategory" runat="server"
                    ItemType="NewsExam.Models.Article"
                    DataSource="<%# GetArticlesByCategory(Item.Id) %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <p>No articles.</p>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>'
                                Text='<%# string.Format("<strong>{0}</strong> by <i>{1}</i>", Item.Title, Item.AppUser.UserName) %>' runat="server"></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
