﻿using EstudioExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("MIS_CURSOS"))
                {
                    Response.Redirect("Login.aspx");
                }

                var cursoAComprar = !string.IsNullOrEmpty(Session["IdCursoAComprar"].ToString()) ? Session["IdCursoAComprar"].ToString() : string.Empty;
                Session["IdCursoAComprar"] = string.Empty;

                var nombreCursoAComprar = Session["NombreCursoAComprar"].ToString();

                if (string.IsNullOrEmpty(cursoAComprar))
                {
                    Response.Redirect("Cursos.aspx");
                }

                CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

                if (GestorDeCursos.ObtenerInstancia().EsUnCursoAsignadoAlUsuario(Int32.Parse(cursoAComprar), userIdentity.identificador))
                {
                    MessageBox.ShowAndRedirect(this, "Usted ya cuenta con el curso " + nombreCursoAComprar + ".", "MisCursos.aspx");
                    return;
                }

                TituloLabel.Text = string.Format("Ingrese los datos de su Tarjeta de Credito para comprar el curso <b>{0}</b>", nombreCursoAComprar);
                CursoIdentificador.Text = cursoAComprar;
            }
        }

        protected void PagarButton_Click(object sender, EventArgs e)
        {
            var cursoAComprar = int.Parse(CursoIdentificador.Text);
            var nombreCursoAComprar = Session["NombreCursoAComprar"].ToString();

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                MessageBox.ShowAndRedirect(this, "El usuario ha sido desconectado, vuelva a conectarse por favor.", "Login.aspx");
                return;
            }
            CustomIdentity userIdentity = (CustomIdentity)HttpContext.Current.User.Identity;

            if (GestorDeCursos.ObtenerInstancia().EsUnCursoAsignadoAlUsuario(cursoAComprar, userIdentity.identificador))
            {
                MessageBox.ShowAndRedirect(this, "Usted ya cuenta con este curso.", "MisCursos.aspx");
                return;

            }
            RealizarCompra(cursoAComprar, userIdentity.identificador);
            MessageBox.ShowAndRedirect(this, "El curso " + nombreCursoAComprar + " fue comprado exitosamente.", "MisCursos.aspx");
            return;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Session["IdCursoAComprar"] = string.Empty;
            Session["NombreCursoAComprar"] = string.Empty;
            Response.Redirect("Cursos.aspx");
        }

        private void RealizarCompra(int cursoAComprar, int idUsuario)
        {
            var curso = GestorDeCursos.ObtenerInstancia().ObtenerCurso(cursoAComprar);

            var usuario = new Usuario() { identificador = idUsuario };

            var detalleFactura = new DetalleFactura() { descripcion = curso.nombre, monto = curso.precio };
            List<DetalleFactura> detalle = new List<DetalleFactura>() { detalleFactura };

            GestorDeFacturacion.ObtenerInstancia().CrearFactura(new Factura() { DetalleFactura = detalle ,usuario = usuario, fecha = new DateTime()});

            GestorDeCursos.ObtenerInstancia().AsignarCursoAUsuario(curso, usuario);

        }
    }
}