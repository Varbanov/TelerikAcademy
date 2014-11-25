<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="NewsExam.ArticleDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="FormViewArticleDetails" runat="server"
        ItemType="NewsExam.Models.Article"
        SelectMethod="FormViewArticleDetails_GetItem">

        <ItemTemplate>
            <table style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <td colspan="2">
                           <%-- <asp:Panel ID="theLikes" runat="server">
                                <div class="like-control col-md-1">
                                    <div>Likes</div>
                                    <div>
                                        <a class="btn btn-default glyphicon glyphicon-chevron-up" href="#"></a>
                                        <span class="like-value"><%#: GetLikes(Item) %></span>
                                        <a class="btn btn-default glyphicon glyphicon-chevron-down" href="#"></a>
                                    </div>
                                </div>
                            </asp:Panel>--%>

                            <h2><%# string.Format("{0} <small>Category: {1}</small>", Item.Title, Item.Category.Name )%></h2>
                            <p><%#: Item.Content %></p>
                            <p>
                                <span><%#: string.Format("Author: {0}", Item.AppUser.UserName) %></span>
                                <span class="pull-right"><%#: string.Format("{0}", Item.DateCreated) %></span>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>


</asp:Content>
