using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstudioExpress
{
    public partial class SiteMaster : MasterPage
    {
        private static List<MenuItem> menuItems = new List<MenuItem>();

        static SiteMaster()
        {
            menuItems.Add(newMenuItem("TODOS-HOME", "~/Pages/Home.aspx", "Página principal"));
            menuItems.Add(newMenuItem("WEBMASTER-BITACORA", "~/Pages/Bitacora.aspx", "Bitacora"));
            menuItems.Add(newMenuItem("TUTOR-ADMINISRAR_CURSOS", "~/Pages/Home.aspx", "Administrar Cursos"));
            menuItems.Add(newMenuItem("CLIENTE-CONSULTAR_CURSOS", "~/Pages/Home.aspx", "Consultar Cursos"));
            menuItems.Add(newMenuItem("CLIENTE-MIS_CURSOS", "~/Pages/Home.aspx", "Mis Cursos"));
            menuItems.Add(newMenuItem("TODOS-NOSOTROS", "~/Pages/Nosotros.aspx", "Nosotros"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                PanelLogin.Visible = false;
                PanelLogout.Visible = true;
                LabelBienvenido.Text = "Bienvenido " + HttpContext.Current.User.Identity.Name;
                loadMenuItemsIfLogged(true);

            }
            else
            {
                loadMenuItemsIfLogged(false);
                PanelLogin.Visible = true;
                PanelLogout.Visible = false;
            }
        }

        private static MenuItem newMenuItem(String value,String navigateUrl,String text)
        {
            return new MenuItem() { Value=value,NavigateUrl=navigateUrl,Text=text};
        }

        private void loadMenuItemsIfLogged(bool isLogged)
        {
            NavigationMenu.Items.Clear();

            foreach (MenuItem item in menuItems)
            {

                String[] rolAndName = item.Value.ToString().Split('-');


                if (rolAndName[0] != "TODOS")
                {
                    if (isLogged)
                    {
                        if (HttpContext.Current.User.IsInRole(rolAndName[1]))
                        {
                            NavigationMenu.Items.Add(item);
                        }
                    }

                }
                else
                {
                    NavigationMenu.Items.Add(item);
                }
            }
        }
    }
}