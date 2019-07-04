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

                if (Session["IdCursoAVer"] != null && Session["IdCursoAVer"].ToString() == "")
                {
                    Response.Redirect("Cursos.aspx");
                }

                if (Session["IdEpisodioAVer"] != null && Session["IdEpisodioAVer"].ToString() == "")
                {
                    Response.Redirect("Cursos.aspx");
                }
                var idUsuario = ((EstudioExpress.CustomIdentity)HttpContext.Current?.User?.Identity).identificador;
                var usuarioCurso = GestorDeCursos.ObtenerInstancia().EsUnCursoAsignadoAlUsuario(Int32.Parse(Session["IdCursoAVer"].ToString()), idUsuario);

                if (!usuarioCurso)
                {
                    Response.Redirect("Cursos.aspx");
                }
            }
        }
    }
}