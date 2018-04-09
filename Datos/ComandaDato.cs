using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class ComandaDato
    {
        public static DataSet SeleccionarTodos(string estadoComanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_enprogreso");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoComanda", estadoComanda);

            DataSet ds = db.ExecuteReader(comando, "comanda");
            return ds;
        }

        public static SqlDataReader SeleccionarComanda(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        public static void Insertar(Comanda comanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoComanda_id", comanda.estadoComanda.estadoComanda_id);
            comando.Parameters.AddWithValue("@mesa_id", comanda.mesa.mesa_id);
            comando.Parameters.AddWithValue("@estadoCuenta_id", comanda.estadoCuenta.estadoCuenta_id);
            comando.Parameters.AddWithValue("@nombreCliente", comanda.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", comanda.fecha);
            comando.Parameters.AddWithValue("@usuario_id", comanda.usuarioComanda.usuario_id);

            db.ExecuteNonQuery(comando);
        }

        public static void Modificar(Comanda comanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda.comanda_id);
            comando.Parameters.AddWithValue("@estadoComanda", comanda.estadoComanda.estadoComanda_id);
            comando.Parameters.AddWithValue("@mesa_id", comanda.mesa.mesa_id);
            comando.Parameters.AddWithValue("@estadoCuenta_id", comanda.estadoCuenta.estadoCuenta_id);
            comando.Parameters.AddWithValue("@nombreCliente", comanda.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", comanda.fecha);
            comando.Parameters.AddWithValue("@usuario_id", comanda.usuarioComanda.usuario_id);

            db.ExecuteNonQuery(comando);
        }
    }
}
