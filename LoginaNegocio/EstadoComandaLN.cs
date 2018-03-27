using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace LoginaNegocio
{
    public class EstadoComandaLN
    {
        public static List<EstadoComanda> ObtenerTodos()
        {
            List<EstadoComanda> lista = new List<EstadoComanda>();
            DataSet ds = EstadoComandaDato.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EstadoComanda registro = new EstadoComanda();
                registro.estadoComanda_id = fila["estadoComanda_id"].ToString();
                registro.descripcion = fila["descripcion"].ToString();

                lista.Add(registro);
            }
            return lista;
        }

        public static EstadoComanda SeleccionarEstadoComanda(string id)
        {
            EstadoComanda estadoComanda = null;

            SqlDataReader data = EstadoComandaDato.SeleccionarEstadoComanda(id);

            while (data.Read())
            {
                estadoComanda = new EstadoComanda();

                estadoComanda.estadoComanda_id = data["estadoComanda_id"].ToString();
                estadoComanda.descripcion = data["descripcion"].ToString();

            }


            return estadoComanda;
        }
    }
}
