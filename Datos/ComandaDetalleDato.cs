using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ComandaDetalleDato
    {

        public static DataSet SeleccionarTodos(string comanda_id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_detalle");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);

            DataSet ds = db.ExecuteReader(comando, "comanda_detalle");
            return ds;
        }

        public static SqlDataReader SeleccionarComandaDetalle(string idComanda, string idProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_detalle_uni");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", idComanda);
            comando.Parameters.AddWithValue("@producto_id", idProducto);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        public static void Insertar(string comanda_id, ComandaDetalle detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_comanda_detalle");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);
            comando.Parameters.AddWithValue("@producto_id", detalle.producto.producto_id);
            comando.Parameters.AddWithValue("@cantidad", detalle.cantidad);
            comando.Parameters.AddWithValue("@notas", detalle.notas);

            db.ExecuteNonQuery(comando);
        }

        public static void Modificar(string comanda_id, ComandaDetalle detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_comanda_detalle");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);
            comando.Parameters.AddWithValue("@producto_id", detalle.producto.producto_id);
            comando.Parameters.AddWithValue("@cantidad", detalle.cantidad);
            comando.Parameters.AddWithValue("@notas", detalle.notas);

            db.ExecuteNonQuery(comando);
        }

        public static void Eliminar(string comanda_id, string producto_id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_eliminar_detalle");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);
            comando.Parameters.AddWithValue("@producto_id", producto_id);
            
            db.ExecuteNonQuery(comando);
        }
    }
}
