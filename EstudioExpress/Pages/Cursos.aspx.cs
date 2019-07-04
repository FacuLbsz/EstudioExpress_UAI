using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("ADMINISRAR_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }
                listaDeCursos.DataSource = GestorDeCursos.ObtenerInstancia().ObtenerCursos();
                listaDeCursos.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cursoABuscar = txtCurso.Text.Trim();

            var cursosEncontrados = GestorDeCursos.ObtenerInstancia().ObtenerCursos()
                .Where(x => x.nombre.ToLower().Contains(cursoABuscar.ToLower()) || x.descripcion.ToLower().Contains(cursoABuscar.ToLower())).ToList();
            if (cursosEncontrados != null)
            {
                listaDeCursos.DataSource = cursosEncontrados;
                listaDeCursos.DataBind();
                UpdatePanel1.Update();
            }
            else
            {
                Helpers.MessageBox.Show(this, "No se encontraron cursos con ese nombre. Cargando todos los cursos...");
                listaDeCursos.DataSource = GestorDeCursos.ObtenerInstancia().ObtenerCursos();
                listaDeCursos.DataBind();
                UpdatePanel1.Update();
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