<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
</head>
<body>
    <form id="formSumator" runat="server">
    <h1>Sumator</h1>
        First number:
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        Second number:
        <asp:TextBox ID="TextBoxSecondNumber" runat="server" />  
        <br />
        <asp:Button Text="Calculate Sum" OnClick="ButtonCalculateSum_Click" ID="ButtonCalculateSum" runat="server" />
        <br />
        Sum:
        <asp:TextBox ID="TextBoxSum" ReadOnly="true" runat="server" />  
    </form>
</body>
</html>
