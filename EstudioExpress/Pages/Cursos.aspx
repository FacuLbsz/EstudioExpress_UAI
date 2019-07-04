<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="EstudioExpress.Pages.Cursos" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <asp:ScriptManager ID="ScriptManager1"
            runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1"
            runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row">
                    <asp:TextBox ID="txtCurso" runat="server" Height="37px" Width="195px"></asp:TextBox>
                    &nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnBuscarCurso" class="myButton" runat="server" Text="Buscar Curso" Height="47px" Width="208px" OnClick="Button1_Click" />
                </div>
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
                                    <th>Precio</th>
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
                                <%# Item.precio %>  
                            </td>
                            <td>
                                <asp:Button CommandName="CursoVerDetalle" CommandArgument='<%# Eval("identificador") %>' OnCommand="ListView_ItemCommand" Text="Ver Detalle" ToolTip="Detalle Del Curso" CausesValidation="false" runat="server" CssClass="btn" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
