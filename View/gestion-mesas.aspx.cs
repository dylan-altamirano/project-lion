using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;
using System.Text;

namespace Vista
{
    public partial class gestion_mesas : System.Web.UI.Page
    {
        private static List<Entidades.Mesa> arrayMesas = new List<Entidades.Mesa>();
        public string html = "";
        public StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarMesas();
            }
        }

        private void cargarMesas()
        {
            arrayMesas = MesaLN.ObtenerTodos();


            if (arrayMesas != null)
            {
                foreach (var item in arrayMesas)
                {

                    sb.Append("<div class='col-lg-3'>" +
                        "<div class='card' style=' width: 18rem; margin-bottom:2%;'>" +
                            "<div class='card-body'>" +
                            "<h5 class='card-title'>Mesa Nº " + item.mesa_id + "</h5>" +
                                "<p class='card-text'>Estado: " + ((item.ocupado) ? "Ocupado" : "Libre") + "</p>");

                    if (item.ocupado)
                    {
                        sb.Append("<a href = '#' class='btn btn-dark disabled'>Asignar</a>");
                    }else
                    {
                        sb.Append("<a href = '#' class='btn btn-dark'>Asignar</a>");
                    }

                    sb.Append("</div>" +
                            "</div>" +
                            "</div>");
                }
            }

        }
    }
}