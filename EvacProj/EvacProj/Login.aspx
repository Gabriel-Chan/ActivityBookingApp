<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EvacProj.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">



        .style1
        {
            width: 100%;
        }
        .auto-style1 {
            width: 92px;
            height: 30px;
        }
        .auto-style2 {
            height: 30px;
        }
        .style2
        {
            width: 92px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Login Page</h1>
        <table class="style1">
            <tr>
                <td class="auto-style1">UserName:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="225px" />
        <br />
        <asp:Label ID="lblInvalid" runat="server" style="color: #FF0000" Text="Invalid UserName and/or Password." Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
