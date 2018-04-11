using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Mesa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                string childPage = this.ContentPlaceHolderMesaDashboard.Page.GetType().BaseType.FullName;

                if (childPage.Equals("View.buscar_mesa") || childPage.Equals("View.crear_mesa"))
                {
                    cmdCancelarOperacion.Visible = true;
                }
            }
        }

        protected void cmdNuevaMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("crear-mesa.aspx");
        }

        protected void cmdBuscarMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscar-mesa.aspx");
        }

        protected void cmdCancelarOperacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("gestion-mesas.aspx");
        }
    }
}