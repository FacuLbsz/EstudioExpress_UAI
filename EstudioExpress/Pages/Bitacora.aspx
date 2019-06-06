<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="EstudioExpress.Pages.Bitacora" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <div>
            <div style="display: inline-block; margin-right: 20px; margin-bottom: 5px">
                <span>Fecha desde</span>
                <div style="margin-top: -10px">
                    <asp:TextBox ID="desdeTextBox" runat="server" Width="151px" Height="20px"></asp:TextBox>
                    <asp:ImageButton Style="position: relative; top: 8px" ID="desdeImageButton" runat="server" Height="28px" ImageUrl="~/static/calendar-icon.png" Width="36px" OnClick="desdeImageButton_Click" />
                </div>
            </div>
            <div style="display: inline-block; margin-right: 20px; margin-bottom: 5px">
                <span>Fecha hasta</span>
                <div style="margin-top: -10px">
                    <asp:TextBox ID="hastaTextBox" runat="server" Width="151px" Height="20px"></asp:TextBox>
                    <asp:ImageButton Style="position: relative; top: 8px" ID="hastaImageButton" runat="server" Height="28px" ImageUrl="~/static/calendar-icon.png" Width="36px" OnClick="hastaImageButton_Click" />
                </div>
            </div>
            <div style="display: inline-block; margin-right: 20px; margin-bottom: 5px">
                <span>Criticidad</span>
                <div>
                    <asp:DropDownList ID="criticidadDropDownList" runat="server" Width="173px" Height="25px">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="display: inline-block; margin-right: 20px; margin-bottom: 5px">
                <span>Usuario</span>
                <div>
                    <asp:DropDownList ID="usuarioDropDownList" runat="server" Width="172px" Height="25px">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="display: inline-block; margin-bottom: 5px">
                <asp:Button ID="buscarButton" runat="server" Text="Buscar" Style="" OnClick="buscarButton_Click" />
            </div>
        </div>
        <div>
            <div style="display: inline-block;">
                <asp:Calendar ID="desdeCalendar" runat="server" OnSelectionChanged="desdeCalendar_SelectionChanged"></asp:Calendar>
            </div>
            <div style="display: inline-block;">
                <asp:Calendar ID="hastaCalendar" runat="server" OnSelectionChanged="hastaCalendar_SelectionChanged"></asp:Calendar>
            </div>

        </div>

        <div>
            <asp:GridView ID="bitacoraGridView" runat="server" Class="table" Height="0px" Width="100%" HorizontalAlign="Center" DataMember="nombreUsuario">
                <Columns>
                    <asp:BoundField DataField="usuario.nombreUsuario" HeaderText="Usuario en sesion" ReadOnly="True" SortExpression="usuario" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" ReadOnly="True" />
                    <asp:BoundField DataField="funcionalidad" HeaderText="Funcionalidad" ReadOnly="True" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ReadOnly="True" />
                    <asp:BoundField DataField="criticidad" HeaderText="Criticidad" ReadOnly="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
