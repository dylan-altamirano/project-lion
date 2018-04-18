using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace LoginaNegocio
{
    public class PagoCuentaLN
    {
        /// <summary>
        /// Lista una serie de registros que incluyen el metodo de pago y,
        /// su respectivo monto.
        /// </summary>
        /// <param name="comanda_id"></param>
        /// <returns></returns>
        public static List<PagoCuenta> ObtenerTodos(string comanda_id)
        {
            List<PagoCuenta> lista = new List<PagoCuenta>();
            DataSet ds = PagoCuentaDato.SeleccionarTodos(comanda_id);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                PagoCuenta registro = new PagoCuenta();

                registro.metodoPago = MetodoPagoLN.SeleccionarMetodoPago(fila["metodoPago_id"].ToString());
                registro.monto = Convert.ToInt32(fila["monto"]);

                lista.Add(registro);
            }
            return lista;
        }

        /// <summary>
        /// Crea un nuevo registro a nivel de base de datos el cual,
        /// contendrá el metodo de pago y su, respectivo, monto.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagoCuenta"></param>
        public static void Nuevo(string id, PagoCuenta pagoCuenta)
        {

                PagoCuentaDato.Insertar(id, pagoCuenta);

        }
    }
}
