using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboMeses();
                llenarComboAnnos();
            }
        }

        protected void cmdAgregarMetodoPago_Click(object sender, EventArgs e)
        {

        }

        private void llenarComboMeses()
        {
            List<int> arrayMeses = new List<int>();

            for (int i = 1; i <= 12; i++)
            {
                arrayMeses.Add(i);
            }

            cboMeses.DataSource = arrayMeses;
            cboMeses.DataBind();
           
        }

        private void llenarComboAnnos()
        {
            List<int> arrayAnnos = new List<int>();

            for (int i = 1995; i <= 2035; i++)
            {
                arrayAnnos.Add(i);
            }

            cboAnnos.DataSource = arrayAnnos;
            cboAnnos.DataBind();
        }
    }
}