using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public class DAO_FormaPago
    {
        public static List<FormaPago> obtenerTodos()
        {
            List<FormaPago> lista = new List<FormaPago>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DAOs.StringConexion.StringLucasBD;
            cn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = cn;
            com.CommandText = "SELECT TOP 1000 [idFormaPago],[nombre] FROM[ProyectoWeb].[dbo].[FormaPago]";
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                int idFormaPago = int.Parse(dr["idFormaPago"].ToString());
                String nombre = dr["nombre"].ToString();
                FormaPago fp = new FormaPago(idFormaPago, nombre);
                lista.Add(fp);
            }
            dr.Close();
            cn.Close();
            return lista;
        }
}
}
