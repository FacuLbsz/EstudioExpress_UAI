<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="AdministracionDeEpisodios.aspx.cs" Inherits="EstudioExpress.Pages.AdministracionDeEpisodios" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container" style="text-align: left !important;">
        <asp:Label ID="TituloLabel" CssClass="h1" runat="server" Text=""></asp:Label>
        <div>
            <h3>Agregar nuevo Episodio:</h3>
            <asp:Label ID="CursoIdentificador" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="CursoNombre" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="form-group">

                <span class="help-block text-muted small-font">Nombre:</span>
                <asp:TextBox ID="AgregarNombre" class="form-control" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* nombre requerido." ControlToValidate="AgregarNombre" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">

                <span class="help-block text-muted small-font">Descripcion:</span>
                <asp:TextBox ID="AgregarDescripcion" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="* descripcion requerida." ControlToValidate="AgregarDescripcion" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>


            </div>
            <div class="form-group">

                <span class="help-block text-muted small-font">Direccion de video:</span>
                <asp:TextBox ID="AgregarVideo" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* nombre video requerido." ControlToValidate="AgregarVideo" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>

            <div class="form-group">

                <span class="help-block text-muted small-font">Numero de episodio:</span>
                <asp:TextBox ID="AgregarNumeroEpisodio" class="form-control" runat="server" MaxLength="3" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* numero de episodio requerido." ControlToValidate="AgregarNumeroEpisodio" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>

            <asp:Button ID="AgregarEpisodioButton" runat="server" Text="Guardar" CausesValidation="true" CssClass="btn btn-default" OnClick="AgregarEpisodioButton_Click" />
        </div>
        <br />
        <br />
        <asp:Label ID="LabelStatus" BackColor="Blue" Width="540px" Height="5px" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <h3>Todos los episodios:</h3>
        <div>
            <asp:ListView ID="EpisodioList" ItemType="Episodio" DataKeyNames="identificador" runat="server" Class="table" HorizontalAlign="Center">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No se han encontrado episodios, intenta nuevamente!</td>
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
                                <th>Video</th>
                                <th>Numero Ep</th>
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
                            <%# Item.direccionVideo %>  
                        </td>
                        <td>
                            <%# Item.numeroEpisodio %>  
                        </td>
                        <td>                            
                            <asp:Button CommandName="EpisodioEliminar" CommandArgument='<%# Eval("identificador") %>' OnCommand="ListView_ItemCommand" ToolTip="Eliminar un episodio" CausesValidation="false" OnClientClick="javascript:return confirm('Esta seguro que desea eliminar?')" Text="Eliminar" runat="server" CssClass="btn" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
