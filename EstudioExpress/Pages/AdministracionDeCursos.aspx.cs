using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class AdministracionDeCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("ADMINISRAR_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }

                CursoList.DataSource = GestorDeCursos.ObtenerInstancia().ObtenerCursos();
                CursoList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Write("<script>Window.location.reload()</script>");

        }

        public IQueryable<CursoEntidad> GetSearchedItems()
        {
            return null;
        }


        public void DeleteEmployee(int id)
        {



        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            CursoList.DataBind();
            Response.Write("<script>Window.location.reload()</script>");

        }

        protected void EliminarCurso(object sender, ListViewDeleteEventArgs e)
        {
            Response.Write("<script>javascript:alert('Curso eliminado satisfactoriamente.');</script>");
        }

        protected void EditarCurso(object sender, ListViewEditEventArgs e)
        {
            Response.Write("<script>javascript:alert('Curso editado satisfactoriamente.');</script>");
        }

        protected void ItemCancelling(object sender, ListViewCancelEventArgs e)
        {
            Response.Write("<script>javascript:alert('Curso cancelado satisfactoriamente.');</script>");
        }

        protected void AddEmployeeButton_Click(object sender, EventArgs e)
        {
           
            Response.Write("<script>javascript:alert('Employee Information Added  successfully');</script>");


        }

        public void ActualizarCurso(CursoEntidad modifiedEmployee)
        {
            Response.Write("<script>javascript:alert('Employee Information Updated successfully');</script>");


        }

        protected void ListView_ItemCommand(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "CursoEditarEpisodios":
                    var curso = Int32.Parse(e.CommandArgument.ToString());
                    Session["idCurso"] = curso;

                    Response.Redirect("AdministracionDeEpisodios.aspx");
                    break;

            }

        }

        protected void AgregarCursoButton_Click(object sender, EventArgs e)
        {
            var nombre = AgregarNombre.Text;
            var descripcion = AgregarDescripcion.Text;
            var precio = AgregarPrecio.Text;

            CursoEntidad curso = new CursoEntidad() { nombre = nombre, descripcion = descripcion, precio = Decimal.Parse(precio) };

            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            GestorDeCursos.ObtenerInstancia().CrearCurso(curso, userIdentity.identificador);
            MessageBox.ShowAndRedirect(this, "Curso creado satisfactoriamente", "AdministracionDeCursos.aspx");

        }
    }
}