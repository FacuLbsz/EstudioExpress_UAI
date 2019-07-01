using System;
using System.Web.UI;

namespace EstudioExpress.Helpers
{
    public static class MessageBox
    {
        public static void Show(this Page Page, string Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }

        public static void ShowAndRedirect(this Page Page, String Message, String aspx)
        {
            Page.ClientScript.RegisterStartupScript(
              Page.GetType(),
              "MessageBox",
              "<script language='javascript'>alert('" + Message + "');;  window.location = '" + aspx + "'</script>"
           );
        }
    }
}