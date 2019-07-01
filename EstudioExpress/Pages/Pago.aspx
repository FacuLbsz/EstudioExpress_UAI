<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="EstudioExpress.Pages.Pago" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <div class="credit-card-div">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row ">
                        <div class="col-md-12">                     
                            <span class="help-block text-muted small-font">
                            <asp:Label ID="TituloLabel" runat="server" Text="Label"></asp:Label>
                                </span>
                            <asp:TextBox ID="TextBox1" runat="server"  class="form-control" placeholder="Ingrese el número de la Tarjeta"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-3 col-xs-3">
                            <span class="help-block text-muted small-font">Mes de expiración</span>
                            <asp:TextBox ID="MMTextBox" runat="server"  class="form-control" placeholder="MM"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-3">
                            <span class="help-block text-muted small-font">Año de expiración</span>
                            <asp:TextBox ID="YYTextBox" runat="server" class="form-control" placeholder="YY"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-3">
                            <span class="help-block text-muted small-font">Código de seguridad</span>
                            <asp:TextBox ID="CCVTextBox" runat="server" class="form-control" placeholder="CCV"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-3">
                            <img src="/Images/cc.png" class="img-rounded" />
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-md-12 pad-adjust">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Nombre en la Tarjeta"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row ">
                        <div class="col-md-6 col-sm-6 col-xs-6 pad-adjust">
                            <asp:Button ID="CancelarButton" class="btnSubmit btn btn-danger btn-block" Text="CANCELAR" runat="server" OnClick="CancelarButton_Click" />
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-6 pad-adjust">
                            <asp:Button ID="PagarButton" class="btnSubmit btn btn-warning btn-block" Text="PAGAR" runat="server" OnClick="PagarButton_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="CursoIdentificador" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>

