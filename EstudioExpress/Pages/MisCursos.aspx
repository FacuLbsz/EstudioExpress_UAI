<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisCursos.aspx.cs" Inherits="EstudioExpress.Pages.MisCursos" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <h3>Mis Cursos</h3>
        <br />
        <br />
        <asp:ListView ID="listaDeCursos" runat="server"
            DataKeyNames="identificador"
            ItemType="CursoEntidad" OnItemCommand="ListView_ItemCommand"
            Class="table" HorizontalAlign="Center">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No hay cursos disponibles.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td />
            </EmptyItemTemplate>
            <LayoutTemplate>
                <div>
                    <table id="EmployeeTable" width="100%" class="table">
                        <tr>
                            <th>Nombre</th>
                            <th>Descripcion</th>
                            <th style="width: 260px;"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.nombre %>  
                    </td>
                    <td>
                        <%# Item.descripcion %>  
                    </td>
                    <td>
                        <asp:Button CommandName="CursoVerDetalle" CommandArgument='<%# Eval("identificador") %>' OnCommand="ListView_ItemCommand" Text="Ver Detalle" ToolTip="Detalle Del Curso" CausesValidation="false" runat="server" CssClass="btn" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
