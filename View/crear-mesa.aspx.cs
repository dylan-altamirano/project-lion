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
    public partial class crear_mesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdGuardarMesa_Click(object sender, EventArgs e)
        {
            guardarMesa(((rblOcupado.SelectedValue.Equals("1")) ? true:false), ((rblActivo.SelectedValue.Equals("1")) ? true : false));
        }

        private void guardarMesa(bool ocupado, bool activo)
        {

            Mesa mesa = new Mesa();

            mesa.ocupado = ocupado;
            mesa.activo = activo;

            MesaLN.Nuevo(mesa);

            Response.Redirect("gestion-mesas.aspx");

        }
    }
}