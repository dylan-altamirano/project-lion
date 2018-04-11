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
    public class CategoriaLN
    {
        public static List<Categoria> ObtenerTodos()
        {
            List<Categoria> lista = new List<Categoria>();
            DataSet ds = CategoriaDato.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Categoria registro = new Categoria();
                registro.categoria_id = fila["categoria_id"].ToString();
                registro.nombreCategoria = fila["nombreCategoria"].ToString();
                registro.activo = Convert.ToBoolean(fila["activo"]);

                lista.Add(registro);
            }
            return lista;
        }

        public static Categoria SeleccionarCategoria(string id)
        {
            Categoria categoria = null;

            SqlDataReader data = null;

            try
            {
                data = CategoriaDato.SeleccionarCategoria(id);

                while (data.Read())
                {
                    categoria = new Categoria();

                    categoria.categoria_id = data["categoria_id"].ToString();
                    categoria.nombreCategoria = data["nombreCategoria"].ToString();
                    categoria.activo = Convert.ToBoolean(data["activo"]);
                }

                return categoria;
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
    }
}
