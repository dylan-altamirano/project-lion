using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class usuario
    {
        public string usuario_id { set; get; }
        public string nombreUsuario { set; get;}

        public string nombreCompleto { set; get; }
        public rol rolUsuario { set; get; }
        public string clave { set; get; }
        public bool activo { set; get; }


        public usuario()
        {

        }

        public usuario(string usuario_idp, string nombre, string nombreCompletop, rol rolp, string clavep, bool activop)
        {
            this.usuario_id = usuario_idp;
            this.nombreUsuario = nombre;
            this.nombreCompleto = nombreCompletop;
            this.rolUsuario = rolp;
            this.clave = clavep;
            this.activo = activop;
        }
    }
}
