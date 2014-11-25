<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server"
            ID="EmployeesGridView"
            AutoGenerateColumns="false"
            AllowPaging="true"
            DataKeyNames="EmployeeID"
            OnPageIndexChanging="EmployeesGridView_PageIndexChanging">

            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First name" />
                <asp:BoundField DataField="LastName" HeaderText="Last name" />
                <asp:HyperLinkField Text="More" DataNavigateUrlFields="EmployeeID, FirstName"
                    DataNavigateUrlFormatString="~\Employees.aspx?id={0}" />
            </Columns>
        </asp:GridView>

        <br />

        <asp:ListView ID="EmployeeListView" ItemType="_05.EmployeesDetailsWithListView.Data.Employee" runat="server">
            <ItemTemplate>
                <h3>Details:</h3>
                <p><%#: Item.FirstName + " " + Item.LastName %></p>
                <p>City: <%#: Item.City %></p>
                <p>City: <%#: Item.Country %></p>
                <p>City: <%#: Item.Address %></p>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
