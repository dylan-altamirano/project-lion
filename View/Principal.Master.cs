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
            usuario Usuario = new usuario();

            Usuario = (usuario)Session["usuarioLogueado"];


            lblUsuarioActivo.Text = "Bievenido "+ Usuario.nombreUsuario;
            lblUsuarioActivo.Text.Equals(System.Drawing.FontStyle.Italic);
        }
    }
}