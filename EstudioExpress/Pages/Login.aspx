<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EstudioExpress.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 575px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <br />
            <br />
            <br />
            <br />
            <br />
            Usuario<br />
            <asp:TextBox ID="TextBox1" runat="server" style="align-content: center"></asp:TextBox>
            <br />
            Contraseña<br />            
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" style="margin-left: 0px" Text="Ingresar" OnClick="Button1_Click" Width="180px" />
            <br />
        </div>
    </form>
</body>
</html>
