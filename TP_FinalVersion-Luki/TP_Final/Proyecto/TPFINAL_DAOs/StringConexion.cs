using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public static class StringConexion
    {
        public static string StringBD
        {
            get
            {
                return @"Data Source=FEDECARP-PC\SQLSERVER;Initial Catalog=ProyectoWeb;Integrated Security=True";
            }
            set
            {
            }
        }
        public static string StringLucasBD
        {
            get
            {
                return @"Data Source=JOSÉ-PC\SQLEXPRESS;Initial Catalog=ProyectoWeb;Integrated Security=True";
                }
            set { }
        }
    }
}
