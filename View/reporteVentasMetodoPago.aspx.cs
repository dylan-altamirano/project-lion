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

namespace View
{
    public partial class reporteVentasMetodoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarMetodosPago();

                //carga el reporte inicialmente con la fecha de hoy y las que estén pagas con tarjeta
                cargarReporte(DateTime.Now, DateTime.Now, "CC-101");
            }
        }

        protected void cmdFiltrarReporte_Click(object sender, EventArgs e)
        {

            DateTime f_ini = new DateTime();
            DateTime f_fin = new DateTime();

            bool bandera = false;

            bandera = DateTime.TryParse(txtFechaIni.Text, out f_ini);
            bandera = DateTime.TryParse(txtFechaFin.Text, out f_fin);

            if (bandera)
            {
                cargarReporte(f_ini, f_fin, cboMetodosPago.SelectedValue);
            }

            
        }

        private void cargarMetodosPago()
        {
            List<MetodoPago> arrayMetodosPago = new List<MetodoPago>();

            arrayMetodosPago = MetodoPagoLN.ObtenerTodos();

            cboMetodosPago.DataSource = arrayMetodosPago;
            cboMetodosPago.DataValueField = "metodoPago_id";
            cboMetodosPago.DataTextField = "description";
            cboMetodosPago.DataBind();
        }

        private void cargarReporte(DateTime fecha_ini, DateTime fecha_fin, string metodo)
        {
            //Reset
            reportViewerMetodoPago.Reset();

            //Data Source

            DataTable dt = ComandaLN.obtenerVentasPorMetodoPago(fecha_ini, fecha_fin, metodo);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewerMetodoPago.LocalReport.DataSources.Add(rds);

            //Path

            reportViewerMetodoPago.LocalReport.ReportPath = "reporteMetodoPago.rdlc";

            //Parameters

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("fecha_ini", fecha_ini.ToShortDateString()),
                new ReportParameter("fecha_fin", fecha_fin.ToShortDateString()),
            };

            // Set parameters
            reportViewerMetodoPago.LocalReport.SetParameters(rptParams);

            //Refresh

            reportViewerMetodoPago.LocalReport.Refresh();
        }

    }
}