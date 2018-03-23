using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagoCuenta
    {
        public MetodoPago metodoPago { get; set; }
        public double monto { get; set; }

        public PagoCuenta()
        {
            this.metodoPago = new MetodoPago();
            this.monto = 0.0;
        }

        public PagoCuenta(MetodoPago metodoPago, double monto)
        {
            this.metodoPago = metodoPago;
            this.monto = monto;
        }
    }
}
