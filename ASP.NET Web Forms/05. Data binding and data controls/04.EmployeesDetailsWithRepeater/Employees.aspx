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

        <asp:Repeater ID="EmployeeRepeater" runat="server" ItemType="_04.EmployeesDetailsWithRepeater.Data.Employee">
            <ItemTemplate>
                <h3>Details:</h3>
                <table>
                    <thead>
                        <tr>
                            <th>First Name </th>
                            <th>Last Name</th>
                            <th>City</th>
                            <th>Address</th>
                            <th>Country</th>
                        </tr>
                    </thead>
                    <tbody>
                        <td><%#: Item.FirstName%></td>
                        <td><%#: Item.LastName %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Address %></td>
                        <td><%#: Item.Country %></td>
                    </tbody>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
