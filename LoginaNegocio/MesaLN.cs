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
    public class MesaLN
    {
        public static List<Mesa> ObtenerTodos()
        {
            List<Mesa> lista = new List<Mesa>();
            DataSet ds = MesaDato.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Mesa registro = new Mesa();
                registro.mesa_id = fila["mesa_id"].ToString();
                registro.ocupado = Convert.ToBoolean(fila["ocupado"]);
                registro.activo = Convert.ToBoolean(fila["activo"]);

                lista.Add(registro);
            }
            return lista;
        }

        public static Mesa SeleccionarMesa(string id)
        {
            Mesa mesa = null;

            SqlDataReader data = MesaDato.SeleccionarMesa(id);

            while (data.Read())
            {
                mesa = new Mesa();

                mesa.mesa_id = data["mesa_id"].ToString();
                mesa.ocupado = Convert.ToBoolean(data["ocupado"]);
                mesa.activo = Convert.ToBoolean(data["activo"]);

            }


            return mesa;
        }

        public static void Nuevo(Mesa mesa)
        {
            MesaDato.Insertar(mesa);

        }

        public static void Modificar(Mesa mesa)
        {
            MesaDato.Modificar(mesa);
        }
    }
}
