using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class MisCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("MIS_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }
                listaDeCursos.DataSource = GestorDeCursos.ObtenerInstancia().ObtenerCursosDeUnUsuario(((EstudioExpress.CustomIdentity)HttpContext.Current?.User?.Identity).identificador);
                listaDeCursos.DataBind();
            }
        }

        protected void ListView_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CursoVerDetalle")
            {
                var curso = Int32.Parse(e.CommandArgument.ToString());
                Session["idCurso"] = curso;

                Response.Redirect("Curso.aspx");
            }
        }
    }
}