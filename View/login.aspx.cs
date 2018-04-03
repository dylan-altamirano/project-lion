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
    public partial class login : System.Web.UI.Page
    {
        private usuario Usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
            }
  
        }

        protected void cmdIngresar_Click(object sender, EventArgs e)
        {
            this.Usuario = new usuario();

            this.Usuario.nombreUsuario = txtUsuario.Text;
            this.Usuario.clave = txtPassword.Text;

            this.Usuario = UsuarioLN.AutenticarUsuario(this.Usuario);

            if (Usuario !=null)
            {

                Session["usuarioLogueado"] = this.Usuario;

                Response.Redirect("dashboard.aspx");
            }else
            {
                Response.Redirect("login.aspx");
            }

        }
    }
}