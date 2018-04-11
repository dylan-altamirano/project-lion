using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;
using System.Globalization;

namespace View
{
    public partial class administrar_comanda : System.Web.UI.Page
    {
        //private int opcion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                cargarEstadosComadas();
                obtenerDatosComandaActual();
                cargarDetalleComanda();

                modificarEstadoControlesSegunEstadoComanda();

                //establecer componentes de solo lectura
                establecerComponenteSoloLectura(txtComandaID);
                establecerComponenteSoloLectura(txtFecha);
                establecerComponenteSoloLectura(txtNombreCliente);

                //Session["comanda_actual"] = null;
            }
        }

        protected void cmdOrdenar_Click(object sender, EventArgs e)
        {
            establecerSesionComandaActual();

            Response.Redirect("menu-productos.aspx");
        }

        private void cargarEstadosComadas()
        {
            List<EstadoComanda> arrayEstados = new List<EstadoComanda>();

            arrayEstados = EstadoComandaLN.ObtenerTodos();

            cboEstadoComanda.DataSource = arrayEstados;
            cboEstadoComanda.DataTextField = "descripcion";
            cboEstadoComanda.DataValueField = "estadoComanda_id";
            cboEstadoComanda.DataBind();
        }

        private void obtenerDatosComandaActual()
        {
            Comanda comanda = new Comanda();

            comanda = ComandaLN.SeleccionarComandaSegunMesaAsignada((string)Session["mesa_id"]);

            if (comanda != null)
            {
                comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(comanda.estadoComanda.estadoComanda_id);
                comanda.mesa = MesaLN.SeleccionarMesa(comanda.mesa.mesa_id);
                comanda.estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta(comanda.estadoCuenta.estadoCuenta_id);

                asignarDatosSegunComanda(comanda);
            }

            establecerSesionComandaActual();
        }

        private void asignarDatosSegunComanda(Comanda comanda)
        {

            txtComandaID.Text = comanda.comanda_id;
            txtNombreCliente.Text = comanda.nombreCliente;
            txtFecha.Text = comanda.fecha.ToShortDateString();

            cboEstadoComanda.SelectedValue = comanda.estadoComanda.estadoComanda_id;

        }

        private void establecerComponenteSoloLectura(TextBox txt)
        {
            txt.Attributes.Add("readonly", "readonly");
        }

        private void establecerSesionComandaActual()
        {
            Comanda comanda = new Comanda();

            comanda = ComandaLN.SeleccionarComanda(txtComandaID.Text);

            Session["comanda_actual"] = comanda;
        }

        private void cargarDetalleComanda()
        {
            List<ComandaDetalle> arrayDetalle = new List<ComandaDetalle>();

            Comanda comanda = new Comanda();

            comanda = (Comanda)Session["comanda_actual"];

            if (comanda.obtenerDetalle() != null && comanda.obtenerDetalle().Count > 0)
            {
                grvComandaDetalle.DataSource = comanda.obtenerDetalle();
                grvComandaDetalle.DataBind();


                cargarTotalComanda(comanda);

            } else
            {
                arrayDetalle = ComandaDetalleLN.ObtenerTodos(comanda.comanda_id);

                foreach (ComandaDetalle item in arrayDetalle)
                {
                    comanda.agregarPedido(item.producto, item.cantidad, item.notas);

                }

                grvComandaDetalle.DataSource = comanda.obtenerDetalle();
                grvComandaDetalle.DataBind();

                cargarTotalComanda(comanda);

            }
        }

        protected void cmdFormalizar_Click(object sender, EventArgs e)
        {
            modificarVidaComanda((Comanda)Session["comanda_actual"], "IN-P");

            cmdFormalizar.Enabled = false;

            Response.AppendHeader("Refresh", "1;url=administrar-comanda.aspx");
        }

        private void cargarTotalComanda(Comanda comanda)
        {

            tdIVA.Text = comanda.obtenerIVA().ToString("C", CultureInfo.CurrentCulture);


            tdSubtotal.Text = comanda.obtenerTotalOrden().ToString("C", CultureInfo.CurrentCulture);
            tdTotal.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture);

        }

        /// <summary>
        /// Actualiza el estado de la comanda para comenzar el ciclo de vida.
        /// A este estado, no hay cambios permitidos en la orden.
        /// </summary>
        /// <param name="comanda"></param>
        private void modificarVidaComanda(Comanda comanda, string estado)
        {
            try
            {

                comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(estado);

                ComandaLN.Modificar(comanda);

                lblErrorMessage.Text = "Se ha actualizado el estado de la comanda con éxito. Espere un unos segundos mientras se refleja el cambio en pantalla.";
                lblErrorMessage.CssClass = "alert alert-success";

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Ha ocurrido un error al formalizar la orden.\n" +

                    "Código de error: " + ex.Message;

                lblErrorMessage.CssClass = "alert alert-danger";
            }
        }

        private void modificarEstadoControlesSegunEstadoComanda()
        {
            Comanda comanda = new Comanda();

            comanda = (Comanda)Session["comanda_actual"];


            if (comanda.estadoComanda.estadoComanda_id.Equals("RE"))
            {
                cmdFormalizar.Visible = true;
                cmdEntregar.Visible = false;
                cmdOrdenar.Visible = true;
                cmdFacturar.Visible = false;
            }
            else if (comanda.estadoComanda.estadoComanda_id.Equals("IN-P"))
            {
                cmdFormalizar.Visible = false;
                cmdOrdenar.Visible = false;
                cmdEntregar.Visible = true;
                cmdFacturar.Visible = false;

                grvComandaDetalle.Columns[5].Visible = false;
            }
            else if (comanda.estadoComanda.estadoComanda_id.Equals("DE"))
            {
                cmdFormalizar.Visible = false;
                cmdOrdenar.Visible = false;
                cmdEntregar.Visible = false;
                cmdFacturar.Visible = true;

                grvComandaDetalle.Columns[5].Visible = false;
            }
        }

        protected void cmdEntregar_Click(object sender, EventArgs e)
        {
            modificarVidaComanda((Comanda)Session["comanda_actual"], "DE");

            cmdEntregar.Enabled = false;

            Response.AppendHeader("Refresh", "1;url=administrar-comanda.aspx");
        }

        protected void grvComandaDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iRowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ShowPopup();", true);

                GridViewRow fila = grvComandaDetalle.Rows[iRowIndex];

                string producto_id = fila.Cells[0].Text;


                Comanda comanda = new Comanda();

                comanda = (Comanda)Session["comanda_actual"];



                try
                {
                    ComandaDetalleLN.Eliminar(comanda.comanda_id, producto_id);

                    lblErrorMessage.Text = "Se ha eliminado el pedido con el producto Nº " + producto_id + " " + fila.Cells[1].Text + " con éxito. Proceda a seleccionar otro o formalice la orden.";
                    lblErrorMessage.CssClass = "alert alert-success";

                    Response.AppendHeader("Refresh", "1;url=administrar-comanda.aspx");

                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Ha ocurrido un error al eliminar el pedido.\n" +

                    "Código de error: " + ex.Message;

                    lblErrorMessage.CssClass = "alert alert-danger";

                }


            }
        }

        protected void cmdFacturar_Click(object sender, EventArgs e)
        {

        }
    }
}