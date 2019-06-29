using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress.Pages
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated && !HttpContext.Current.User.IsInRole("BITACORA"))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {



                //Se cargan los controles
                if (!IsPostBack)
                {
                    desdeCalendar.Visible = false;
                    hastaCalendar.Visible = false;
                    
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios.Add(new Usuario { nombreUsuario = "TODOS", identificador = 0 });
                    usuarios.AddRange(obtenerUsuarios());

                    usuarioDropDownList.DataSource = usuarios;
                    usuarioDropDownList.DataValueField = "identificador";
                    usuarioDropDownList.DataTextField = "nombreUsuario";
                    usuarioDropDownList.DataBind();

                    criticidadDropDownList.DataSource = new List<String> { "TODOS", "Alta", "Media", "Baja" };
                    criticidadDropDownList.DataBind();
                }



            }

        }

        private List<Usuario> obtenerUsuarios()
        {
            return GestorDeUsuarios.ObtenerInstancia().ConsultarUsuariosTodos();
        }

        protected void desdeImageButton_Click(object sender, ImageClickEventArgs e)
        {
            desdeCalendar.Visible = !desdeCalendar.Visible;
        }

        protected void hastaImageButton_Click(object sender, ImageClickEventArgs e)
        {
            hastaCalendar.Visible = !hastaCalendar.Visible;
        }

        protected void desdeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            desdeTextBox.Text = desdeCalendar.SelectedDate.ToShortDateString();
            desdeCalendar.Visible = false;
        }

        protected void hastaCalendar_SelectionChanged(object sender, EventArgs e)
        {
            hastaTextBox.Text = hastaCalendar.SelectedDate.ToShortDateString();
            hastaCalendar.Visible = false;
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;

            if (desdeTextBox.Text != "" && hastaTextBox.Text != "")
            {
                Console.WriteLine("COMPARE TO: " + desdeCalendar.SelectedDate.CompareTo(hastaCalendar.SelectedDate));
                if (desdeCalendar.SelectedDate.CompareTo(hastaCalendar.SelectedDate) > 0)
                {
                    Response.Write("<script>alert('La fecha desde no puede ser superior a la fecha hasta');</script>");
                    return;
                }

                //DateTime dt = DateTime.ParseExact(yourObject.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                fechaDesde = desdeCalendar.SelectedDate;
                fechaHasta = hastaCalendar.SelectedDate;
            }



            String criticidad = criticidadDropDownList.SelectedItem.ToString();
            int? criticidadInt = null;
            switch (criticidad)
            {
                case "Alta":
                    criticidadInt = 1;
                    break;
                case "Media":
                    criticidadInt = 2;
                    break;
                case "Baja":
                    criticidadInt = 3;
                    break;
            }

            Usuario usuario = new Usuario() { identificador = int.Parse(usuarioDropDownList.SelectedItem.Value) };
            int? idUsuario = null;
            if (usuario.identificador > 0)
            {
                idUsuario = usuario.identificador;
            }

            cargarEventosBitacora(GestorDeBitacora.ObtenerInstancia().ConsultarEventos(criticidadInt, idUsuario, fechaDesde, fechaHasta));
        }

        private void cargarEventosBitacora(List<EventoBitacora> eventos)
        {
            bitacoraGridView.AutoGenerateColumns = false;

            bitacoraGridView.DataSource = eventos;
            bitacoraGridView.DataBind();
        }
    }
}