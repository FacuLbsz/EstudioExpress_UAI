<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="EstudioExpress.Pages.Bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="display: inline-block; margin-right: 20px">
                <span>Fecha desde</span>
                <div style="margin-top: -10px">
                    <asp:TextBox ID="desdeTextBox" runat="server" Width="151px" Height="20px"></asp:TextBox>
                    <asp:ImageButton style="position: relative; top:8px" ID="desdeImageButton" runat="server" Height="28px" ImageUrl="~/static/calendar-icon.png" Width="36px" OnClick="desdeImageButton_Click" />
                </div>
            </div>
            <div style="display: inline-block; margin-right: 20px">
                <span>Fecha hasta</span>
                <div style="margin-top: -10px">
                    <asp:TextBox ID="hastaTextBox" runat="server" Width="151px" Height="20px"></asp:TextBox>
                    <asp:ImageButton style="position: relative; top:8px" ID="hastaImageButton" runat="server" Height="28px" ImageUrl="~/static/calendar-icon.png" Width="36px" OnClick="hastaImageButton_Click" />
                </div>
        </div>
        <div style="display: inline-block; margin-right: 20px">
            <span>Criticidad</span>
            <div>
                <asp:DropDownList ID="criticidadDropDownList" runat="server" Width="173px" Height="25px">
                </asp:DropDownList>
            </div>
        </div>
            <div style="display: inline-block; margin-right: 20px">
                <span>Usuario</span>
                <div>
                    <asp:DropDownList ID="usuarioDropDownList" runat="server" Width="172px" Height="25px">
                    </asp:DropDownList>
                </div>
        </div>
            <div style="display: inline-block;  ">
                <asp:Button ID="buscarButton" runat="server" Text="Buscar" Width="100px" Height="30px" Style="" OnClick="buscarButton_Click" />
            </div>        
        </div>
        <div>
            <div style="display: inline-block;  ">
                <asp:Calendar ID="desdeCalendar" runat="server" OnSelectionChanged="desdeCalendar_SelectionChanged"></asp:Calendar>
            </div>
            <div style="display: inline-block;  ">
                <asp:Calendar ID="hastaCalendar" runat="server" OnSelectionChanged="hastaCalendar_SelectionChanged"></asp:Calendar>
            </div>
            
        </div>
        
        <div>
            <asp:GridView ID="bitacoraGridView" runat="server" Height="0px" Width="100%" HorizontalAlign="Center" DataMember="nombreUsuario">
                <Columns>
                    <asp:BoundField DataField="usuario.nombreUsuario" HeaderText="Usuario en sesion" ReadOnly="True" SortExpression="usuario" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" ReadOnly="True" />
                    <asp:BoundField DataField="funcionalidad" HeaderText="Funcionalidad" ReadOnly="True" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ReadOnly="True" />
                    <asp:BoundField DataField="criticidad" HeaderText="Criticidad" ReadOnly="True" />
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
