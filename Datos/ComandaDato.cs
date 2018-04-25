using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class ComandaDato
    {
        /// <summary>
        /// Método que proporciona el data source para el reporte a través de 
        /// un 'DataTable' y que se filtra por un rando de fechas y un estado
        /// </summary>
        /// <param name="fecha_ini"></param>
        /// <param name="fecha_fin"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static DataTable reporteVentasPorFecha(DateTime fecha_ini, DateTime fecha_fin, string estado)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ToString()))
            {


                try
                {
                    SqlCommand comando = new SqlCommand("sp_obtener_ventas", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha_ini", fecha_ini);
                    comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                    comando.Parameters.AddWithValue("@estadoCuenta", estado);



                    SqlDataAdapter sqa = new SqlDataAdapter(comando);

                    sqa.Fill(dt);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    cn.Close();
                }


                return dt;
            }

        }

        /// <summary>
        /// Método que proporciona el data source para el reporte a través de 
        /// un 'DataTable' y que se filtra por un rando de fechas y un metodo de pago preferido
        /// </summary>
        /// <param name="fecha_ini"></param>
        /// <param name="fecha_fin"></param>
        /// <param name="metodo"></param>
        /// <returns></returns>
        public static DataTable reporteVentasPorMetodoPago(DateTime fecha_ini, DateTime fecha_fin, string metodo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ToString()))
            {


                try
                {
                    SqlCommand comando = new SqlCommand("sp_obtener_reporte_metodo_pago", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha_ini", fecha_ini);
                    comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                    comando.Parameters.AddWithValue("@metodoPagoId", metodo);



                    SqlDataAdapter sqa = new SqlDataAdapter(comando);

                    sqa.Fill(dt);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    cn.Close();
                }


                return dt;
            }

        }

        /// <summary>
        /// Presenta un reporte por mesa/producto/usuario filtrado dependiendo
        /// de un criterio de busqueda que se especifica al buscar cierto criterio
        /// </summary>
        /// <param name="fecha_ini"></param>
        /// <param name="fecha_fin"></param>
        /// <param name="metodo"></param>
        /// <returns></returns>
        public static DataTable reporteVentasFiltrado(DateTime fecha_ini, DateTime fecha_fin, string criterio, int opcion)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ToString()))
            {


                try
                {
                    SqlCommand comando = new SqlCommand("sp_obtener_reporte_ventas_filtrado", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@fecha_ini", fecha_ini);
                    comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                    comando.Parameters.AddWithValue("@criterio", criterio);
                    comando.Parameters.AddWithValue("@opcion", opcion);



                    SqlDataAdapter sqa = new SqlDataAdapter(comando);

                    sqa.Fill(dt);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    cn.Close();
                }


                return dt;
            }

        }



        /// <summary>
        /// Método que atrae los registros de la factura que se 
        /// elige a la hora de facturarla
        /// </summary>
        /// <param name="comandaId"></param>
        /// <returns></returns>
        public static DataTable reporteFactura(string comandaId)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ToString()))
            {


                try
                {
                    SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_detalle", cn);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@comanda_id", comandaId);



                    SqlDataAdapter sqa = new SqlDataAdapter(comando);

                    sqa.Fill(dt);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    cn.Close();
                }


                return dt;
            }

        }



        public static DataSet SeleccionarTodos(string estadoComanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_enprogreso");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoComanda", estadoComanda);

            DataSet ds = db.ExecuteReader(comando, "comanda");
            return ds;
        }

        public static SqlDataReader SeleccionarComanda(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        public static SqlDataReader SeleccionarComandaSegunMesaAsignada(string id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_seleccionar_comanda_segun_mesa_actual");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@mesa_id", id);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        public static void Insertar(Comanda comanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@estadoComanda_id", comanda.estadoComanda.estadoComanda_id);
            comando.Parameters.AddWithValue("@mesa_id", comanda.mesa.mesa_id);
            comando.Parameters.AddWithValue("@estadoCuenta_id", comanda.estadoCuenta.estadoCuenta_id);
            comando.Parameters.AddWithValue("@nombreCliente", comanda.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", comanda.fecha);
            comando.Parameters.AddWithValue("@usuario_id", comanda.usuarioComanda.usuario_id);

            db.ExecuteNonQuery(comando);
        }

        public static void Modificar(Comanda comanda)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_comanda");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@comanda_id", comanda.comanda_id);
            comando.Parameters.AddWithValue("@estadoComanda_id", comanda.estadoComanda.estadoComanda_id);
            comando.Parameters.AddWithValue("@mesa_id", comanda.mesa.mesa_id);
            comando.Parameters.AddWithValue("@estadoCuenta_id", comanda.estadoCuenta.estadoCuenta_id);
            comando.Parameters.AddWithValue("@nombreCliente", comanda.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", comanda.fecha);
            comando.Parameters.AddWithValue("@usuario_id", comanda.usuarioComanda.usuario_id);

            db.ExecuteNonQuery(comando);
        }
    }
}
