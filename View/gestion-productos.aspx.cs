using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LoginaNegocio;

namespace View
{
    public partial class gestion_productos : System.Web.UI.Page
    {
        static int offRows = 0;
        static int nextRows = 5;

        static bool banderaIdentificador = false;
        static string idProducto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarCategorias();
                precargarGridView();
                cargarFiltroBusqueda();
                cargarComboActivo();


                usuario user = new usuario();

                user = (usuario)Session["usuarioLogueado"];

                hfRolProducto.Value = user.rolUsuario.ToString();

            }
        }

        private void cargarComboActivo()
        {
            cboActivo.Items.Add("Activo");
            cboActivo.Items.Add("Inactivo");

            cboActivo.DataBind();
        }

        private void cargarCategorias()
        {
            cboCategorias.DataSource = CategoriaLN.ObtenerTodos();
            cboCategorias.DataValueField = "categoria_id";
            cboCategorias.DataTextField = "nombreCategoria";
            cboCategorias.DataBind();
        }

        private void cargarFiltroBusqueda()
        {
            DropDownList1.DataSource = CategoriaLN.ObtenerTodos();
            DropDownList1.DataValueField = "categoria_id";
            DropDownList1.DataTextField = "nombreCategoria";
            DropDownList1.DataBind();
        }

        private void precargarGridView()
        {
            List<Producto> arrayProductos = new List<Producto>();

            arrayProductos = ProductoLN.ObtenerTodos(0, 5);

            grvProductos.DataSource = arrayProductos;
            grvProductos.DataBind();
        }

        private void cargarProductosSergunCriterio(string cri,int off, int next, int op)
        {
            List<Producto> arrayProductos = new List<Producto>();

            //filtra los productos por la categoria del producto, que se obteniene del combo 
            arrayProductos = ProductoLN.SeleccionarProductosFiltrado(cri, off,next,op);

            grvProductos.DataSource = arrayProductos;
            grvProductos.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProductosSergunCriterio(DropDownList1.SelectedItem.Text, 0, 5, 2);
        }

        public void guardarProducto(string id, string nombreProducto, Categoria categoria, string descripcion, double precio, bool activo)
        {
            Producto prod = null;

            //Busca la existencia de un usuario con las mismas caracteristicas
            prod = ProductoLN.SeleccionarProducto(id);
            //Si existe se modificará, de lo contrario, se creará uno nuevo
            if (prod != null)
            {
                prod = new Producto(id, nombreProducto, categoria, descripcion, precio, activo);

                try
                {
                    ProductoLN.Modificar(prod);

                    lblErrorMessage.Text = "El producto ha sido actualizado de manera correcta";
                    lblErrorMessage.CssClass = "alert alert-success";
                    Response.AppendHeader("Refresh", "2;url=gestion-productos.aspx");
                }
                catch (Exception ex)
                {

                    lblErrorMessage.Text = "Ha ocurrido un error al guardar el producto, por favor intentelo de nuevo" +
                        "Código de error: " + ex.Message;
                }
            }
            else
            {
                prod = new Producto(id, nombreProducto, categoria, descripcion, precio, activo);

                try
                {
                    ProductoLN.Nuevo(prod);

                    lblErrorMessage.Text = "El producto ha sido almacenado de manera correcta";
                    lblErrorMessage.CssClass = "alert alert-success";
                    Response.AppendHeader("Refresh", "2;url=gestion-productos.aspx");
                }
                catch (Exception ex)
                {

                    lblErrorMessage.Text = "Ha ocurrido un error al guardar el producto, por favor intentelo de nuevo" +
                        "Código de error: " + ex.Message;
                }
            }


        }

        protected void previousRows_Click(object sender, EventArgs e)
        {
            if (offRows >= 5)
            {
                nextRows = offRows;
                offRows -= 5;
            }
            else
            {

                nextRows = 5;
                offRows = 0;
                
            }

            if (!txtBuscar.Text.Equals(""))
            {

                cargarProductosSergunCriterio(txtBuscar.Text, offRows, nextRows, 1);
            }else
            {
                cargarProductosSergunCriterio(DropDownList1.SelectedItem.Text, offRows, nextRows, 2);
            }
        }

        protected void nextRows_Click(object sender, EventArgs e)
        {
            if (nextRows >= 5)
            {
                offRows = nextRows;
                nextRows += 5;
            }
            else
            {

                nextRows = 5;
                offRows = 0;

            }

            if (!txtBuscar.Text.Equals(""))
            {

                cargarProductosSergunCriterio(txtBuscar.Text, offRows, nextRows, 1);
            }
            else
            {
                cargarProductosSergunCriterio(DropDownList1.SelectedItem.Text, offRows, nextRows, 2);
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            

            if (banderaIdentificador == false)
            {

                Categoria categoria = CategoriaLN.SeleccionarCategoria(cboCategorias.SelectedValue);

                guardarProducto("", txtNombreProducto.Text, categoria, txaDescripcion.Text, Convert.ToDouble(txtPrecio.Text), (cboActivo.SelectedValue.Equals("Activo"))? true:false);

            }else
            {
                Categoria categoria = CategoriaLN.SeleccionarCategoria(cboCategorias.SelectedValue);

                guardarProducto((!idProducto.Equals("")? idProducto:""), txtNombreProducto.Text, categoria, txaDescripcion.Text, Convert.ToDouble(txtPrecio.Text), (cboActivo.SelectedValue.Equals("Activo")) ? true : false);
            }

        }

        protected void grvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iRowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                banderaIdentificador = true;

                GridViewRow fila = grvProductos.Rows[iRowIndex];

                string productoId = fila.Cells[0].Text;

                Producto prod = ProductoLN.SeleccionarProducto(productoId);

                txtIdentificador.Text = prod.producto_id;

                //Asigna el id a la variable de la clase
                idProducto = prod.producto_id;

                txtNombreProducto.Text = prod.nombreProducto;
                txaDescripcion.Text = prod.descripcion;
                cboCategorias.SelectedValue = prod.categoria.categoria_id;
                txtPrecio.Text = prod.precio.ToString();
                cboActivo.SelectedValue = (prod.activo) ? "Activo" : "Inactivo";
            }
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            cargarProductosSergunCriterio(txtBuscar.Text, 0, 5, 1);
        }

        protected void cmdLimpiar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void limpiarControles()
        {
            txtIdentificador.Text = "";
            txtNombreProducto.Text = "";
            txaDescripcion.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "";

            idProducto = "";
            banderaIdentificador = false;
        }
    }
}