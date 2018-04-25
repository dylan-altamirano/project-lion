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
    public partial class reporteFiltrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarFiltros();

                //carga el reporte inicialmente con la fecha de hoy y las que estén asociadas con una mesa
                cargarReporte(DateTime.Now, DateTime.Now, "Mesa", 1);
            }
        }

        private void cargarFiltros()
        {
            cboFiltros.Items.Add("Mesa");
            cboFiltros.Items.Add("Producto");
            cboFiltros.Items.Add("Usuario");

            cboFiltros.DataBind();
        }


        private void cargarReporte(DateTime fecha_ini, DateTime fecha_fin, string criterio, int opcion)
        {
            //Reset
            reportViewerFiltrado.Reset();

            //Data Source

            DataTable dt = ComandaLN.obtenerVentasFiltrado(fecha_ini, fecha_fin, criterio, opcion);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewerFiltrado.LocalReport.DataSources.Add(rds);

            //Path

            reportViewerFiltrado.LocalReport.ReportPath = "reporteVentasFiltrado.rdlc";

            //Parameters

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("fecha_ini", fecha_ini.ToShortDateString()),
                new ReportParameter("fecha_fin", fecha_fin.ToShortDateString()),
                new ReportParameter("criterio", criterio)
            };

            // Set parameters
            reportViewerFiltrado.LocalReport.SetParameters(rptParams);

            //Refresh

            reportViewerFiltrado.LocalReport.Refresh();
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

                if (cboFiltros.SelectedValue.Equals("Mesa"))
                {
                    cargarReporte(f_ini, f_fin, txtBusqueda.Text, 1);
                }
                else if (cboFiltros.SelectedValue.Equals("Usuario"))
                {
                    cargarReporte(f_ini, f_fin, txtBusqueda.Text, 2);
                }
                else if (cboFiltros.SelectedValue.Equals("Producto"))
                {
                    cargarReporte(f_ini, f_fin, txtBusqueda.Text, 3);
                }
                
            }
        }
    }
}