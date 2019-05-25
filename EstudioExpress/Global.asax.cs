using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace EstudioExpress
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GestorSistema.ObtenerInstancia();

        }

        void Application_PostAuthenticateRequest(object sender, EventArgs e)

        {

            if (Request.Cookies["EstudioExpress_Usuario"] != null)
            {
                GenericIdentity myIdentity = new GenericIdentity("usuario");
                
                String[] roles = GestorDeEncriptacion.DesencriptarAes(Request.Cookies["EstudioExpress_Usuario"].Value).Split(',');
                GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, roles);

                HttpContext.Current.User = myPrincipal;
            }

        }
    }
}