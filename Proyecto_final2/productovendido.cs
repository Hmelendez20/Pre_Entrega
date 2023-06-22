using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


namespace Final_Entrega1
{
    internal class productovendido
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public List<productovendido> ProductosVendidos { get; set; }

        public productovendido()

        {
            ProductosVendidos = new List<productovendido>();
        }
        public List<productovendido> ListarProductosVendidos()
        {

            string connectionString = @"Server=WCX-DEV-0059;Database=CoderHouse;Trusted_Connection=True;";
            var query = "Select Id,Stock,IdProducto,IdVenta FROM ProductoVendido";
            var listaProductosVendidos = new List<productovendido>();
            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                var ProductoVendido = new productovendido();

                                ProductoVendido.Id = dr.GetInt64(dr.GetOrdinal("Id"));
                                ProductoVendido.Stock = dr.GetInt32(dr.GetOrdinal("Stock"));
                                ProductoVendido.IdProducto = dr.GetInt64(dr.GetOrdinal("IdProducto"));
                                ProductoVendido.IdVenta = dr.GetInt64(dr.GetOrdinal("IdVenta"));


                                listaProductosVendidos.Add(ProductoVendido);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay datos disponibles.");
                        }
                    }
                }
            }

            return listaProductosVendidos;
        }


    }
}
