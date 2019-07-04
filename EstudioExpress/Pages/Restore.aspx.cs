using EstudioExpress.Helpers;
using System;
using System.IO;
using System.Web;


namespace EstudioExpress.Pages
{
    public partial class Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("RESTORE"))
                {
                    Response.Redirect("Login.aspx");
                }

                lblPath.Visible = false;
            }
        }

        protected void RestoreButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fuBackUpPath.PostedFile.FileName))
            {
                MessageBox.Show(this, "Debe indicar una ruta origen válida.");
                return;
            }
 
            string ext = Path.GetExtension(fuBackUpPath.PostedFile.FileName);
            if (ext.ToLower() != ".zip")
            {
                lblPath.Text = "Desafortunadamente, el formato seleccionado no es correcto. Solo se admiten archivos .Zip.";
                lblPath.Visible = true;
                return;
            }

            lblPath.Visible = false;
            var rutaDestino = fuBackUpPath.PostedFile.FileName;

            var rutaDeArchivo = Server.MapPath("~/") + rutaDestino;
            fuBackUpPath.SaveAs(rutaDeArchivo);

            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            if (GestorSistema.ObtenerInstancia().RealizarRestore(rutaDeArchivo, userIdentity.identificador, rutaDestino) == 1)
            {

                MessageBox.Show(this, "La restauracion se realizo correctamente");
            }
            else
            {
                MessageBox.Show(this, "Hubo un error al realizar la restauracion, revise el formato de la ruta origen indicada.");
            }


        }
    }
}