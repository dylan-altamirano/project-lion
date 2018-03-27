using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace LoginaNegocio
{
    public class EstadoCuentaLN
    {
        public static List<EstadoCuenta> ObtenerTodos()
        {
            List<EstadoCuenta> lista = new List<EstadoCuenta>();
            DataSet ds = EstadoCuentaDato.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EstadoCuenta registro = new EstadoCuenta();
                registro.estadoCuenta_id = fila["estadoCuenta_id"].ToString();
                registro.descripcion = fila["descripcion"].ToString();

                lista.Add(registro);
            }
            return lista;
        }

        public static  EstadoCuenta SeleccionarEstadoCuenta(string id)
        {
            EstadoCuenta estadoCuenta = null;

            SqlDataReader data = EstadoCuentaDato.SeleccionarEstadoCuenta(id);

            while (data.Read())
            {
                estadoCuenta = new EstadoCuenta();

                estadoCuenta.estadoCuenta_id = data["estadoCuenta_id"].ToString();
                estadoCuenta.descripcion = data["descripcion"].ToString();

            }


            return estadoCuenta;
        }
    }
}
