using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComandaDetalle
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public string notas { get; set; }

        public ComandaDetalle()
        {
            this.producto = new Producto();
            this.cantidad = 0;
            this.notas = "";
        }

        public ComandaDetalle(Producto producto, int cantidad, string notas)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.notas = notas;
        }
    }
}
