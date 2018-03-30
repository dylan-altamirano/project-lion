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
    public partial class gestion_perfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarRoles();
                cargarGridView();
            }

        }

        protected void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmdRegistrarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void cargarRoles()
        {
            cboRoles.DataSource = Enum.GetValues(typeof(rol));
            cboRoles.DataBind();
        }

        private void cargarGridView()
        {
            List<usuario> usuarios = new List<usuario>();

            usuarios = UsuarioLN.ObtenerTodos("ADMINISTRADOR");

            grvUsuarios.DataSource = usuarios;
            grvUsuarios.DataBind();
        }
    }
}