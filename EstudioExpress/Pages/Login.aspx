<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EstudioExpress.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <br />
            <br />
            <br />
            <br />
            <%--<div style="display: inline-grid; margin-bottom: 5px" class="form-group">
            <h2>Usuario</h2>
            <asp:TextBox ID="UsuarioTextBox" CssClass="form-control" runat="server" Style="align-content: center" Width="222px" Height="33px"></asp:TextBox>
        </div>
        <br />
        <div style="display: inline-grid; margin-bottom: 5px" class="form-group">
            <h2>Contraseña</h2>
            <asp:TextBox ID="ContraseñaTextBox" CssClass="form-control" TextMode="Password" runat="server" Style="margin-left: 0px" Width="216px" Height="45px"></asp:TextBox>
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Style="margin-left: 0px" Text="Ingresar" OnClick="Button1_Click" Width="180px" />
        <br />--%>
            <div class="col-md-4">
            </div>
            <div class="col-md-4 login-form-2">
                <h2>Login</h2>
                <div class="form-group">
                    <asp:TextBox ID="UsuarioTextBox"  style="left: 41px;position: relative;" class="form-control" placeholder="Usuario *" runat="server"></asp:TextBox>                   
                </div>
                <div class="form-group">
                    <asp:TextBox ID="ContraseñaTextBox" style="left: 41px; position: relative;" class="form-control" TextMode="Password" runat="server" placeholder="Contraseña *"></asp:TextBox>                   
                </div>
                <div class="form-group">        
                    <asp:Button ID="Button1" class="myButton" Text="Login" runat="server" OnClick="Button1_Click"/>
                </div>               
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</asp:Content>
