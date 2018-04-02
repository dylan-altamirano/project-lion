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
                cargarFiltroBusqueda();
            }

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

        private void cargarFiltroBusqueda()
        {
            DropDownList1.DataSource = Enum.GetValues(typeof(rol));
            DropDownList1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarUsuariosSergunCriterio();
        }


        private void cargarUsuariosSergunCriterio()
        {
            List<usuario> usuarios = new List<usuario>();

            string criterio = DropDownList1.SelectedValue;

            usuarios = UsuarioLN.ObtenerTodos(criterio);

            grvUsuarios.DataSource = usuarios;
            grvUsuarios.DataBind();
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            buscarUsuario(txtBuscar.Text);
        }

        public void buscarUsuario(string usuario)
        {
            List<usuario> usuarios = new List<usuario>();

            usuario user = new usuario();

            user = UsuarioLN.SeleccionarUsuarioPorId(usuario);

            if (user != null)
            {
                usuarios.Add(user);

                grvUsuarios.DataSource = usuarios;
                grvUsuarios.DataBind();

            }
            else
            {
                user = new usuario();

                user = UsuarioLN.SeleccionarUsuario(usuario);

                if (user != null)
                {
                    usuarios.Add(user);

                    grvUsuarios.DataSource = usuarios;
                    grvUsuarios.DataBind();
                }

            }

        }

        /// <summary>
        /// Guarda un usuario en la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="nombreCompleto"></param>
        /// <param name="rolp"></param>
        /// <param name="clave"></param>
        /// <param name="activo"></param>
        public void guardarUsuario(string id, string nombreUsuario, string nombreCompleto, rol rolp, string clave, bool activo)
        {
            usuario user = null;
            //Busca la existencia de un usuario con las mismas caracteristicas
            user = UsuarioLN.SeleccionarUsuarioPorId(id);
            //Si existe se modificará, de lo contrario, se creará uno nuevo
            if (user != null)
            {
                user = new usuario(id, nombreUsuario, nombreCompleto, rolp, clave, activo);

                UsuarioLN.Modificar(user);
            } else
            {
                user = new usuario(id, nombreUsuario, nombreCompleto, rolp, clave, activo);

                UsuarioLN.Nuevo(user);
            }


        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            guardarUsuario(txtIdentificacion.Text, txtNombre.Text, txtNombreCompleto.Text, (rol)Enum.Parse(typeof(rol), cboRoles.SelectedValue), txtClave.Text, true);
        }

        protected void grvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int iRowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Select")
            {

                GridViewRow fila = grvUsuarios.Rows[iRowIndex];

                string nombreUsuario = fila.Cells[0].Text;

                usuario user = UsuarioLN.SeleccionarUsuario(nombreUsuario);

                txtIdentificacion.Text = user.usuario_id;

                txtNombre.Text = user.nombreUsuario;
                txtNombreCompleto.Text = user.nombreCompleto;
                cboRoles.SelectedValue = user.rolUsuario.ToString();
                txtClave.Text = "none";
                txtClave.Enabled = false;
            }


        }

        private void refrescarGridView()
        {
            if (txtBuscar.Text.Equals(""))
            {
                cargarUsuariosSergunCriterio();
            }else
            {
                buscarUsuario(txtBuscar.Text);
            }
        }
    }
}