using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using LoginaNegocio;
using System.Globalization;
using System.Text;

namespace View
{
    public partial class facturacion : System.Web.UI.Page
    {

        private static Comanda comanda = new Comanda();

        private static string pago_code = "";

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboMeses();
                llenarComboAnnos();
                llenarComboMetodosPago();
                esconderDetallePago();

                //cargar la comanda
                comanda = (Comanda)Session["comanda_actual"];

                //cargar el balance inicial que es eventualmente el mismo total de la orden
                comanda.actualizarBalance(comanda.obtenerTotal());

                //cargar estados comandas
                cargarEstadosComadas();

                //Cargar detalle de comanda actual
                asignarDatosSegunComanda(comanda);

                txtComandaID.Attributes.Add("readonly", "readonly");
                txtFecha.Attributes.Add("readonly", "readonly");
                txtNombreCliente.Attributes.Add("readonly", "readonly");
                txtEstadoCuenta.Attributes.Add("readonly", "readonly");
                cboEstadoComanda.Attributes.Add("readonly", "readonly");
                txtMesa.Attributes.Add("readonly", "readonly");
            }
        }

        protected void cmdAgregarMetodoPago_Click(object sender, EventArgs e)
        {
            if (cboMetodosPago.SelectedValue.Equals("CASH-201"))
            {
                cargarEfectivoOption(true);
                cargarTarjetaOption(false);

                //Establecer el pago
                realizarMetodoEfectivo(comanda.obtenerTotal());

                txtTotalEfectivo.ReadOnly = true;

                pago_code = cboMetodosPago.SelectedValue;

                lblTotalFactura.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture); 


            }
            else if (cboMetodosPago.SelectedValue.Equals("CC-101"))
            {
                cargarTarjetaOption(true);
                cargarEfectivoOption(false);

                //Establecer el pago
                realizarMetodoTarjeta(comanda.obtenerTotal());

                txtTotalEfectivo.ReadOnly = true;

                pago_code = cboMetodosPago.SelectedValue;

                lblTotalFactura.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture);



            }
            else if(cboMetodosPago.SelectedValue.Equals("CC/CASH-00"))
            {
                cargarTarjetaOption(true);
                cargarEfectivoOption(true);

                lblTotalFactura.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture);

                pago_code = cboMetodosPago.SelectedValue;
            }
        }

        private void llenarComboMeses()
        {
            List<int> arrayMeses = new List<int>();

            for (int i = 01; i <= 12; i++)
            {
                arrayMeses.Add(i);
            }

            cboMeses.DataSource = arrayMeses;
            cboMeses.DataBind();
           
        }

        private void llenarComboAnnos()
        {
            List<int> arrayAnnos = new List<int>();

            for (int i = 1995; i <= 2035; i++)
            {
                arrayAnnos.Add(i);
            }

            cboAnnos.DataSource = arrayAnnos;
            cboAnnos.DataBind();
        }

        private void llenarComboMetodosPago()
        {
            List<MetodoPago> arrayMetodosPago = new List<MetodoPago>();

            arrayMetodosPago = MetodoPagoLN.ObtenerTodos();

            cboMetodosPago.DataSource = arrayMetodosPago;
            cboMetodosPago.DataValueField = "metodoPago_id";
            cboMetodosPago.DataTextField = "description";
            cboMetodosPago.DataBind();
        }

        private void cargarEfectivoOption(bool bandera)
        {
            lblTotalEfectivo.Visible = bandera;
            txtTotalEfectivo.Visible = bandera;
        }

        private void cargarTarjetaOption(bool bandera)
        {
            lblNumeroTarjeta.Visible = bandera;
            lblExpirationDate.Visible = bandera;
            lblTotalTarjeta.Visible = bandera;

            txtNumeroTarjeta.Visible = bandera;
            txtTotalTarjeta.Visible = bandera;
            cboAnnos.Visible = bandera;
            cboMeses.Visible = bandera;
        }

        private void esconderDetallePago()
        {
            //Efectivo
            cargarEfectivoOption(false);

            //Tarjeta
            cargarTarjetaOption(false);
        }

        private void realizarMetodoEfectivo(double monto)
        {
            MetodoPago metodo = new MetodoPago();

            txtTotalEfectivo.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture);
            

            metodo = MetodoPagoLN.SeleccionarMetodoPago("CASH-201");

            comanda.realizarPago(metodo, monto);

        }

        private void realizarMetodoTarjeta(double monto)
        {
            MetodoPago metodo = new MetodoPago();

            txtTotalTarjeta.Text = comanda.obtenerTotal().ToString("C", CultureInfo.CurrentCulture);

            metodo = MetodoPagoLN.SeleccionarMetodoPago("CC-101");

            comanda.realizarPago(metodo, monto);

        }

        /// <summary>
        /// Finalizar la comanda con la facturacion del dinero relacionado con la comanda.
        /// </summary>
        /// <param name="comanda"></param>
        private void cancelarCuenta(Comanda comanda)
        {

            if (comanda.estadoCuenta.estadoCuenta_id.Equals("CXP"))
            {
                //update comanda
                foreach (PagoCuenta item in comanda.obtenerDetallePagos())
                {
                    try
                    {
                        //Actualiza y guarda el pago de la comanda con su respectivo monto
                        PagoCuentaLN.Nuevo(comanda.comanda_id, item);

                        //Actualiza el estado de la cuenta

                        //crea un nuevo objeto 'EstadoCuenta'
                        EstadoCuenta estadoCuenta = new EstadoCuenta();

                        //Selecciona el objeto desde la base de datos
                        estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta("C-SUCCESS");

                        //Se agrega el objeto a la comanda actual
                        comanda.estadoCuenta = estadoCuenta;

                        //Actualiza el estado de la comanda a finalizada
                        comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda("FIN");

                        //Actualiza el estado de la cuenta a nivel de datos
                        ComandaLN.Modificar(comanda);

                        //Liberar la mesa
                        liberarMesa(comanda);

                        lblErrorMessage.Text = "La comanda has sido cancelada satisfactoriamente. Espere unos segundos y será redirigido a la página principal de comandas.";
                        lblErrorMessage.CssClass = "alert alert-success";
                        Response.AppendHeader("Refresh", "2;url=gestion-mesas.aspx");
                    }
                    catch (Exception ex)
                    {

                        lblErrorMessage.Text = "Ha ocurrido un error al procesar el pago de la comanda.\n" +

                            "Código de error: " + ex.Message;
                    }
                }

            }


        }

        /// <summary>
        /// Libera la mesa despues de cumplida y, cancelada la orden.
        /// </summary>
        /// <param name="comanda"></param>
        private void liberarMesa(Comanda comanda)
        {
            Mesa mesa = new Mesa();

            mesa = comanda.mesa;

            mesa.ocupado = false;

            MesaLN.Modificar(mesa);

        }

        protected void cmdRealizarPago_Click(object sender, EventArgs e)
        {
            if (comanda != null)
            {
                if (pago_code.Equals("CASH-201"))
                {
                    cancelarCuenta(comanda);


                }
                else if (pago_code.Equals("CC-101"))
                {
                    StringBuilder sbFecha = new StringBuilder();                    
                    
                    //Construye la fecha a partir de los valores seleccionados por el usuario

                    sbFecha.Append(cboAnnos.SelectedValue); //añade el año
                    sbFecha.Append("-");
                    sbFecha.Append(((Convert.ToInt32(cboMeses.SelectedValue) >= 10) ? cboMeses.SelectedValue : "0" + cboMeses.SelectedValue)); //añade el mes
                    sbFecha.Append("-");
                    sbFecha.Append("01"); //Añade el dia 
                    sbFecha.Append(" ").Append("00:00:00 AM");

                    //Conovertir el string a un objeto de fecha
                    DateTime fechaExpiracion = DateTime.Parse(sbFecha.ToString());

                    if (validarPagoConTarjeta(txtNumeroTarjeta.Text, fechaExpiracion))
                    {
                        cancelarCuenta(comanda);
                    }else
                    {
                        lblErrorMessage.Text = "El numero de tarjeta o la fecha introducida son inválidos. Por favor, intentelo de nuevo.";

                        lblErrorMessage.CssClass = "alert alert-warning";
                    }


                }
                else if (pago_code.Equals("CC/CASH-00"))
                {

                    try
                    {
                        if (verificaMontoPagoDividido(Convert.ToDouble(txtTotalTarjeta.Text), Convert.ToDouble(txtTotalEfectivo.Text)))
                        {

                            realizarMetodoEfectivo(Convert.ToDouble(txtTotalEfectivo.Text));

                            realizarMetodoTarjeta(Convert.ToDouble(txtTotalTarjeta.Text));


                            StringBuilder sbFecha = new StringBuilder();

                            //Construye la fecha a partir de los valores seleccionados por el usuario

                            sbFecha.Append(cboAnnos.SelectedValue); //añade el año
                            sbFecha.Append("-");
                            sbFecha.Append(((Convert.ToInt32(cboMeses.SelectedValue) >= 10) ? cboMeses.SelectedValue : "0" + cboMeses.SelectedValue)); //añade el mes
                            sbFecha.Append("-");
                            sbFecha.Append("01"); //Añade el dia 
                            sbFecha.Append(" ").Append("00:00:00 AM");

                            //Conovertir el string a un objeto de fecha
                            DateTime fechaExpiracion = DateTime.Parse(sbFecha.ToString());

                            if (validarPagoConTarjeta(txtNumeroTarjeta.Text, fechaExpiracion))
                            {
                                cancelarCuenta(comanda);
                            }
                            else
                            {
                                lblErrorMessage.Text = "El numero de tarjeta o la fecha introducida son inválidos. Por favor, intentelo de nuevo.";

                                lblErrorMessage.CssClass = "alert alert-warning";
                            }


                        }else
                        {
                            lblErrorMessage.Text = "Los montos relacionados al pago no son congruentes al total a cancelar. Por favor, intentelo de nuevo.";

                            lblErrorMessage.CssClass = "alert alert-warning";
                        }
                    }
                    catch (Exception ex)
                    {

                        lblErrorMessage.Text = "Ha ocurrido un error al procesar los montos del pago dividido.\n"+
                            
                            "Código de error: "+ ex.Message;
                    }



                } //End-of-Else (CC/CASH) option

            } //End-of comanda != null condition

            
        } //End-of realizar pago event

        /// <summary>
        /// Método que valida que el numero de tarjeta y la fecha de expiracion de la misma,
        /// sean correctos y, validos.
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="fechaExpiracion"></param>
        /// <returns></returns>
        private bool validarPagoConTarjeta(string numero, DateTime fechaExpiracion)
        {
            if (Comanda.esTarjetaValida(numero) && fechaExpiracion >= DateTime.Now)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica que los montos ingresados para el pago dividido son correctos.
        /// </summary>
        /// <param name="montoCC"></param>
        /// <param name="montoCash"></param>
        /// <returns></returns>
        private bool verificaMontoPagoDividido(double montoCC, double montoCash)
        {

            if ( (montoCC+montoCash)>comanda.obtenerTotal())
            {
                return false;
            }
            else if ((montoCC+montoCash)<comanda.obtenerTotal())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Asigna el detalle de la comanda a cancelar el pago.
        /// </summary>
        /// <param name="comanda"></param>
        private void asignarDatosSegunComanda(Comanda comanda)
        {

            txtComandaID.Text = comanda.comanda_id;
            txtNombreCliente.Text = comanda.nombreCliente;
            txtFecha.Text = comanda.fecha.ToShortDateString();

            cboEstadoComanda.SelectedValue = comanda.estadoComanda.estadoComanda_id;

            txtEstadoCuenta.Text = comanda.estadoCuenta.descripcion;
            txtMesa.Text = comanda.mesa.mesa_id;

        }

        /// <summary>
        /// Carga los estados de la comanda al combo de detalle de la 
        /// comanda respectivamente realizando el pago.
        /// </summary>
        private void cargarEstadosComadas()
        {
            List<EstadoComanda> arrayEstados = new List<EstadoComanda>();

            arrayEstados = EstadoComandaLN.ObtenerTodos();

            cboEstadoComanda.DataSource = arrayEstados;
            cboEstadoComanda.DataTextField = "descripcion";
            cboEstadoComanda.DataValueField = "estadoComanda_id";
            cboEstadoComanda.DataBind();
        }


    }
}