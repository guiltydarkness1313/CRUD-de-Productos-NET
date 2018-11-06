using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Productos_Semana11_NET.Models
{
    public class Proveedor
    {
        public int id { get; set; }
        public string nombreCompañia { get; set; }
        public string nombreContacto { get; set; }
        public string cargoContacto { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string region { get; set; }
        public string codigoPostal { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        public string paginaPrincipal { get; set; }
        public virtual ICollection<Producto> productos { get; set; }

        public Proveedor()
        {
        }

        public Proveedor(int id, string nombreCompañia, string nombreContacto, string cargoContacto, string direccion, string ciudad, string region, string codigoPostal, string pais, string telefono, string fax, string paginaPrincipal)
        {
            this.id = id;
            this.nombreCompañia = nombreCompañia;
            this.nombreContacto = nombreContacto;
            this.cargoContacto = cargoContacto;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.region = region;
            this.codigoPostal = codigoPostal;
            this.pais = pais;
            this.telefono = telefono;
            this.fax = fax;
            this.paginaPrincipal = paginaPrincipal;
        }
    }
}