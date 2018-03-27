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
    public class MesaDato
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_mesas ");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "mesa");
            return ds;
        }

        public static SqlDataReader SeleccionarMesa(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_mesa");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@mesa_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        /// <summary>
        /// Inserta un nuevo registro de mesa en la base de datos.
        /// </summary>
        /// <param name="mesa"></param>
        public static void Insertar(Mesa mesa)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_mesa");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ocupado", mesa.ocupado);
            comando.Parameters.AddWithValue("@activo", mesa.activo);

            db.ExecuteNonQuery(comando);
        }
        /*Sentencia del procedimiento almacenado
         */
        public static void Modificar(Mesa mesa)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_mesa");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@mesa_id", mesa.mesa_id);
            comando.Parameters.AddWithValue("@ocupado", mesa.ocupado);
            comando.Parameters.AddWithValue("@activo", mesa.activo);

            db.ExecuteNonQuery(comando);
        }
    }
}
