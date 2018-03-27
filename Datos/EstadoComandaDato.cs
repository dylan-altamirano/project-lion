using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EstadoComandaDato
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_estado_comanda_todos");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "estado_comanda");
            return ds;
        }

        public static SqlDataReader SeleccionarEstadoComanda(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_estado_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoComanda_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }
    }
}
