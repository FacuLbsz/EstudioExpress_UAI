using EstudioExpress.Helpers;
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
            if (IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    Response.Redirect("Home.aspx");

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UsuarioTextBox.Text) && !String.IsNullOrEmpty(ContraseñaTextBox.Text))
            {

                var usuario = new Usuario() { nombreUsuario = UsuarioTextBox.Text, contrasena = ContraseñaTextBox.Text };
                var result = GestorSistema.ObtenerInstancia().RealizarLogIn(usuario);

                switch (result)
                {

                    case 1:

                        List<PatenteUsuario> patentesPorFamilia = GestorDePatentes.ObtenerInstancia().ObtenerPatentesParaUnUsuarioPorFamilia(usuario);

                        String patentes = "";
                        patentesPorFamilia.ForEach(p =>
                        {

                            if (patentes == "")
                            {
                                patentes = p.patente.nombre;
                            }
                            else
                            {
                                patentes = patentes + "," + p.patente.nombre;
                            }
                        });

                        var cookie = new HttpCookie("EstudioExpress_Usuario", GestorDeEncriptacion.EncriptarAes(usuario.identificador + "|" + UsuarioTextBox.Text + "|" + patentes));

                        

                        if (GestorSistema.ObtenerInstancia().ConsultarIntegridadDeBaseDeDatos() == 0)
                        {
                            if (patentesPorFamilia.Exists(x => x.patente.nombre == "BITACORA"))
                            {

                                Response.Cookies.Add(cookie);
                                MessageBox.ShowAndRedirect(this, "Se ha vulnerado la integridad de la base de datos, desea recuperarla?", "RecuperarIntegridad.aspx");
                                return;
                            }
                            else
                            {
                                MessageBox.ShowAndRedirect(this, "Se ha vulnerado la integridad de la base de datos por favor comuniquese con el administrador de sistema.", "Login.aspx");
                                return;
                            }
                        }

                        Response.Cookies.Add(cookie);
                        Response.Redirect("Home.aspx");
                        break;

                    case 0:
                        MessageBox.Show(this, "Los datos ingresados son incorrectos.");
                        break;
                    case 2:
                        //SE BLOQUEO EL USUARIO
                        MessageBox.Show(this, "Se ha bloqueado el usuario.");
                        break;
                }



            }



        }
    }
}