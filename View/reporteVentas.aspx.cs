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
    public partial class reporteVentas : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarEstadoCuenta();

                //carga el reporte inicialmente con la fecha de hoy y las que estén pagas
                cargarReporte(DateTime.Now, DateTime.Now, "CXP");
            }
        }

        protected void cmdFiltrarReporte_Click(object sender, EventArgs e)
        {
            cargarReporte(calFechaIni.SelectedDate, calFechaFin.SelectedDate, cboEstadoCuenta.SelectedValue);
        }

        private void cargarEstadoCuenta()
        {
            List<EstadoCuenta> arrayEstadosCuenta = new List<EstadoCuenta>();

            arrayEstadosCuenta = EstadoCuentaLN.ObtenerTodos();

            cboEstadoCuenta.DataSource = arrayEstadosCuenta;
            cboEstadoCuenta.DataValueField = "estadoCuenta_id";
            cboEstadoCuenta.DataTextField = "descripcion";
            cboEstadoCuenta.DataBind();
        }

        private void cargarReporte(DateTime fecha_ini, DateTime fecha_fin, string estado)
        {
            //Reset
            ReportViewerVentas.Reset();

            //Data Source

            DataTable dt = ComandaLN.obtenerVentasPorFecha(fecha_ini, fecha_fin, estado);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            ReportViewerVentas.LocalReport.DataSources.Add(rds);

            //Path

            ReportViewerVentas.LocalReport.ReportPath = "reporteVentasPorFecha.rdlc";

            //Parameters

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("fecha_ini", fecha_ini.ToShortDateString()),
                new ReportParameter("fecha_fin", fecha_fin.ToShortDateString()),
                new ReportParameter("estado", estado)
            };

            // Set parameters
            ReportViewerVentas.LocalReport.SetParameters(rptParams);

            //Refresh

            ReportViewerVentas.LocalReport.Refresh();
        }

    }
}