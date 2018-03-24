using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDato
    {
        public static SqlDataReader SeleccionarUsuario()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_usuario");
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        /// <summary>
        /// Retorna un usuario si las credenciales coinciden con
        /// los datos guardados en la base de datos.
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader AutenticarUsuario()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_autenticar_usuario");
            comando.CommandType = CommandType.StoredProcedure;

           

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }
    }
}
