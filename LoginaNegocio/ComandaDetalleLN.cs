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
    public class ComandaDetalleLN
    {
        public static List<ComandaDetalle> ObtenerTodos(int comanda_id)
        {
            List<ComandaDetalle> lista = new List<ComandaDetalle>();
            DataSet ds = ComandaDetalleDato.SeleccionarTodos(comanda_id);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                ComandaDetalle registro = new ComandaDetalle();

                registro.producto = ProductoLN.SeleccionarProducto(fila["producto_id"].ToString());
                registro.cantidad = Convert.ToInt32(fila["cantidad"]);
                registro.notas = fila["notas"].ToString();
                
                lista.Add(registro);
            }
            return lista;
        }

        public static void Nuevo(string id, ComandaDetalle comandaDetalle)
        {
            ComandaDetalleDato.Insertar(id, comandaDetalle);

        }

        public static void Modificar(string id, ComandaDetalle comandaDetalle)
        {
            ComandaDetalleDato.Modificar(id, comandaDetalle);
        }
    }
}
