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
    public class ComandaDetalleLN
    {
        public static List<ComandaDetalle> ObtenerTodos(string comanda_id)
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

        /// <summary>
        /// Verifica que el registro exista en la base de datos para evitar duplicaciones de registros.
        /// </summary>
        /// <param name="idComanda"></param>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public static bool DetalleExiste(string idComanda, string idProducto)
        {
            //ComandaDetalle comanda_detalle = null;

            bool bandera = false;

            SqlDataReader data = null;

            try
            {
                data = ComandaDetalleDato.SeleccionarComandaDetalle(idComanda, idProducto);

                while (data.Read())
                {
                    //comanda_detalle = new ComandaDetalle();

                    //comanda_detalle.producto.producto_id = data["producto_id"].ToString();
                    //comanda_detalle.cantidad = Convert.ToInt32(data["cantidad"]);
                    //comanda_detalle.notas = Convert.ToBoolean(data["activo"]);
                    bandera = true;


                }


                return bandera;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.Close();
            }

            
        }

        public static void Nuevo(string id, ComandaDetalle comandaDetalle)
        {

            if (!DetalleExiste(id,comandaDetalle.producto.producto_id))
            {
                ComandaDetalleDato.Insertar(id, comandaDetalle);
            }

        }

        public static void Modificar(string id, ComandaDetalle comandaDetalle)
        {
            ComandaDetalleDato.Modificar(id, comandaDetalle);
        }

        public static void Eliminar(string id, string producto_id)
        {
            ComandaDetalleDato.Eliminar(id, producto_id);
        }
    }
}
