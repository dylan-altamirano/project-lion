using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;

namespace Vista
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                usuario user = new usuario();

                user = (usuario)Session["usuarioLogueado"];

                hfRol.Value = user.rolUsuario.ToString();

            }
        }
    }
}