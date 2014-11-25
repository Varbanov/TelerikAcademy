<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShowTextInTextboxes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <asp:Label Text="Input: " ID="LabelInput" runat="server" />
        <asp:TextBox ID="TextboxInput" runat="server" />
        <br />
        Result: 
        <br />
        <asp:Label Text="" ID="LabelResult" runat="server" />
        <br />
        <asp:TextBox ID="TextBoxResult" runat="server" />
        <br />
        <asp:Button ID="buttonSubmit" OnClick="buttonSubmit_Click" Text="Generate" runat="server" />
    </form>
</body>
</html>
