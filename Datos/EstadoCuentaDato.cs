using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class EstadoCuentaDato
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_estado_cuenta_todos");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "estado_cuenta");
            return ds;
        }

        public static SqlDataReader SeleccionarEstadoCuenta(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_estado_cuenta_todos");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoCuenta_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }
    }
}
