<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="EstudioExpress.Pages.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MEJORAR LA VIDA A TRAVÉS DEL APRENDIZAJE</h2>
    <br />
    <br />
    <h4 style="text-align: center; color: white;">El mercado global líder para el aprendizaje y la instrucción</h4>
    <br />
    <br />
    <div class="container">
        <h1 class="display-4" style="color: white;">Nuestros docentes son profesionales que trabajan día a día en la materia que imparten</h1>
        <br />
        <br />
        <div class="row">
            <div class="col-md-5">
                <h5 class="display-3">¿Porque Estudio Express es tu mejor opción?</h5>
                <ul class="list-group">
                    <li class="list-group-item" style="font-weight: bold;">Exclusividad IT</li>
                    <li class="list-group-item" style="font-weight: bold;">100% Español</li>
                    <li class="list-group-item" style="font-weight: bold;">Expertos</li>
                    <li class="list-group-item" style="font-weight: bold;">Tutorías</li>
                    <li class="list-group-item" style="font-weight: bold;">Calidad</li>
                </ul>
            </div>
            <div class="col-md-5"></div>
            <div class="col-md-2">
                <asp:Image ID="Image1" runat="server" EnableViewState="False" Height="378px" ImageAlign="Right" ImageUrl="~/Images/About2.jpg" Width="578px" />
            </div>
        </div>
    </div>



</asp:Content>
