using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("BACKUP"))
                {
                    Response.Redirect("Login.aspx");
                }               

            }
        }

        protected void BackupButton_Click(object sender, EventArgs e)
        {
            var rutaDestino = RutaDestinoTextBox.Text;
            if (rutaDestino == "")
            {
                MessageBox.Show(this, "Debe indicar una ruta destino");
                return;
            }

            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            if(GestorSistema.ObtenerInstancia().RealizarBackup(rutaDestino, 1, userIdentity.identificador) == 1)
            {

                MessageBox.Show(this, "El backup se realizo correctamente");

            }
            else
            {
                MessageBox.Show(this, "Hubo un error al realizar el backup, revise el formato de la ruta destino indicada.");
            }


        }
    }
}