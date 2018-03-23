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
        public static SqlDataReader SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_SeleccionarAlquileres");
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }
    }
}
