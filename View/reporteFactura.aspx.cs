using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;
using Microsoft.Reporting.WebForms;
using System.Data;


namespace View.Reportes
{
    public partial class reporteFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cagarReporte();
            }
        }

        private void cagarReporte()
        {

            Comanda comanda = (Comanda)Session["comanda_actual"];

            //Reset
            reportViewerFactura.Reset();

            //Data Source

            DataTable dt = ComandaLN.obtenerReporteFiltrado(comanda.comanda_id);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewerFactura.LocalReport.DataSources.Add(rds);

            //Path

            reportViewerFactura.LocalReport.ReportPath = "factura.rdlc";

            //Parameters

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("comandaId", comanda.comanda_id),
                new ReportParameter("nombreCliente", comanda.nombreCliente),
                new ReportParameter("fecha", comanda.fecha.ToShortDateString()),
                new ReportParameter("totalf", comanda.obtenerTotal().ToString())
            };

            // Set parameters
            reportViewerFactura.LocalReport.SetParameters(rptParams);

            //Refresh

            reportViewerFactura.LocalReport.Refresh();

        }

        protected void cmdCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("gestion-mesas.aspx");
        }
    }
}