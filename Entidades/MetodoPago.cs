using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MetodoPago
    {
        public MetodoPago(string metodoPago_id, string description)
        {
            this.metodoPago_id = metodoPago_id;
            this.description = description;
        }

        public string metodoPago_id { get; set; }
        public string description { get; set; }

        public MetodoPago()
        {
            this.metodoPago_id = "";
            this.description = "";
        }


    }
}
