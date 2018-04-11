using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;
using System.Text;

namespace View
{
    public partial class menu_productos : System.Web.UI.Page
    {
        public StringBuilder sb = new StringBuilder();
        private static Comanda comanda = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarCategorias();
                cargarProductosSegunCategoria("Bebidas");

                establecerComponenteSoloLectura(txtProductoID);

                comanda = (Comanda)Session["comanda_actual"];
            }
        }

        private void cargarCategorias()
        {

            List<Categoria> arrayEstados = new List<Categoria>();

            arrayEstados = CategoriaLN.ObtenerTodos();

            cboCategorias.DataSource = arrayEstados;
            cboCategorias.DataTextField = "nombreCategoria";
            cboCategorias.DataValueField = "categoria_id";
            cboCategorias.DataBind();

        }

        private void cargarProductosSegunCategoria(string categoria)
        {
            List<Producto> arrayProductos = new List<Producto>();

            //Filtra los productos por categoria y trae los primeros 10 productos en la base de datos 
            arrayProductos = ProductoLN.SeleccionarProductosFiltrado(categoria, 0, 10, 2);

            //arrayProductos = ProductoLN.ObtenerTodos(0, 10);

            if (arrayProductos != null)
            {
                foreach (Producto item in arrayProductos)
                {
                    sb.Append("<div class='col-lg-3' style='margin:1%;'>" +
                        "<div class='card' style='margin:2%;'>" +

                            "<div class='card-header'>" +
                            "<h4>Producto ID: <strong>" + item.producto_id + "</strong> </h4>" +
                            "</div>" +
                            "<div class='card-body'>" +
                            "<h5 class='card-title'>" + item.nombreProducto + "</h5>" +
                                "<p class='card-text'>Precio: " + item.precio + ".00 <span class=\"input - group - text\">₡</span></p>");

                    sb.Append("<button id='" + item.producto_id + "' type='button' class='btn btn-info' data-toggle='modal' data-target='#ordenarProducto' onclick='getProductoId(" + item.producto_id + ")'>Seleccionar</button>");

                    sb.Append("</div>" +
                         "</div>" +
                         "</div>");
                }
            }
        }

        protected void cmdBuscarProductos_Click(object sender, EventArgs e)
        {
            cargarProductosPorCategoria(cboCategorias.SelectedItem.Text);
        }

        protected void cmdAfirmacion_Click(object sender, EventArgs e)
        {
            if (!this.txtProductoID.Text.Equals("") || !this.txtCantidad.Text.Equals(""))
            {
                agregarProductosAComanda(txtProductoID.Text, txaNotas.Text, Convert.ToInt32(txtCantidad.Text));
            }
        }

        /// <summary>
        /// Establece la propiedad de un Textbox a solo lectura.
        /// </summary>
        /// <param name="txt"></param>
        private void establecerComponenteSoloLectura(TextBox txt)
        {
            txt.Attributes.Add("readonly", "readonly");
        }

        /// <summary>
        /// Agrega los pedidos de productos a la comanda. 
        /// </summary>
        /// <param name="producto_id"></param>
        /// <param name="notas"></param>
        /// <param name="cant"></param>
        private void agregarProductosAComanda(string producto_id, string notas, int cant)
        {
            Producto producto = new Producto();

            producto = ProductoLN.SeleccionarProducto(producto_id);

            if (producto != null)
            {
                comanda.agregarPedido(producto, cant, notas);

                foreach (ComandaDetalle detalle in comanda.obtenerDetalle())
                {
                    try
                    {

                        //Solo agrega nuevos productos, para los existentes, no realiza ninguna acción.
                        ComandaDetalleLN.Nuevo(comanda.comanda_id, detalle);

                        //Refrescar los productos en pantalla
                        cargarProductosPorCategoria(cboCategorias.SelectedItem.Text);

                        
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Ha ocurrido un error al guardar el pedido " + comanda.comanda_id + "-" + detalle.producto.producto_id + "\n" +
                            "Código de error: " + ex.Message;
                        lblErrorMessage.CssClass = "alert alert-danger";
                    }
                }
            }



        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            Session["comanda_actual"] = comanda;

            Response.Redirect("administrar-comanda.aspx");
        }

        private void cargarProductosPorCategoria(string criterio)
        {
            sb = new StringBuilder();

            cargarProductosSegunCategoria(criterio);
        }
    }
}