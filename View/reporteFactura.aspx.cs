using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginaNegocio;
using Entidades;


namespace View.Reportes
{
    public partial class reporteFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //cagarReporte();
            }
        }

        private void cagarReporte()
        {

            //crvFactura report = new crvFactura();

            //Comanda comanda = new Comanda();

            //comanda = (Comanda)Session["comanda_actual"];

            //DataSetFactura ds = new DataSetFactura();

            //report.SetDataSource(ds);

            //report.SetParameterValue("nombreClientep", comanda.nombreCliente);
            //report.SetParameterValue("fechap", comanda.fecha.ToShortDateString());
            //report.SetParameterValue("mesaIdp", comanda.mesa.mesa_id);
            //report.SetParameterValue("estadoCuentaIdp", comanda.estadoCuenta.descripcion);
            //report.SetParameterValue("totalFacturap", comanda.obtenerTotal());

            //CrystalReportViewerFactura.ReportSource = report;
            //CrystalReportViewerFactura.DataBind();
        }
    }
}