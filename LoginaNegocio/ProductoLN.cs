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
    public class ProductoLN
    {
        public static List<Producto> ObtenerTodos(int offset_rows, int next_rows)
        {
            List<Producto> lista = new List<Producto>();
            DataSet ds = ProductoDato.SeleccionarTodos(offset_rows, next_rows);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Producto registro = new Producto();

                registro.producto_id = fila["producto_id"].ToString();
                registro.descripcion = fila["descripcion"].ToString();
                registro.nombreProducto = fila["nombreProducto"].ToString();
                registro.precio = Convert.ToDouble(fila["precio"]);
                registro.activo = Convert.ToBoolean(fila["activo"]);

                registro.categoria = CategoriaLN.SeleccionarCategoria(fila["categoria_id"].ToString());

                lista.Add(registro);
            }
            return lista;
        }

        public static List<Producto> SeleccionarProductosFiltrado(string criterio, int offset_rows, int next_rows, int opcion)
        {
            List<Producto> lista = new List<Producto>();

            DataSet ds = ProductoDato.SeleccionarTodosFiltrado(criterio, offset_rows, next_rows, opcion);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Producto registro = new Producto();
                registro.producto_id = fila["producto_id"].ToString();
                registro.descripcion = fila["descripcion"].ToString();
                registro.nombreProducto = fila["nombreProducto"].ToString();
                registro.precio = Convert.ToDouble(fila["precio"]);
                registro.activo = Convert.ToBoolean(fila["activo"]);

                registro.categoria = CategoriaLN.SeleccionarCategoria(fila["categoria_id"].ToString());

                lista.Add(registro);
            }

            return lista;
        }

        public static Producto SeleccionarProducto(string id)
        {
            Producto producto = null;

            SqlDataReader data = null;

            try
            {
                data = ProductoDato.SeleccionarProducto(id);

                while (data.Read())
                {
                    producto = new Producto();

                    producto.producto_id = data["producto_id"].ToString();
                    producto.nombreProducto = data["nombreProducto"].ToString();
                    producto.descripcion = data["descripcion"].ToString();
                    producto.precio = Convert.ToDouble(data["precio"]);
                    producto.activo = Convert.ToBoolean(data["activo"]);

                    producto.categoria = CategoriaLN.SeleccionarCategoria(data["categoria_id"].ToString());
                }

                return producto;
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

        public static void Nuevo(Producto producto)
        {
                ProductoDato.Insertar(producto);
            
        }

        public static void Modificar(Producto producto)
        {
            ProductoDato.Modificar(producto);
        }
    }
}
