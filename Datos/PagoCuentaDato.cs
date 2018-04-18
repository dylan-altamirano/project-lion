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
    public class PagoCuentaDato
    {
        /// <summary>
        /// Selecciona los metodos de pago de la cuenta del origen de datos.
        /// </summary>
        /// <param name="comanda_id"></param>
        /// <returns></returns>
        public static DataSet SeleccionarTodos(string comanda_id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_pago_cuenta");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);

            DataSet ds = db.ExecuteReader(comando, "pago_cuenta");
            return ds;
        }

        /// <summary>
        /// Inserta un nuevo registro relaccionado con la comanda y sus metodos de pago.
        /// </summary>
        /// <param name="comanda_id"></param>
        /// <param name="pagoCuenta"></param>
        public static void Insertar(string comanda_id, PagoCuenta pagoCuenta)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_pago_cuenta");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda_id);
            comando.Parameters.AddWithValue("@metodoPago_id", pagoCuenta.metodoPago.metodoPago_id);
            comando.Parameters.AddWithValue("@monto", pagoCuenta.monto);
            
            db.ExecuteNonQuery(comando);
        }
    }
}
