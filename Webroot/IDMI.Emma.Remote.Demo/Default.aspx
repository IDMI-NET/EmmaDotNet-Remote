<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EmmaDotNet-Remote: Demo</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="SignupSummary">
            <asp:ValidationSummary ID="vsSummary" runat="server" HeaderText="Oops! The following errors occured:" />
        </div>
        <div id="SignupForm" class="form">
            <div class="form-item">
                <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="FirstName" Text="First Name"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" ErrorMessage="First name is required." Display="Dynamic" CssClass="error-msg"></asp:RequiredFieldValidator>
            </div>
            <div class="form-item">
                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="LastName" Text="Last Name"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" ErrorMessage="Last name is required." Display="Dynamic" CssClass="error-msg"></asp:RequiredFieldValidator>
            </div>
            <div class="form-item">
                <asp:Label ID="lblEmailAddress" runat="server" AssociatedControlID="EmailAddress" Text="E-Mail Address"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" MaxLength="250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="EmailAddress" ErrorMessage="E-mail address is required." Display="Dynamic" CssClass="error-msg"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="EmailAddress" ErrorMessage="E-mail address is invalid (e.g. user@domain.com)." Display="Dynamic" CssClass="error-msg" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-buttons">
                <asp:Button ID="btnSubmitForm" runat="server" Text="Submit" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".error-msg").text("*");
        });
    </script>
</body>
</html>
