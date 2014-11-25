<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsExam.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:ListView ID="ListViewCategories" runat="server" 
        ItemType="NewsExam.Models.Category"
         SelectMethod="ListViewCategories_GetData"
         UpdateMethod="ListViewCategories_UpdateItem"
         DeleteMethod="ListViewCategories_DeleteItem"
         InsertMethod="ListViewCategories_InsertItem"
         InsertItemPosition="LastItem"
         DataKeyNames="Id">

        <LayoutTemplate>
            <table class="gridview" id="MainContent_GridViewCategories"
                style="border-collapse: collapse;">
                <tbody>
                    <tr>
                        <th scope="col" colspan="2">
                            <asp:LinkButton CssClass="btn btn-default" Text="Caterory Name" runat="server"
                                ID="LinkButtonSortByCategory" CommandName="Sort"
                                CommandArgument="Name" />
                        </th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder">

                    </asp:PlaceHolder>
                    <tr>
                        <td colspan="2">
                            <asp:DataPager runat="server" ID="DataPagerCategories"
                                PagedControlID="ListViewCategories" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Name %></td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" Text="Delete" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                    <br />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxName"
                        ErrorMessage="Name field is required." />
                </td>
                <td>
                    <asp:LinkButton runat="server" CssClass="btn btn-info" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                </td>
                <td>
                    <asp:LinkButton runat="server" CssClass="btn btn-info" ID="LinkButtonInsert" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

</asp:Content>
