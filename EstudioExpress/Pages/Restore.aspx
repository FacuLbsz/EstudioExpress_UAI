<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="EstudioExpress.Pages.Restore" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <div class="credit-card-div">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row ">
                        <div class="col-md-12 pad-adjust">
                            <span class="help-block text-muted ">Ruta donde se obtendra el backup</span>
                            <asp:TextBox ID="RutaOrigenTextBox" runat="server" class="form-control" placeholder="Ruta origen"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row ">                        
                        <div class="col-md-12 col-sm-12 col-xs-12 pad-adjust">
                            <asp:Button ID="RestoreButton" class="btnSubmit btn btn-block btn-success" Text="Realizar restauracion" runat="server" OnClick="RestoreButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
