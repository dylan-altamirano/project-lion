using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Entidad que se encarga de abstraer un objeto de tipo
    /// "Producto" para los ingredientes que forman parte de una 
    /// comida.
    /// </summary>
    public class Producto
    {
        public string producto_id { get; set; }
        public string nombreProducto { get; set; }
        public Categoria categoria { get; set; }
        public string descripcion { get; set; }

        public double precio { get; set; }
        public bool activo { get; set; }

        public Producto()
        {
            this.producto_id = "";
            this.nombreProducto = "";
            this.categoria = new Categoria();
            this.descripcion = "";
            this.precio = 0.0;
            this.activo = false;
        }

        public Producto(string producto_id, string nombreProducto, Categoria categoria, string descripcion, double precio, bool activo)
        {
            this.producto_id = producto_id;
            this.nombreProducto = nombreProducto;
            this.categoria = categoria;
            this.descripcion = descripcion;
            this.precio = precio;
            this.activo = activo;
        }
    }
}
