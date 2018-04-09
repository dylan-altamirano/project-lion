using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;

namespace View
{
    public partial class buscar_mesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (!txtBuscar.Text.Equals(""))
            {
                buscarMesaSegunFiltro(txtBuscar.Text);
            }
        }

        private void buscarMesaSegunFiltro(string criterio)
        {
            Mesa mesa = new Mesa();

            mesa = MesaLN.SeleccionarMesa(criterio);

            if (mesa != null)
            {
                txtIdentificacionMesa.Text = mesa.mesa_id;
                rblOcupado.SelectedValue = (mesa.ocupado) ? "1" : "0";
                rblActivo.SelectedValue = (mesa.activo) ? "1" : "0";
            }else
            {
                lblErrorMessage.Text = "No se ha encontrado registros con la descripción indicada";
                lblErrorMessage.CssClass = "alert alert-warning form-control";
                
            }

        }

        protected void cmdGuardarMesa_Click(object sender, EventArgs e)
        {
            guardarMesa(((rblOcupado.SelectedValue.Equals("1")) ? true : false), ((rblActivo.SelectedValue.Equals("1")) ? true : false));
        }

        private void guardarMesa(bool ocupado, bool activo)
        {

            Mesa mesa = new Mesa();

            mesa.ocupado = ocupado;
            mesa.activo = activo;

            if (txtIdentificacionMesa.Text != null && !txtIdentificacionMesa.Text.Equals(""))
            {
                mesa.mesa_id = txtIdentificacionMesa.Text;

                MesaLN.Modificar(mesa);

                lblErrorMessage.Text = "La mesa se ha modificado correctamente";
                lblErrorMessage.CssClass = "alert alert-success";

                //Redirige a la página de gestión de las mesas después de 2 segundos
                Response.AppendHeader("Refresh", "2;url=gestion-mesas.aspx");
            }else
            {
                lblErrorMessage.Text = "No se ha encontrado registros a modificar, verifique que el dato consultado sea correcto.";
                lblErrorMessage.CssClass = "alert alert-warning form-control";
            }

           
        }
    }
}