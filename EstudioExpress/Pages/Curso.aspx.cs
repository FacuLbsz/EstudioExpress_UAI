using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Curso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("CONSULTAR_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }

                if (((int?)Session["idCurso"] ?? 0) == 0)
                {
                    Response.Redirect("Cursos.aspx");
                }
                var curso = GestorDeCursos.ObtenerInstancia().ObtenerCurso((int)Session["idCurso"]);
                listaDeEpisodios.DataSource = curso.Episodios;
                listaDeEpisodios.DataBind();
                lblDescripcionCurso.Text = curso.descripcion;
                PrecioCursoLabel.Text = "$"+curso.precio;
                Session["IdCursoAComprar"] = curso.identificador.ToString();
                LabelIdCurso.Text = curso.identificador.ToString();
                LabelIdCurso.Visible = false;
                Session["NombreCursoAComprar"] = curso.nombre;
                var idUsuario = ((EstudioExpress.CustomIdentity)HttpContext.Current?.User?.Identity).identificador;
                var usuarioCurso = GestorDeCursos.ObtenerInstancia().EsUnCursoAsignadoAlUsuario(curso.identificador, idUsuario);

                HabilitarVideoSiEsCliente(usuarioCurso);
            }
        }

        private void HabilitarVideoSiEsCliente(bool usuarioCurso)
        {
            for (int i = 0; i < listaDeEpisodios.Items.Count(); i++)
            {
                Button btnVideoUrl = (Button)listaDeEpisodios.Items[i].FindControl("btnVerVideo");

                if (HttpContext.Current.User.Identity.Name == "Carlos.Sanchez" && usuarioCurso)
                {
                    btnVideoUrl.Enabled = true;
                    comprarPanel.Visible = false;
                }
                else
                {
                    btnVideoUrl.Enabled = false;
                    comprarPanel.Visible = true;
                }
            }
        }

        protected void ListView_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CursoVerVideo")
            {
                
                var idVideo = (e.CommandArgument.ToString());
                Session["IdCursoAVer"] = LabelIdCurso.Text;
                Session["IdEpisodioAVer"] = idVideo;
                Response.Redirect("Video.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listaDeEpisodios.Items.Count() > 0)
            {
                Response.Redirect("Pago.aspx");
            }
            else
            {
                Helpers.MessageBox.Show(this, "El curso actualmente no posee episodios. Por favor contacte al tutor.");
            }
        }
    }
}