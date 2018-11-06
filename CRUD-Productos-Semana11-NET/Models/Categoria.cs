using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Productos_Semana11_NET.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] image { get; set; }
        public int productoId { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string nombre, string descripcion, byte[] image, int productoId)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.image = image;
            this.productoId = productoId;
        }
    }
}