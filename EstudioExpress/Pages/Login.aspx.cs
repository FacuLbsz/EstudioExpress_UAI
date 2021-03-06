﻿using System;
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
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                Response.Redirect("Home.aspx");

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

                        var patentesPorFamilia = GestorDePatentes.ObtenerInstancia().ObtenerPatentesParaUnUsuarioPorFamilia(usuario);

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

                        var cookie = new HttpCookie("EstudioExpress_Usuario", GestorDeEncriptacion.EncriptarAes(UsuarioTextBox.Text + "|" + patentes));

                        Response.Cookies.Add(cookie);
                        Response.Redirect("Home.aspx");
                        break;

                    case 0:
                        //NO SE ENCUENTRA
                        break;
                    case 2:
                        //SE BLOQUEO EL USUARIO
                        break;
                }



            }



        }
    }
}