<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_01.Continents.Index" ViewStateMode="Enabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Continents</title>
    <link href="Css/index.css" rel="stylesheet" />
</head>
<body>
    <ef:EntityDataSource ID="ContinentsDataSource" runat="server" OnContextCreating="Get_Data"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Continents">
    </ef:EntityDataSource>

    <ef:EntityDataSource ID="CountriesDataSource" runat="server" OnContextCreating="Get_Data"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Countries"
        Include="Continent"
        Where="it.ContinentId=@ContId">
        <WhereParameters>
            <asp:ControlParameter Name="ContId" Type="Int32"
                ControlID="ContinentsListBox" />
        </WhereParameters>
    </ef:EntityDataSource>

    <ef:EntityDataSource ID="TownsDataSource" runat="server" OnContextCreating="Get_Data"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EnableViewState="true"
        EntitySetName="Towns"
        Where="it.CountryId=@CountryId">
        <WhereParameters>
            <asp:ControlParameter Name="CountryId" Type="Int32"
                ControlID="CountriesGridView" />
        </WhereParameters>
    </ef:EntityDataSource>


    <form id="form1" runat="server">
        <h2>You can check it out for Bulgarian, German or Austrian towns as they are more :)</h2>
        <h2>Continents</h2>
        <asp:ListBox ID="ContinentsListBox" runat="server"
            DataSourceID="ContinentsDataSource"
            DataTextField="Name"
            DataValueField="Id"
            ItemType="Continents.Models.Continent"
            SelectionMode="Single"
            AutoPostBack="true"></asp:ListBox>

        <h2>Countries</h2>
        <asp:GridView ID="CountriesGridView" runat="server"
            AllowPaging="True" PageSize="2"
            AllowSorting="True" AutoPostBack="true"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            DataSourceID="CountriesDataSource" EmptyDataText="No countries available in this category.">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Continent.Name" HeaderText="Continent" SortExpression="Continent.Name" />
                <asp:CommandField SelectText="View" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <h2>Towns</h2>
        <asp:ListView ID="TownsListView" runat="server"
            ItemType="Continents.Models.Town" DataKeyNames="Id"
            SelectMethod="TownsListView_GetData"
            UpdateMethod="TownsListView_UpdateItem"
         
            DataSourceID="TownsDataSource">
            <LayoutTemplate>
                <table class="gridview"
                    rules="all" border="1"
                    style="border-collapse: collapse;">
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton Text="Town name" runat="server"
                                    ID="TownsSortByName" CommandName="Sort"
                                    CommandArgument="Name" />
                            </th>
                            <th>
                                <asp:LinkButton Text="Population" runat="server"
                                    ID="TownsSortByPopulation" CommandName="Sort"
                                    CommandArgument="Population" />
                            </th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="3">
                                <asp:DataPager ID="TownsDataPager" runat="server"
                                    PagedControlID="TownsListView" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="true"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ShowLastPageButton="true"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                                <asp:LinkButton runat="server" ID="TownsButtonInsert" Text="Insert"
                                    CssClass="btn btn-primary pull-right" OnClick="TownsButtonInsert_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Population %></td>
                    <td>
                        <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" />
                        <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="EditTownNameTb" Text="<%#: BindItem.Name %>" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="EditTownPopulationTb" Text="<%#: BindItem.Population %>" />
                    </td>
                    <td>
                        <asp:LinkButton runat="server" ID="EditTownSaveBtn" Text="Save" CommandName="Update" />
                        <asp:LinkButton runat="server" ID="EditTownCancelBtn" Text="Cancel" CommandName="Cancel" />
                    </td>
                </tr>
            </EditItemTemplate>

        </asp:ListView>
        <br />







    </form>
</body>
</html>
