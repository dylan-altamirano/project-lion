using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MetodoPagoDato
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_metodos_pago");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "metodo_pago");
            return ds;
        }

        public static SqlDataReader SeleccionarMetodoPago(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_metodo_pago");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@metodoPago_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }
    }
}
