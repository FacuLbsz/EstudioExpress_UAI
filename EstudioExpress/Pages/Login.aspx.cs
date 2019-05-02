using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var cookie = new HttpCookie("EstudioExpress_Usuario", GestorDeEncriptacion.EncriptarAes("WEBMASTER,TUTOR"));
            
            Response.Cookies.Add(cookie);
            Response.Redirect("Home.aspx");
        }
    }
}