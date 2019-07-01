using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class RecuperarIntegridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("BITACORA"))
                {
                    Response.Redirect("Login.aspx");
                }

                GestorSistema.ObtenerInstancia().RecalcularDigitosVerificadores();
                MessageBox.ShowAndRedirect(this, "La base de datos ha vuelto a la normalidad. Por favor verifique la bitacora.", "Home.aspx");

            }
        }
    }
}