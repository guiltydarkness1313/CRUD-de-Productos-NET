using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CRUD_Productos_Semana11_NET.Models;

namespace CRUD_Productos_Semana11_NET.Repository
{
    public class ProductoRepository
    {
        private SqlConnection connection;
        
        private void connectionDB()
        {
            string cons = ConfigurationManager.ConnectionStrings["tecsup"].ToString();
            connection = new SqlConnection(cons);
        }

        public List<Producto> GetProductos()
        {
            connectionDB();
            List<Producto> productos = new List<Producto>();
            SqlCommand command = new SqlCommand("sp_listarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow data in dataTable.Rows)
            {
                productos.Add(new Producto
                {
                    id = Convert.ToInt32(data["IdProducto"]),
                    nombre = Convert.ToString(data["NombreProducto"]),
                    IdProveedor = Convert.ToInt32(data["IdProveedor"]),
                    IdCategoria = Convert.ToInt32(data["IdCategoria"]),
                    cantidadPorUnidad = Convert.ToString(data["CantidadPorUnidad"]),
                    precio = Convert.ToDouble(data["PrecioUnidad"]),
                    unidadExistencia = Convert.ToInt32(data["UnidadesEnExistencia"]),
                    unidadPedido = Convert.ToInt32(data["UnidadesEnPedido"]),
                    nivelNuevoPedido = Convert.ToInt32(data["NivelNuevoPedido"]),
                    suspendido = Convert.ToInt32(data["Suspendido"])
                });
            }

            return productos;
        }

        public bool AgregarProducto(Producto obj)
        {
            connectionDB();
            SqlCommand command = new SqlCommand("sp_AddNewProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", obj.id);
            command.Parameters.AddWithValue("@nombre", obj.nombre);
            command.Parameters.AddWithValue("@proveedor", obj.IdProveedor);
            command.Parameters.AddWithValue("@categoria", obj.IdCategoria);
            command.Parameters.AddWithValue("@cantidadUnidad", obj.cantidadPorUnidad);
            command.Parameters.AddWithValue("@precioUnidad", obj.precio);
            command.Parameters.AddWithValue("@unidadExistencia", obj.unidadExistencia);
            command.Parameters.AddWithValue("@unidadPedido", obj.unidadPedido);
            command.Parameters.AddWithValue("@nivelNuevoPedido", obj.nivelNuevoPedido);
            command.Parameters.AddWithValue("@suspendido", obj.suspendido);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarProducto(Producto obj)
        {
            connectionDB();
            SqlCommand command = new SqlCommand("updateProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", obj.id);
            command.Parameters.AddWithValue("@nombre", obj.nombre);
            command.Parameters.AddWithValue("@proveedor", obj.IdProveedor);
            command.Parameters.AddWithValue("@categoria", obj.IdCategoria);
            command.Parameters.AddWithValue("@cantidadUnidad", obj.cantidadPorUnidad);
            command.Parameters.AddWithValue("@precioUnidad", obj.precio);
            command.Parameters.AddWithValue("@unidadExistencia", obj.unidadExistencia);
            command.Parameters.AddWithValue("@unidadPedido", obj.unidadPedido);
            command.Parameters.AddWithValue("@nivelNuevoPedido", obj.nivelNuevoPedido);
            command.Parameters.AddWithValue("@suspendido", obj.suspendido);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool BorrarProducto(int id)
        {
            connectionDB();
            SqlCommand com = new SqlCommand("deleteProductoById", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}