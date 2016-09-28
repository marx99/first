<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<%--        <asp:Timer ID="timer1" runat="server" Interval="50000"></asp:Timer>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <asp:TextBox ID="TextBox1" runat="server" MaxLength="6" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br>
        <asp:Label ID="lblmatch" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </div>
        <asp:HiddenField ID="hidcode" runat="server" />
    </form>
</body>
</html>
