<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ChatChannel.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:ListView
        ID="Meesageslv"
        SelectMethod="Meesageslv_GetData"
        ItemType="ChatChannel.Models.Message"
        runat="server">
        <ItemTemplate>
            <p><%#: Item.User != null? Item.User.UserName : "anonymous" %></p>
            <p><%#: Item.Content %></p>

        </ItemTemplate>
    </asp:ListView>


</asp:Content>
