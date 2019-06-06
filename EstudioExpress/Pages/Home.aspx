<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EstudioExpress.Home" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            var availableTags = [
                "ActionScript",
                "AppleScript",
                "Asp",
                "BASIC",
                "C",
                "C++",
                "Clojure",
                "COBOL",
                "ColdFusion",
                "Erlang",
                "Fortran",
                "Groovy",
                "Haskell",
                "Java",
                "JavaScript",
                "Lisp",
                "Perl",
                "PHP",
                "Python",
                "Ruby",
                "Scala",
                "Scheme"
            ];
            $("#tags").autocomplete({
                source: availableTags
            });
        });
    </script>  
    <section>
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                    <h2>Que deseas aprender hoy?: </h2>
                    <input id="tags" placeholder="Selecciona un curso...">
                </div>
                <div class="col-md-5"></div>
                <div class="col-md-2">
                    <asp:Image ID="Image1" runat="server" EnableViewState="False" Height="378px" ImageAlign="Right" ImageUrl="~/Images/homePage.jpg" Width="578px" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
