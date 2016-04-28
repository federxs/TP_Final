using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Cliente {
        private int idCliente;
        private string? apellido;
        public string? Apellido {
            get {
                return apellido;
            }
            set {
                if (value.HasValue && (value.Value.Length == 0))
                    throw new ApplicationException(@"El apellido no puede estar vacío");
                apellido = value;
            }
        }
        private string? nombre;
        public string? Nombre {
            get {
                return nombre;
            }
            set {
                if (value.HasValue && (value.Value.Length == 0))
                    throw new ApplicationException(@"El nombre no puede estar vacío");
                nombre = value;
            }
        }
        private string? razonSocial;
        public string? RazonSocial {
            get {
                return razonSocial;
            }
            set {
                if (value.HasValue && (value.Value.Length == 0))
                    throw new ApplicationException(@"La razon social no puede estar vacía");
                razonSocial = value;
            }
        }
        private int telefono;
        public int Telefono {
            get {
                return telefono;
            }
            set {
                if (value.CompareTo(0) == 0)
                    throw new ApplicationException(@"El telefono no puede estar vacío");
                telefono = value;
            }
        }
        private string email;
        private int cuit;
        private string sexo;
        private string direccion;
        private string localidad;
        private int numeroDoc;
        private string tipoDoc;
        private DateTime fechaAlta;
        private float saldo;
        private Boolean borrado;
    }
}
