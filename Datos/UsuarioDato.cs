﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class UsuarioDato
    {
        public static SqlDataReader SeleccionarUsuario(string nombre)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_obtener_usuario");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombreUsuario", nombre);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        /// <summary>
        /// Retorna un usuario si las credenciales coinciden con
        /// los datos guardados en la base de datos.
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader AutenticarUsuario(usuario Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_autenticar_usuario");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Usuario", Usuario.nombreUsuario);
            comando.Parameters.AddWithValue("@passwordp", Usuario.clave);

            SqlDataReader reader = db.ExecuteReader(comando);
            return reader;
        }

        //Inserta un nuevo alquiler
        public static void Insertar(usuario Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_crear_usuario");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario_id", Usuario.usuario_id);
            comando.Parameters.AddWithValue("@nombre", Usuario.nombreUsuario);
            comando.Parameters.AddWithValue("@nombreCompleto", Usuario.nombreCompleto);
            comando.Parameters.AddWithValue("@rol", Usuario.rolUsuario);
            comando.Parameters.AddWithValue("@clave", Usuario.clave);
            comando.Parameters.AddWithValue("@activo", Usuario.activo);
           

            db.ExecuteNonQuery(comando);
        }
        /*Sentencia del procedimiento almacenado
         */
        public static void Modificar(usuario Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("sp_modificar_usuario");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario_id", Usuario.usuario_id);
            comando.Parameters.AddWithValue("@nombre", Usuario.nombreUsuario);
            comando.Parameters.AddWithValue("@nombreCompleto", Usuario.nombreCompleto);
            comando.Parameters.AddWithValue("@rol", Usuario.rolUsuario);
            comando.Parameters.AddWithValue("@clave", Usuario.clave);
            comando.Parameters.AddWithValue("@activo", Usuario.activo);

            db.ExecuteNonQuery(comando);
        }
    }
}
