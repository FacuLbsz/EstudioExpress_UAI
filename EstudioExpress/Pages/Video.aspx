<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="EstudioExpress.Pages.Video" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container custom-container">
        <video width="100%" height="100%" controls>
            <source src="../static/videos/video.mp4" type="video/mp4">
            Your browser does not support the video tag.
        </video>
    </div>
</asp:Content>
