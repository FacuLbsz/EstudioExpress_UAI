<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="AdministracionDeCursos.aspx.cs" Inherits="EstudioExpress.Pages.AdministracionDeCursos" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container" style="text-align: left !important;">
        <h1>Administracion de cursos</h1>
        <div>
            <h3>Crear nuevo Curso:</h3>
            <div class="form-group">

                <span class="help-block text-muted small-font">Nombre:</span>
                <asp:TextBox ID="AgregarNombre" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* nombre requerido." ControlToValidate="AgregarNombre" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">

                <span class="help-block text-muted small-font">Descripcion:</span>
                <asp:TextBox ID="AgregarDescripcion" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="* descripcion requerida." ControlToValidate="AgregarDescripcion" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>


            </div>
            <div class="form-group">

                <span class="help-block text-muted small-font">Precio:</span>
                <asp:TextBox ID="AgregarPrecio" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* precio requerido." ControlToValidate="AgregarPrecio" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>

            <asp:Button ID="AgregarCursoButton" runat="server" Text="Guardar" CausesValidation="true" CssClass="btn btn-default" OnClick="AgregarCursoButton_Click" />
        </div>
        <br />
        <br />
        <asp:Label ID="LabelStatus" BackColor="Blue" Width="540px" Height="5px" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <h3>Todos los cursos:</h3>
        <div>
            <asp:ListView ID="CursoList" ItemType="CursoEntidad" DataKeyNames="identificador" runat="server" Class="table" HorizontalAlign="Center">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No se han encontrado cursos, intenta nuevamente!</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <LayoutTemplate>
                    <div>
                        <table id="EmployeeTable" width="100%" Class="table">
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
                            <asp:Button CommandName="CursoEditarEpisodios" CommandArgument='<%# Eval("identificador") %>' OnCommand="ListView_ItemCommand" Text="Episodios" ToolTip="Editar episodios" CausesValidation="false" runat="server" CssClass="btn" />
                            <asp:Button CommandName="CursoEliminar" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ListView_ItemCommand" ToolTip="Eliminar un curso" CausesValidation="false" OnClientClick="javascript:return confirm('Esta seguro que desea eliminar?')" Text="Eliminar" runat="server" CssClass="btn" />
                        </td>
                    </tr>
                </ItemTemplate>                
            </asp:ListView>
        </div>        
    </div>
</asp:Content>
