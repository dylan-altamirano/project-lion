using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class gestion_reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdlReporteVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteVentas.aspx");
        }

        protected void cmdlReporteMetodoPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteVentasMetodoPago.aspx");
        }

        protected void cmdlReporteFiltrado_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteFiltrado.aspx");
        }
    }
}