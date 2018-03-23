using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Entidad que se encarga de abstraer un objeto de tipo
    /// "Categoria" para clasificar los productos.
    /// </summary>
    public class Categoria
    {
        public string categoria_id { get; set; }

        public string nombreCategoria { get; set; }
        public bool activo { get; set; }

        public Categoria()
        {
            this.categoria_id = "";
            this.nombreCategoria = "";
            this.activo = false;
        }

        public Categoria(string categoria_id, string nombreCategoria, bool activo)
        {
            this.categoria_id = categoria_id;
            this.nombreCategoria = nombreCategoria;
            this.activo = activo;
        }
    }
}
