using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mesa
    {
        public string mesa_id { get; set; }
        public bool ocupado { get; set; }
        public bool activo { get; set; }

        public Mesa()
        {
            this.mesa_id = "";
            this.ocupado = false;
            this.activo = false;
        }

        public Mesa(string mesa_id, bool ocupado, bool activo)
        {
            this.mesa_id = mesa_id;
            this.ocupado = ocupado;
            this.activo = activo;
        }

    }
}
