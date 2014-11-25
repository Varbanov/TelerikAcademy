<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="_03.CookiesExchange.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <div>
            <asp:Button runat="server" ID="btn" Text="Back" OnClick="OnBtnClicked" />
            <br />
            <asp:Literal runat="server" ID="Literal"></asp:Literal>
        </div>
    </form>
</body>
</html>
