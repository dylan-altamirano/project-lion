using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstadoCuenta
    {
        public string estadoCuenta_id { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }

        public EstadoCuenta()
        {
            this.estadoCuenta_id = "CXP";
            this.descripcion = "Cuenta por Pagar";
            this.activo = true;
        }

        public EstadoCuenta(string estadoCuenta_id, string descripcion, bool activo)
        {
            this.estadoCuenta_id = estadoCuenta_id;
            this.descripcion = descripcion;
            this.activo = activo;
        }
    }
}
