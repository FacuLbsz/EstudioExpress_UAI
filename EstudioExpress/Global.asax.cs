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
                
                String[] usuarioYRoles = GestorDeEncriptacion.DesencriptarAes(Request.Cookies["EstudioExpress_Usuario"].Value).Split('|');

                var identificador = usuarioYRoles[0];
                var nombreUsuario = usuarioYRoles[1];
                String[] roles = usuarioYRoles[2].Split(',');

                CustomIdentity myIdentity = new CustomIdentity(nombreUsuario, Int32.Parse(identificador));
                GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, roles);

                HttpContext.Current.User = myPrincipal;
            }

        }
    }
}