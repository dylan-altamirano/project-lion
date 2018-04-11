using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriaDato
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_categorias");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "categoria");

            return ds;
        }

        public static SqlDataReader SeleccionarCategoria(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_categoria_por_id");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@categoria_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);

            return reader;
        }
    }
}
