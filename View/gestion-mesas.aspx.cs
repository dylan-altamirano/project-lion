using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;
using System.Text;
using System.Web.Services;

namespace Vista
{
    public partial class gestion_mesas : System.Web.UI.Page
    {
        private static List<Entidades.Mesa> arrayMesas = new List<Entidades.Mesa>();
        public string html = "";
        public StringBuilder sb = new StringBuilder();
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarMesas();
                Session["mesa_id"] = "";
                txtMesa_id.Attributes.Add("readonly", "readonly");
                txtMesaId2.Attributes.Add("readonly", "readonly");
            }
        }

        private void cargarMesas()
        {
            arrayMesas = MesaLN.ObtenerTodos();


            if (arrayMesas != null)
            {
                foreach (var item in arrayMesas)
                {

                    sb.Append("<div class='col-lg-3' style='margin:1%; background-color:" + ((item.ocupado) ? "#E3C54B" : "#4BE3A7") + "; '>" +
                        "<div class='card' style='margin:2%;'>" +
                            "<div class='card-body'>" +
                            "<h5 class='card-title'>Mesa Nº " + item.mesa_id + "</h5>" +
                                "<p class='card-text'>Estado: " + ((item.ocupado) ? "Ocupado" : "Libre") + "</p>");

                    if (item.ocupado)
                    {
                        sb.Append("<button id='" + item.mesa_id + "' type='button' class='btn btn-warning' data-toggle='modal' data-target='#administrarComanda' onclick='getMesaId(" + item.mesa_id + ");'>Administrar Orden</button>");
                    }
                    else
                    {
                        sb.Append("<button id='" + item.mesa_id + "' type='button' class='btn btn-info' data-toggle='modal' data-target='#AsignarMesa' onclick='getSession("+ item.mesa_id + ");'>Asignar</button>");
                    }


                    sb.Append("</div>" +
                            "</div>" +
                            "</div>");

                }

            }

        }

        protected void cmdAsignarMesa_Click(object sender, EventArgs e)
        {
            asignarMesa(txtMesa_id.Text, txtNombreCliente.Text);
        }

        private void asignarMesa(string mesa_idp, string nombre_cliente)
        {
            Comanda comanda = new Comanda();

            comanda.mesa.mesa_id = mesa_idp;
            comanda.nombreCliente = nombre_cliente;
            comanda.usuarioComanda = (usuario)Session["usuarioLogueado"];

            ComandaLN.Nuevo(comanda);

            //Selecciona la mesa

            Entidades.Mesa mesa = MesaLN.SeleccionarMesa(mesa_idp);

            //Modifica su estado
            mesa.ocupado = true;

            //Guarda su nuevo estado en base de datos
            MesaLN.Modificar(mesa);

            //Regresa a la pantalla principal
            Response.Redirect("gestion-mesas.aspx");

        }

        protected void cmdOrdenar_Click(object sender, EventArgs e)
        {
            Session["mesa_id"] = txtMesaId2.Text;

            if (!esFacturable((string)Session["mesa_id"]))
            {
                Response.Redirect("administrar-comanda.aspx");
            }
            else
            {
                lblErrorMessageMesaMaster.Text = "La comanda seleccionada no se puede modificar porque ha sido finalizada. Por favor, proceda a la facturación y cancelación de la misma.";
                lblErrorMessageMesaMaster.CssClass = "alert alert-info";
                Response.AppendHeader("Refresh", "2;url=gestion-mesas.aspx");

            }

            
        }

        protected void cmdFacturar_Click(object sender, EventArgs e)
        {
            Session["mesa_id"] = txtMesaId2.Text;
            if (esFacturable((string) Session["mesa_id"]))
            {
                Response.Redirect("administrar-comanda.aspx");
            }else
            {
                lblErrorMessageMesaMaster.Text = "La comanda seleccionada no se puede facturar todavía. Finalice la comanda primero para proceder.";
                lblErrorMessageMesaMaster.CssClass = "alert alert-warning";
                Response.AppendHeader("Refresh", "2;url=gestion-mesas.aspx");

            }
        }

        private bool esFacturable(string idMesa)
        {
            Comanda comanda = new Comanda();

            comanda = ComandaLN.SeleccionarComandaSegunMesaAsignada(idMesa);

            if (comanda != null)
            {
                comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(comanda.estadoComanda.estadoComanda_id);
                comanda.mesa = MesaLN.SeleccionarMesa(comanda.mesa.mesa_id);
                comanda.estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta(comanda.estadoCuenta.estadoCuenta_id);
            }

            if (comanda.estadoComanda.estadoComanda_id.Equals("DE"))
            {
                return true;
            }

            return false;
        }
    }
}