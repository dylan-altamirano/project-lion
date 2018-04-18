﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase principal utilizada como la base de la orden de los clientes. En ella, se asocian
    /// varios elementos que hacen posible el rastrear la orden desde su inicio de vida en el sistema hasta
    /// su posterior finalización. 
    /// </summary>
    public class Comanda
    {
        public string comanda_id { get; set; }
        public EstadoComanda estadoComanda { get; set; }
        public Mesa mesa { get; set; }
        public EstadoCuenta estadoCuenta { get; set; }
        public usuario usuarioComanda { get; set; }
        private List<PagoCuenta> arrayPagoCuenta { get; set; }
        public string nombreCliente { get; set; }
        public DateTime fecha { get; set; }

        private List<ComandaDetalle> arrayDetalleOrden { get; set; }

        private static double balance = 0.0;

        private const double IVA = 0.013;

        public Comanda()
        {
            this.comanda_id = "";
            this.estadoComanda = new EstadoComanda();
            this.mesa = new Mesa();
            this.estadoCuenta = new EstadoCuenta();
            this.usuarioComanda = new usuario();
            this.arrayPagoCuenta = new List<PagoCuenta>();
            this.arrayDetalleOrden = new List<ComandaDetalle>(); 
            this.nombreCliente = "";
            this.fecha = DateTime.Now;
        }

        public Comanda(string comanda_id, EstadoComanda estadoComanda, Mesa mesa, EstadoCuenta estadoCuenta, usuario usuarioComanda, string nombreCliente, DateTime fecha)
        {
            this.comanda_id = comanda_id;
            this.estadoComanda = estadoComanda;
            this.mesa = mesa;
            this.estadoCuenta = estadoCuenta;
            this.usuarioComanda = usuarioComanda;
            this.arrayPagoCuenta = new List<PagoCuenta>();
            this.arrayDetalleOrden = new List<ComandaDetalle>();
            this.nombreCliente = nombreCliente;
            this.fecha = fecha;
        }

        /// <summary>
        /// Agrega un pedido a la orden. También actualiza el balance conforme se hace el pedido.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="notas"></param>
        public void agregarPedido(Producto producto, int cantidad, string notas)
        {

            ComandaDetalle detalle = new ComandaDetalle(producto, cantidad, notas);

            arrayDetalleOrden.Add(detalle);

        }

        /// <summary>
        /// Agrega un metodo de pago preferido del cliente y,
        /// lo asocia con su orden a cancelar.
        /// </summary>
        /// <param name="metodoPago"></param>
        /// <param name="monto"></param>
        private void agregarMetodoPago(MetodoPago metodoPago, double monto)
        {

            PagoCuenta pagoCuenta = new PagoCuenta(metodoPago, monto);

            this.arrayPagoCuenta.Add(pagoCuenta);
        }

        /// <summary>
        /// Obtiene los métodos de pago asociados con la orden.
        /// Además del monto a pagar por cada uno de ellos.
        /// </summary>
        /// <returns></returns>
        public List<PagoCuenta> listarMetodosPago()
        {
            return this.arrayPagoCuenta;
        }

        /// <summary>
        /// Obtiene el precio total de la orden basado
        /// en los productos ordenados de la comanda.
        /// </summary>
        /// <returns></returns>
        public double obtenerTotalOrden()
        {
            double total = 0.0;

            foreach (var comandaDetalle in arrayDetalleOrden)
            {
                total+= (comandaDetalle.producto.precio * comandaDetalle.cantidad);
            }

            return total;
        }

        /// <summary>
        /// Obtiene el total de impuestos que debe ser añadido a la factura.
        /// </summary>
        /// <returns></returns>
        public double obtenerIVA()
        {
            return obtenerTotalOrden()*IVA;
        }

        /// <summary>
        /// Obtiene el total a pagar de la factura, incluido el impuesto.
        /// </summary>
        /// <returns></returns>
        public double obtenerTotal()
        {
            return obtenerTotalOrden() + obtenerIVA();
        }

        /// <summary>
        /// Realiza el pago de la comanda con el método de pago
        /// preferido por el cliente.
        /// </summary>
        /// <param name="metodoPago"></param>
        /// <param name="monto"></param>
        public double realizarPago(MetodoPago metodoPago, double monto)
        {
                if (balance >= monto)
                {
                    agregarMetodoPago(metodoPago, monto);

                    balance = balance - monto;
                }
                else if (balance < monto)
                {
                    agregarMetodoPago(metodoPago, balance);

                    return monto - balance;
                }

            return 0.0;

        }


        /// <summary>
        /// Obtiene el detalle de los pedidos de la comanda.
        /// </summary>
        /// <returns></returns>
        public List<ComandaDetalle> obtenerDetalle()
        {
            return this.arrayDetalleOrden;
        }

        /// <summary>
        /// Obtiene el detalle de los pagos de la comanda
        /// </summary>
        /// <returns></returns>
        public List<PagoCuenta> obtenerDetallePagos()
        {
            return this.arrayPagoCuenta;
        }

        /// <summary>
        /// Método que valida que el numero de tarjeta para VISA-DISCOVER y MASTERCARD.
        /// Utiliza el algoritmo de Luhn para su cometido.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool esTarjetaValida(string number)
        {
            int digits = number.Length;

            int sum = 0;

            bool esSegundo = false;

            for (int i = digits-1; i >=0; i--)
            {
                int d = number[i] - 'a';

                if (esSegundo == true)
                {
                    d = d * 2;
                }

                sum += d / 10;
                sum += d % 10;

                esSegundo = !esSegundo;
            }


            return (sum % 10 == 0);
        }

        /// <summary>
        /// Actualiza el monto del balance del método de pago a realizar.
        /// </summary>
        /// <param name="monto"></param>
        public void actualizarBalance(double monto)
        {
            balance = monto;
        }
    }
}
