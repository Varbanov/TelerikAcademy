<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteViewState.aspx.cs" Inherits="_04.DeleteViewState.DeleteViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-2.0.3.js"></script>
</head>
<body>
     <form id="MainForm" runat="server">
            <div>
                <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
                <asp:Button OnClick="OnButtonClicked" runat="server" Text="Submit" />
                <button id="del-btn" >Delete ViewState</button>
                <asp:Label ID="Label" runat="server"></asp:Label>

            </div>
        </form>
        <script>
            $(document).ready(
                $("#MainForm").on("click", "#del-btn", function () {
                    $("#__VIEWSTATE").val("");
                }));
        </script>
</body>
</html>
