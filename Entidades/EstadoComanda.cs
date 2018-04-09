using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoComanda
    {
        public string estadoComanda_id { get; set; }
        public string descripcion { get; set; }

        public EstadoComanda()
        {
            this.estadoComanda_id = "RE";
            this.descripcion = "Registrada";
        }

        public EstadoComanda(string estadoComanda_id, string descripcion)
        {
            this.estadoComanda_id = estadoComanda_id;
            this.descripcion = descripcion;
        }
    }
}
