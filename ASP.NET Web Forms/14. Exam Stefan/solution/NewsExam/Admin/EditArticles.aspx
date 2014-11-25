<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsExam.Admin.EditArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="NewsExam.Models.Article"
        SelectMethod="ListViewCategories_GetData"
        UpdateMethod="ListViewCategories_UpdateItem"
        DeleteMethod="ListViewCategories_DeleteItem"
        InsertMethod="ListViewCategories_InsertItem"
        DataKeyNames="Id"
        InsertItemPosition="LastItem">
        <LayoutTemplate>

            <asp:LinkButton CssClass="btn btn-default" Text="Sort By Title" runat="server"
                ID="LinkButtonSortByTitle" CommandName="Sort"
                CommandArgument="Title" />
            <asp:LinkButton CssClass="btn btn-default" Text="Sort By Date" runat="server"
                ID="LinkButtonSortByDate" CommandName="Sort"
                CommandArgument="DateCreated" />
            <asp:LinkButton CssClass="btn btn-default" Text="Sort By Category" runat="server"
                ID="LinkButtonSortByCategory" CommandName="Sort"
                CommandArgument="CategoryId" />
            <div></div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>

            <asp:DataPager runat="server" ID="DataPagerCategories"
                PagedControlID="ListViewCategories" PageSize="5">
                <Fields>
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField />
                </Fields>
            </asp:DataPager>

        </LayoutTemplate>
        <ItemTemplate>
            <h3>
                <%#: Item.Title %>
                <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="Edit" CommandName="Edit" />
                <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" Text="Delete" CommandName="Delete" />
            </h3>

            <p><%#: string.Format("Category: {0}", Item.Category.Name) %></p>

            <p><%#: string.Format("{0}...", Item.Content.Substring(0, Item.Content.Length > 300 ? 300 : Item.Content.Length - 1)) %></p>

            <p><%#: string.Format("Likes count: {0}", Item.Likes.Count) %></p>

            <div><i><%#: string.Format("By {0} created on: {1}", Item.AppUser.UserName, Item.DateCreated) %></i></div>

        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Title %>" />

                <asp:LinkButton runat="server" CssClass="btn btn-info" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />

                <br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxTitle"
                    ErrorMessage="Title field is required." />
                <br />
                <asp:DropDownList ID="DropDownCategories" runat="server" ItemType="NewsExam.Models.Category"
                    DataTextField="Name"
                    DataValueField="Id"
                    SelectMethod="DropDownCategories_GetData"
                    SelectedValue="<%# BindItem.CategoryId %>">
                </asp:DropDownList>
                <br />
                <br />
                <asp:TextBox CssClass="col-md-12" runat="server" ID="TextBoxArticleContent"
                    TextMode="MultiLine"
                    Text="<%#: BindItem.Content %>" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxArticleContent"
                    ErrorMessage="Content field is required." />
                <br />

            </div>
        </EditItemTemplate>

        <InsertItemTemplate>

            <div class="row">
                <h3>
                    <asp:Label Text="Title" AssociatedControlID="TextBoxTitle" runat="server" />
                    <asp:TextBox  runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Title %>" />
                </h3>
                <p>
                    <asp:DropDownList ID="DropDownCategories" runat="server" ItemType="NewsExam.Models.Category"
                        DataTextField="Name"
                        DataValueField="Id"
                        SelectMethod="DropDownCategories_GetData"
                        SelectedValue="<%# BindItem.CategoryId %>">
                    </asp:DropDownList>
                </p>
                <p>
                    Content:
                    <asp:TextBox CssClass="col-md-12" runat="server" ID="TextBoxArticleContent"
                        TextMode="MultiLine"
                        Text="<%#: BindItem.Content %>" />
                </p>
                <div>
                    <asp:LinkButton runat="server" CssClass="btn btn-info" ID="LinkButtonInsert" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </div>
            </div>

        </InsertItemTemplate>
    </asp:ListView>



</asp:Content>
