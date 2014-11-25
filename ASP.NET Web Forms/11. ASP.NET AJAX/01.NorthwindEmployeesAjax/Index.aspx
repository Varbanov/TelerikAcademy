<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_01.NorthwindEmployeesAjax.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>The text here is not updated</h1>
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel ID="EmployeesUpdatePanel"
            UpdateMode="Conditional" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="EmployeesGridView"
                    AllowPaging="true" PageSize="4" DataKeyNames="EmployeeID"
                    ItemType="_01.NorthwindEmployeesAjax.Data.Employees"
                    EnableViewState="true" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="EmployeesGridView_SelectedIndexChanged"
                    SelectMethod="EmployeesGridView_GetData"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:CommandField SelectText="Select" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

           <asp:UpdateProgress ID="EmployeeUpdateProgress" runat="server"
            AssociatedUpdatePanelID="EmployeesUpdatePanel">
            <ProgressTemplate>
                Updating.....
                <img src="loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="OrdersUpdatePanel"
             UpdateMode="Always" runat="server">
            <ContentTemplate>
                <asp:GridView ID="OrdersGridView"
                    AllowPaging="true" PageSize="10" DataKeyNames="OrderID"
                    ItemType="_01.NorthwindEmployeesAjax.Data.Orders"
                    EnableViewState="true" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="EmployeesGridView_SelectedIndexChanged"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                        <asp:BoundField DataField="ShipName" HeaderText="Ship Name" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

      


        <asp:Timer runat="server" ID="TimerTimeRefresh" Interval="3000"></asp:Timer>
    </form>
</body>
</html>
