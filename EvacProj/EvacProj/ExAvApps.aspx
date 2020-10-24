<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExAvApps.aspx.cs" Inherits="EvacProj.ExAvApps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Application for
            <asp:Label ID="lblName" runat="server" Text="lblName"></asp:Label>
        </h1>
        <p>Number of pending applications:
            <asp:Label ID="lblPendApps" runat="server" Text="lblPendApps"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="ddMonths" runat="server" AutoPostBack="True">
                <asp:ListItem Value="1">January</asp:ListItem>
                <asp:ListItem Value="2">February</asp:ListItem>
                <asp:ListItem Value="3">March</asp:ListItem>
                <asp:ListItem Value="4">April</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">June</asp:ListItem>
                <asp:ListItem Value="7">July</asp:ListItem>
                <asp:ListItem Value="8">August</asp:ListItem>
                <asp:ListItem Value="9">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>
        </p>
    
    </div>
        <asp:GridView ID="gvAvailableApps" runat="server" OnRowCommand="gvAvailableApps_RowCommand" OnRowDataBound="gvAvailableApps_RowDataBound">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="APPLY" Text="Apply" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnPend" runat="server" OnClick="btnPend_Click" Text="Back to Pending" />
        <p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="lblError" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
