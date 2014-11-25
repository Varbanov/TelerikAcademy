<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="_02.Employees.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DetailsView runat="server" ID="DetailsView"
            AutoGenerateRows="true" AllowPaging="true" />
        <br />
        <asp:Button ID="BackBtn" Text="Back to employees" OnClick="OnBackBtnClicked" runat="server" />
    </form>
</body>
</html>
