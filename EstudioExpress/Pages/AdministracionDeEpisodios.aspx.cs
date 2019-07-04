using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class AdministracionDeEpisodios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("ADMINISRAR_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }
                
                string cursoAComprar = Session["idCurso"] != null ? Session["idCurso"].ToString() : string.Empty;
                Session["idCurso"] = string.Empty;

                if (string.IsNullOrEmpty(cursoAComprar))
                {
                    Response.Redirect("AdministracionDeCursos.aspx");
                }

                CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

                var curso = GestorDeCursos.ObtenerInstancia().ObtenerCurso(int.Parse(cursoAComprar));
                var nombreCurso = curso.nombre;


                EpisodioList.DataSource = curso.Episodios;
                EpisodioList.DataBind();

                TituloLabel.Text = string.Format("Adminsitrar episodios del curso <b>{0}</b>", nombreCurso);
                CursoIdentificador.Text = cursoAComprar;
                CursoNombre.Text = nombreCurso;
            }

        }

        protected void ListView_ItemCommand(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                
                case "EpisodioEliminar":
                    var episodio = Int32.Parse(e.CommandArgument.ToString());

                    CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

                    GestorDeCursos.ObtenerInstancia().QuitarEpisodioACurso(new Episodio() {identificador= episodio }, new CursoEntidad()
                    {
                        identificador = Int32.Parse(CursoIdentificador.Text)
                    }, userIdentity.identificador);

                    Session["idCurso"] = CursoIdentificador.Text;

                    MessageBox.ShowAndRedirect(this, "Episodio eliminado satisfactoriamente", "AdministracionDeEpisodios.aspx");
                    break;

            }

        }

        protected void AgregarEpisodioButton_Click(object sender, EventArgs e)
        {
            var nombre = AgregarNombre.Text;
            var descripcion = AgregarDescripcion.Text;
            var video = AgregarVideo.Text;
            var numeroEpisodio = AgregarNumeroEpisodio.Text;

            Episodio episodio = new Episodio() { nombre = nombre, descripcion = descripcion, direccionVideo = video,numeroEpisodio = Int32.Parse(numeroEpisodio) };

            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            GestorDeCursos.ObtenerInstancia().AgregarEpisodioACurso(episodio, new CursoEntidad() {identificador = Int32.Parse(CursoIdentificador.Text) }, userIdentity.identificador);

            Session["idCurso"] = CursoIdentificador.Text;

            MessageBox.ShowAndRedirect(this, "Episodio creado satisfactoriamente", "AdministracionDeEpisodios.aspx");

        }
    }
}