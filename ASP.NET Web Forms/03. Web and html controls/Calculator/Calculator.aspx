<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator"
    EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="css/calculator.css" rel="stylesheet" />
</head>
<body>
        <form id="calculator" runat="server">
            <input type="text" runat="server" name="valueInMemory" id="valueInMemory" readonly="true" hidden="hidden" />
            <input type="text" runat="server" name="lastSelectedOperator" id="lastSelectedOperator" readonly="true" hidden="hidden" />
            <input type="text" runat="server" value="0" id="resultBox" readonly="true" />

            <ul>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="1" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="2" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="3" /></li>
                <li>
                    <input runat="server" onserverclick="OnOperatorButtonClicked" type="button" value="+" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="4" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="5" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="6" /></li>
                <li>
                    <input runat="server" onserverclick="OnOperatorButtonClicked" type="button" value="-" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="7" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="8" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="9" /></li>
                <li>
                    <input runat="server" onserverclick="OnOperatorButtonClicked" type="button" value="*" /></li>
                <li>
                    <input runat="server" onserverclick="OnNumberButtonClicked" type="button" value="0" /></li>
                <li>
                    <input runat="server" onserverclick="OnRootButtonClicked" type="button" value="√" /></li>
                <li>
                    <input runat="server" onserverclick="OnOperatorButtonClicked" type="button" value="/" /></li>
                <li>
                    <input runat="server" onserverclick="OnResultButtonClicked" type="button" value="=" /></li>
            </ul>
    </form>
</body>
</html>
