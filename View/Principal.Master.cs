using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Vista
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                usuario Usuario = new usuario();

                Usuario = (usuario)Session["usuarioLogueado"];


                lblUsuarioActivo.Text = "Bievenido " + Usuario.nombreUsuario;
                lblUsuarioActivo.Text.Equals(System.Drawing.FontStyle.Italic);

                string childPage = this.ContentPlaceHolder1.Page.GetType().BaseType.FullName;

                if (childPage.Equals("Vista.gestion_mesas") || childPage.Equals("View.administrar_comanda") || childPage.Equals("View.menu_productos"))
                {
                    lblGestionMesas.Visible = true;
                }
            }

            
        }
    }
}