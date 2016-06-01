using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public class DAO_Usuario
    {
        public static Usuario Obtener(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT U.[idUsuario], U.[nombreUsuario], U.[contraseña] FROM [ProyectoWeb].[dbo].Usuario U WHERE U.nombreUsuario = @nombreUsuario AND U.contraseña = @contraseña";
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = int.Parse(dataReader["idUsuario"].ToString()),
                        Nombre = dataReader["nombreUsuario"].ToString(),
                        Contraseña = dataReader["contraseña"].ToString(),
                    };
                }
                dataReader.Close();
                conexion.Close();
                return usuario;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<Rol> ObtenerRoles(int idUsuario)
        {
            List<Rol> roles = new List<Rol>();
            Rol rol = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT R.[idRol],R.[nombre],R.[descripcion] FROM [ProyectoWeb].[dbo].Rol R JOIN [ProyectoWeb].[dbo].UsuarioXRol UR ON R.idRol = UR.idRol WHERE UR.idUsuario = @idUsuario";
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    rol = new Rol()
                    {
                        IdRol = int.Parse(dataReader["idRol"].ToString()),
                        Nombre = dataReader["nombre"].ToString(),
                        Descripcion = dataReader["descripcion"].ToString()
                    };
                    roles.Add(rol);
                }
                dataReader.Close();
                conexion.Close();
                return roles;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
