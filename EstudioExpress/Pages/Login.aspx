<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EstudioExpress.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="display: inline-grid; margin-bottom: 5px">
            <span>Usuario</span>
            <asp:TextBox ID="TextBox1" runat="server" Style="align-content: center" Width="151px" Height="20px"></asp:TextBox>
        </div>
        <br />
        <div style="display: inline-grid; margin-bottom: 5px">
            <span>Contraseña</span>
            <asp:TextBox ID="TextBox2" runat="server" Style="margin-left: 0px" Width="151px" Height="20px"></asp:TextBox>
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Style="margin-left: 0px" Text="Ingresar" OnClick="Button1_Click" Width="180px" />
        <br />
    </div>
</asp:Content>
