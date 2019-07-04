<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="EstudioExpress.Pages.Curso" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <h1>Detalle Del Curso</h1>
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <h3>Descripcion:</h3>
                            <asp:Label runat="server" ID="lblDescripcionCurso"></asp:Label>
                        </div>
                        <div class="panel-footer">Información del curso</div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <asp:Panel ID="comprarPanel" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h3>Comprar Curso</h3>
                                <br />
                                <br />
                                <asp:Button class="myButton" Text="Comprar" runat="server" ID="btnComprarCurso" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="panel-footer">Compras</div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <br />
        <h3>Contenido Del Curso</h3>
        <br />
        <asp:ListView ID="listaDeEpisodios" runat="server"
            DataKeyNames="identificador"
            ItemType="Episodio" OnItemCommand="ListView_ItemCommand"
            Class="table" HorizontalAlign="Center">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No hay episodios disponibles.</td>
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
                            <th>Numero de Episodio</th>
                            <th>Nombre</th>
                            <th style="width: 260px;"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.numeroEpisodio %>  
                    </td>
                    <td>
                        <%# Item.nombre %>  
                    </td>
                    <td>
                        <asp:Button ID="btnVerVideo" CommandName="CursoVerVideo" CommandArgument='<%# Eval("direccionVideo") %>' OnCommand="ListView_ItemCommand" Text="Ver Video" ToolTip="Ver Video Online" CausesValidation="false" runat="server" CssClass="btn" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
