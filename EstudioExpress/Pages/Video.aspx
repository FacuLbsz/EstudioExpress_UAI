<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="EstudioExpress.Pages.Video" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <iframe width="560" height="315" src='<%= GetVideoLink() %>' frameborder="0" allowfullscreen></iframe>
        <%--<video width="100%" height="100%" controls>
            <source type="video/mp4" src='<%= GetVideoLink() %>' />
            Your browser does not support the video tag.
        </video>--%>
    </div>
</asp:Content>
