using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class ProductoDato
    {
        //Selecciona todos los alquileres de bicicletas
        public static DataSet SeleccionarTodos(int offset_rows, int next_rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_productos");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@offset_rows", offset_rows);
            comando.Parameters.AddWithValue("@next_rows", next_rows);

            DataSet ds = db.ExecuteReader(comando, "producto");
            return ds;
        }

        public static DataSet SeleccionarTodosFiltrado(string criterio, int offset_rows, int next_rows, int opcion)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_productos_filtrado");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@criterio ", criterio);
            comando.Parameters.AddWithValue("@offset_rows", offset_rows);
            comando.Parameters.AddWithValue("@next_rows", next_rows);
            comando.Parameters.AddWithValue("@opcion ", opcion);

            DataSet ds = db.ExecuteReader(comando, "producto");
            return ds;
        }

        public static SqlDataReader SeleccionarProducto(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_producto");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@producto_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        //Inserta un nuevo alquiler
        public static void Insertar(Producto producto)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_producto");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
            comando.Parameters.AddWithValue("@categoria_id", producto.categoria.categoria_id);
            comando.Parameters.AddWithValue("@descripcion", producto.descripcion);
            comando.Parameters.AddWithValue("@activo", producto.activo);
            comando.Parameters.AddWithValue("@precio", producto.precio);

            db.ExecuteNonQuery(comando);
        }
        /*Sentencia del procedimiento almacenado
         */
        public static void Modificar(Producto producto)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_producto");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@producto_id", producto.producto_id);
            comando.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
            comando.Parameters.AddWithValue("@categoria_id", producto.categoria.categoria_id);
            comando.Parameters.AddWithValue("@descripcion", producto.descripcion);
            comando.Parameters.AddWithValue("@activo", producto.activo);
            comando.Parameters.AddWithValue("@precio", producto.precio);

            db.ExecuteNonQuery(comando);
        }
    }
}
