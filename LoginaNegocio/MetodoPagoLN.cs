using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data.SqlClient;

namespace LoginaNegocio
{
    public class MetodoPagoLN
    {
        public static List<MetodoPago> ObtenerTodos()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            DataSet ds = MetodoPagoDato.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                MetodoPago registro = new MetodoPago();
                registro.metodoPago_id = fila["metodoPago_id"].ToString();
                registro.description = fila["descripcion"].ToString();
                
                lista.Add(registro);
            }
            return lista;
        }

        public static MetodoPago SeleccionarMetodoPago(string id)
        {
            MetodoPago metodoPago = null;

            SqlDataReader data = MetodoPagoDato.SeleccionarMetodoPago(id);

            while (data.Read())
            {
                metodoPago = new MetodoPago();

                metodoPago.metodoPago_id = data["metodoPago_id"].ToString();
                metodoPago.description = data["descripcion"].ToString();

            }

            return metodoPago;
        }
    }
}
