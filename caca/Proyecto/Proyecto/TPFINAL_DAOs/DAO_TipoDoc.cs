using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using DAOs;

namespace DAOs
{
    public static class DAO_TipoDoc
    {
        public static List<TipoDoc> ObtenerTodos()
        {
            List<TipoDoc> listaTipoDoc = new List<TipoDoc>();
            TipoDoc tipoDoc = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 T.[idTipoDoc], T.[nombre] FROM TipoDoc T";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    tipoDoc = new TipoDoc()
                    {
                        IdTipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                    };
                    listaTipoDoc.Add(tipoDoc);
                }
                dataReader.Close();
                conexion.Close();
                return listaTipoDoc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static TipoDoc ObtenerPorID(int idTipoDoc)
        {
            TipoDoc tipoDoc = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT T.[idTipoDoc], T.[nombre] FROM TipoDoc T WHERE T.[idTipoDoc] = @idTipoDoc";
                comando.Parameters.AddWithValue("@idTipoDoc", idTipoDoc);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    tipoDoc = new TipoDoc()
                    {
                        IdTipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                    };
                }
                dataReader.Close();
                conexion.Close();
                return tipoDoc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
