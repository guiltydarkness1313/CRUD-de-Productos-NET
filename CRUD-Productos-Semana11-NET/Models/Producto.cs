using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_Productos_Semana11_NET.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string cantidadPorUnidad { get; set; }
        public double precio { get; set; }
        public int unidadExistencia { get; set; }
        public int unidadPedido { get; set; }
        public int nivelNuevoPedido { get; set; }
        public int suspendido { get; set; }

        public Producto()
        {
        }

        public Producto(int id, string nombre, int idProveedor, int idCategoria, string cantidadPorUnidad, double precio, int unidadExistencia, int unidadPedido, int nivelNuevoPedido, int suspendido)
        {
            this.id = id;
            this.nombre = nombre;
            IdProveedor = idProveedor;
            IdCategoria = idCategoria;
            this.cantidadPorUnidad = cantidadPorUnidad;
            this.precio = precio;
            this.unidadExistencia = unidadExistencia;
            this.unidadPedido = unidadPedido;
            this.nivelNuevoPedido = nivelNuevoPedido;
            this.suspendido = suspendido;
        }
    }
}