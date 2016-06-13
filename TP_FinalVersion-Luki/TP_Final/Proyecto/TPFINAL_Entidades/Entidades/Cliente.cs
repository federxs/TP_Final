using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {

        public int IdCliente { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public int Cuit { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public Localidad Localidad { get; set; }
        public int NumeroDoc { get; set; }
        public TipoDoc TipoDoc { get; set; }
        public DateTime FechaAlta { get; set; }
        public float Saldo { get; set; }
        public bool Borrado { get; set; }

        public Cliente() { }
        public Cliente(int idCliente, string apellido, string nombre, string razonSocial, int cuit, string sexo, string direccion,
            Localidad localidad, int numeroDoc, TipoDoc tipoDoc, DateTime fechaAlta, float saldo, bool borrado, long telefono, string email)
        {
            IdCliente = idCliente;
            Apellido = apellido;
            Nombre = nombre;
            RazonSocial = razonSocial;
            Cuit = cuit;
            Sexo = sexo;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Localidad = localidad;
            NumeroDoc = numeroDoc;
            TipoDoc = tipoDoc;
            FechaAlta = fechaAlta;
            Saldo = saldo;
            Borrado = borrado;
        }
        //private int idCliente;
        //private string? apellido;
        //private int cuit;
        //private string sexo;
        //private string direccion;
        //private string localidad;
        //private int numeroDoc;
        //private string tipoDoc;
        //private DateTime fechaAlta;
        //private float saldo;
        //private Boolean borrado;

        //{
        //    get
        //    {
        //        return apellido;
        //    }
        //    set
        //    {
        //        if (value.HasValue && (value.Value.Length == 0))
        //            throw new ApplicationException(@"El apellido no puede estar vacío");
        //        apellido = value;
        //    }
        //}
        //private string? nombre;
        //public string? Nombre
        //{
        //    get
        //    {
        //        return nombre;
        //    }
        //    set
        //    {
        //        if (value.HasValue && (value.Value.Length == 0))
        //            throw new ApplicationException(@"El nombre no puede estar vacío");
        //        nombre = value;
        //    }
        //}
        //private string? razonSocial;
        //public string? RazonSocial
        //{
        //    get
        //    {
        //        return razonSocial;
        //    }
        //    set
        //    {
        //        if (value.HasValue && (value.Value.Length == 0))
        //            throw new ApplicationException(@"La razon social no puede estar vacía");
        //        razonSocial = value;
        //    }
        //}
        //private int telefono;
        //public int Telefono
        //{
        //    get
        //    {
        //        return telefono;
        //    }
        //    set
        //    {
        //        if (value.CompareTo(0) == 0)
        //            throw new ApplicationException(@"El telefono no puede estar vacío");
        //        telefono = value;
        //    }
        //}
        //private string email;
        //public string Email
        //{
        //    get
        //    {
        //        return email;
        //    }
        //    set
        //    {
        //        int cont = 0;
        //        foreach (char c in value)
        //        {
        //            if (c == '@')
        //                cont++;
        //        }
        //        if (cont != 1)
        //            throw new ApplicationException(@"El email es incorrecto");
        //    }
        //}
    }
}
