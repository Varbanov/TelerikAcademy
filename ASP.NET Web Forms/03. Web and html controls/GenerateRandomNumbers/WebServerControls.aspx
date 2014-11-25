<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServerControls.aspx.cs" Inherits="GenerateRandomNumbers.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Enter min value: " AssociatedControlID="TextBoxMin" runat="server" />
        <asp:TextBox ID="TextBoxMin" runat="server" />
        <br />
        <asp:Label Text="Enter max value: " AssociatedControlID="TextBoxMax" runat="server" />
        <asp:TextBox ID="TextBoxMax" runat="server" />
        <br />
        <asp:Button ID="buttonSubmit" OnClick="ButtonSubmit_Click" Text="Generate"  runat="server" />
    </form>
    <br />
    <asp:Label ID="labelResult" Text="Generated number: " runat="server" />
</body>
</html>
