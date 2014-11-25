<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintHelloFromAspx.aspx.cs" Inherits="WebFormsIntro.PrintHelloFromAspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label Text="Hello, ASP" ID="labelName" runat="server" />
            </h1>
            <h1>
                <asp:Label Text="" ID="labelPath" runat="server" />
            </h1>
        </div>
    </form>
</body>
</html>
