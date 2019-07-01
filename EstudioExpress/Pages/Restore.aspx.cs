using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            }
        }

        protected void RestoreButton_Click(object sender, EventArgs e)
        {
            var rutaDestino = RutaOrigenTextBox.Text;
            if (rutaDestino == "")
            {
                MessageBox.Show(this, "Debe indicar una ruta origen");
                return;
            }

            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            if (GestorSistema.ObtenerInstancia().RealizarRestore(rutaDestino, userIdentity.identificador) == 1)
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