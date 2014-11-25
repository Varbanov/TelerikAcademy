<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSearchPage.aspx.cs" Inherits="_01.CarsSearch.CarSearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        Producer:
            <asp:DropDownList ID="ProducersDropDown" runat="server" 
                AutoPostBack="True" 
                DataTextField="Name" 
                OnSelectedIndexChanged="OnProducerSelectedIndexChanged">
            </asp:DropDownList>

        <br />

        Model:
            <asp:DropDownList ID="ModelsDropDown" runat="server" >
            </asp:DropDownList>

        <br />

        Extras:
            <asp:CheckBoxList ID="ExtrasCheckBox" runat="server"
                 DataTextField="Name">
            </asp:CheckBoxList>

        <br />

        Engine:
            <asp:RadioButtonList ID="EnginesRadioButton" runat="server">
            </asp:RadioButtonList>

        <br />

        <asp:Button Text="Search" runat="server" OnClick="OnSearchButtonClicked" />

        <br />
        <div runat="server" id="Result" visible="false">
            <h2>Result:</h2>
        </div>
    </form>
</body>
</html>
