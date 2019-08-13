using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("CONSULTAR_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }

                // Create cookie object 
                HttpCookie cookieVideo = new HttpCookie("HttpBrowserCookieCheck");
                // Set the cookies value 
                cookieVideo.Value = Session["IdEpisodioAVer"].ToString();
                //Set the cookie to expire in 20 minute
                DateTime dtNow = DateTime.Now;
                TimeSpan tsMinute = new TimeSpan(30, 0, 20, 0);
                cookieVideo.Expires = DateTime.Now.AddDays(1);
                // Add the cookie 
                Response.Cookies.Add(cookieVideo);
                

                //if (Session["IdCursoAVer"] != null && Session["IdCursoAVer"].ToString() == "")
                //{
                //    Response.Redirect("Cursos.aspx");
                //}

                //if (Session["IdEpisodioAVer"] != null && Session["IdEpisodioAVer"].ToString() == "")
                //{
                //    Response.Redirect("Cursos.aspx");
                //}
                //var idUsuario = ((EstudioExpress.CustomIdentity)HttpContext.Current?.User?.Identity).identificador;
                //var usuarioCurso = GestorDeCursos.ObtenerInstancia().EsUnCursoAsignadoAlUsuario(Int32.Parse(Session["IdCursoAVer"].ToString()), idUsuario);

                //if (!usuarioCurso)
                //{
                //    Response.Redirect("Cursos.aspx");
                //}
            }
        }

        protected string GetVideoLink()
        {
            return Session["IdEpisodioAVer"].ToString();
        }
    }
}