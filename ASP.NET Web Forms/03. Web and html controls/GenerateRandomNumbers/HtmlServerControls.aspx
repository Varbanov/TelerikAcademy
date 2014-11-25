<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlServerControls.aspx.cs" Inherits="GenerateRandomNumbers.HtmlServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label for="inputMin">Enter min value: </label>
        <input id="inputMin" type="text" runat="server" />
        <br />
        <label for="inputMax">Enter max value: </label>
        <input id="inputMax" type="text" runat="server" />
        <br />

        <input id="ButtonSubmit" type="button" runat="server" value="Generate number" onserverclick="ButtonSubmit_ServerClick" />
    </form>
    <asp:Label ID="labelResult" Text="Generated number: " runat="server" />

</body>
</html>
