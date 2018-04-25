using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace LoginaNegocio
{
    public class ComandaLN
    {

        public static DataTable obtenerVentasPorFecha(DateTime fecha_ini, DateTime fecha_fin, string estado)
        {
            DataTable dt = new DataTable();

            dt = ComandaDato.reporteVentasPorFecha(fecha_ini, fecha_fin, estado);

            return dt;
        }

        public static DataTable obtenerVentasPorMetodoPago(DateTime fecha_ini, DateTime fecha_fin, string metodo)
        {
            DataTable dt = new DataTable();

            dt = ComandaDato.reporteVentasPorMetodoPago(fecha_ini, fecha_fin, metodo);

            return dt;
        }

        public static DataTable obtenerVentasFiltrado(DateTime fecha_ini, DateTime fecha_fin, string criterio, int opcion)
        {
            DataTable dt = new DataTable();

            dt = ComandaDato.reporteVentasFiltrado(fecha_ini, fecha_fin, criterio, opcion);

            return dt;
        }

        public static DataTable obtenerReporteFiltrado(string comandaId)
        {
            DataTable dt = new DataTable();

            dt = ComandaDato.reporteFactura(comandaId);

            return dt;
        }

        public static List<Comanda> ObtenerTodos(string estadoComanda)
        {
            List<Comanda> lista = new List<Comanda>();
            DataSet ds = ComandaDato.SeleccionarTodos(estadoComanda);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Comanda registro = new Comanda();

                registro.comanda_id = fila["comanda_id"].ToString();
                registro.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(fila["estadoComanda_id"].ToString());
                registro.mesa = MesaLN.SeleccionarMesa(fila["mesa_id"].ToString());
                registro.estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta(fila["estadoCuenta_id"].ToString());
                registro.nombreCliente = fila["nombreCliente"].ToString();
                registro.usuarioComanda = UsuarioLN.SeleccionarUsuarioPorId(fila["usuario_id"].ToString());

                lista.Add(registro);
            }
            return lista;
        }

        public static Comanda SeleccionarComanda(string id)
        {
            Comanda comanda = null;

            SqlDataReader data = null;

            try
            {
                data = ComandaDato.SeleccionarComanda(id);

                while (data.Read())
                {
                    comanda = new Comanda();

                    comanda.comanda_id = data["comanda_id"].ToString();
                    comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(data["estadoComanda_id"].ToString());
                    comanda.mesa = MesaLN.SeleccionarMesa(data["mesa_id"].ToString());
                    comanda.estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta(data["estadoCuenta_id"].ToString());
                    comanda.nombreCliente = data["nombreCliente"].ToString();
                    comanda.usuarioComanda = UsuarioLN.SeleccionarUsuarioPorId(data["usuario_id"].ToString());

                }


                return comanda;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                data.Close();
            }

            
        }


        public static Comanda SeleccionarComandaSegunMesaAsignada(string id)
        {
            Comanda comanda = null;

            SqlDataReader data = null;

            try
            {
                data = ComandaDato.SeleccionarComandaSegunMesaAsignada(id);

                while (data.Read())
                {
                    comanda = new Comanda();

                    comanda.comanda_id = data["comanda_id"].ToString();
                    comanda.estadoComanda = EstadoComandaLN.SeleccionarEstadoComanda(data["estadoComanda_id"].ToString());
                    comanda.mesa = MesaLN.SeleccionarMesa(data["mesa_id"].ToString());
                    comanda.estadoCuenta = EstadoCuentaLN.SeleccionarEstadoCuenta(data["estadoCuenta_id"].ToString());
                    comanda.nombreCliente = data["nombreCliente"].ToString();
                    comanda.usuarioComanda = UsuarioLN.SeleccionarUsuarioPorId(data["usuario_id"].ToString());

                }


                return comanda;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.Close();
            }

            
        }

        public static void Nuevo(Comanda comanda)
        {
            ComandaDato.Insertar(comanda);

        }

        public static void Modificar(Comanda comanda)
        {
            ComandaDato.Modificar(comanda);
        }
    }
}
