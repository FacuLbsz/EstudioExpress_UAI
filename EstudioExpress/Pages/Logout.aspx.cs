using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpCookie cookie = Response.Cookies.Get("EstudioExpress_Usuario");
                cookie.Expires = DateTime.Now.AddHours(-12);
                Response.Cookies.Add(cookie);
            }
                Response.Redirect("Home.aspx");
        }
    }
}