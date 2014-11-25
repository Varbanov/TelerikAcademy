<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintHello.aspx.cs" Inherits="WebFormsIntro.PrintHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="textboxName" runat="server" />
            <br />
            <asp:Button ID="buttonPrint" Text="Print Hello" OnClick="buttonPrint_Click" runat="server" />
            <br />
            <h1>
                <asp:Label Text="Hello" ID="labelName" runat="server" />
            </h1>
        </div>
    </form>
</body>
</html>
