<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Validation.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Registration</h2>
        <p>
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div>
            <h4>Create a new account</h4>
            <hr />
            <asp:ValidationSummary runat="server" />
            <div>
                <asp:Label runat="server" AssociatedControlID="EmailTextBox">E-mail</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="EmailTextBox" placeholder="example@mail.com" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email is required." />
                    <div>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidatorEmail"
                            runat="server"
                            ErrorMessage="Incorrect email!"
                            ControlToValidate="EmailTextBox" EnableClientScript="True"
                            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                    </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        ErrorMessage="The password is required." />
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" >Confirm password</asp:Label>
                <div >
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        Display="Dynamic" ErrorMessage="The two passwords do not match." />
                </div>
            </div>
            <div >
                <asp:Label runat="server" AssociatedControlID="FirstName" >First name</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="FirstName"  TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                        ErrorMessage="The first name field is required." />
                </div>
            </div>
            <div >
                <asp:Label runat="server" AssociatedControlID="SecondName">Second name</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="SecondName" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SecondName"
                        ErrorMessage="The second name field is required." />
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="PhoneNumber">Phone</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="PhoneNumber" TextMode="Phone" placeholder="1-234-567-8901" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                        ErrorMessage="The phone number field is required." />
                    <div>
                        <asp:RegularExpressionValidator
                            ID="PhoneNumberRegExp"
                            runat="server"
                            ErrorMessage="Phone number is incorrect!"
                            ControlToValidate="PhoneNumber" EnableClientScript="True"
                            ValidationExpression="1?\W*([2-9][0-8][0-9])\W*([2-9][0-9]{2})\W*([0-9]{4})(\se?x?t?(\d*))?">
                    </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="Age">Age</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Age" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
                        ErrorMessage="The age field is required." />
                    <div>
                        <asp:RangeValidator ID="RangeValidatorAge" runat="server"
                            ErrorMessage="Age must be between 18 and 81"
                            ControlToValidate="Age" MaximumValue="81" MinimumValue="18" Text="Age must be between 18 and 81"></asp:RangeValidator>
                    </div>
                </div>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="Address">Address</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Address" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                         ErrorMessage="The local address field is required." />
                </div>
            </div>
            <div>
                <div>
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
