using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;

namespace LoginaNegocio
{
    public class UsuarioLN
    {
        public static usuario SeleccionarUsuario(string nombre)
        {
            usuario Usuario = null;

            SqlDataReader data = UsuarioDato.SeleccionarUsuario(nombre);

            while (data.Read())
            {
                Usuario = new usuario();

                Usuario.usuario_id = data["usuario_id"].ToString();
                Usuario.nombreUsuario = data["nombre"].ToString();
                Usuario.nombreCompleto = data["nombreCompleto"].ToString();
                Usuario.rolUsuario = (rol)Enum.Parse(typeof(rol), data["rol"].ToString());
                Usuario.activo = Convert.ToBoolean(data["activo"]);
            }

            return Usuario;
        }

        public static usuario AutenticarUsuario(usuario user)
        {
            usuario Usuario = null;

            SqlDataReader data = UsuarioDato.AutenticarUsuario(user);

            while (data.Read())
            {
                Usuario = new usuario();

                Usuario.usuario_id = data["usuario_id"].ToString();
                Usuario.nombreUsuario = data["nombre"].ToString();
                Usuario.nombreCompleto = data["nombreCompleto"].ToString();
                Usuario.rolUsuario = (rol)Enum.Parse(typeof(rol), data["rol"].ToString());
                Usuario.activo = Convert.ToBoolean(data["activo"]);
            }

            return Usuario;
        }

        public static void Nuevo(usuario Usuario)
        {
            if (UsuarioDato.SeleccionarUsuario(Usuario.nombreUsuario) != null)
            {
                UsuarioDato.Insertar(Usuario);
            }
        }

        public static void Modificar(usuario Usuario)
        {
            UsuarioDato.Modificar(Usuario);
        }
    }
}
