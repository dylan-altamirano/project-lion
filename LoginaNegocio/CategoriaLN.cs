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
                registro.nombreCategoria = fila["nombre"].ToString();
                registro.activo = Convert.ToBoolean(fila["activo"]);

                lista.Add(registro);
            }
            return lista;
        }
    }
}
