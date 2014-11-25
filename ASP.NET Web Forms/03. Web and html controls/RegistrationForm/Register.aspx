<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegistrationForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegisterForm" runat="server">
        First name:
        <asp:TextBox ID="TextBoxFirstName" runat="server" />
        <br />
        Last name:
        <asp:TextBox ID="TextBoxLastName" runat="server" />
        <br />
        Faculty number:
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server" />
        <br />

        University:
        <asp:DropDownList ID="DropDownUniversity" runat="server">
            <asp:ListItem Text="SU" />
            <asp:ListItem Text="TU" />
            <asp:ListItem Text="MU" />
        </asp:DropDownList>
        <br />

        Specialty:
        <asp:DropDownList ID="DropDownSpecialty" runat="server">
            <asp:ListItem Text="IT" />
            <asp:ListItem Text="Medicine" />
            <asp:ListItem Text="Computer Science" />
        </asp:DropDownList>
        <br />

        Courses:
        <br />
       <asp:ListBox ID="ListBoxCourses" SelectionMode="Multiple" runat="server">
           <asp:ListItem Text="ASP.NET WebForms" />
           <asp:ListItem Text="ASP.NET MVC" />
           <asp:ListItem Text="Anesthesiology" />
       </asp:ListBox>

        <asp:Button Text="Submit" ID="ButtonSubmit" OnClick="OnRegisterButtonClicked" runat="server" />
    </form>

    <asp:Panel ID="ResultPanel" Visible="false" runat="server"></asp:Panel>

</body>
</html>
