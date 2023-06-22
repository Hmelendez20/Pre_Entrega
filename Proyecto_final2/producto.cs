using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_final2
{
    internal class producto
    {
        public long Id { get; set; }
        public string Descripciones { get; set; }
        public Double Costo { get; set; }
        public Double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long  IdUsuario { get; set; }
        public List<producto> Productos { get; set; }

        public producto()

        {
            Productos = new List<producto>();
        }
        public List<producto> ListarProductos()
        {

            string connectionString = @"Server=WCX-DEV-0003;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "Select Id,Descripciones,Costo,PrecioVenta,Stock,IdUsuario FROM Producto";
            var listaProductos = new List<producto>();
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

                                var Producto = new producto();

                                Producto.Id = dr.GetInt64(dr.GetOrdinal("Id"));
                                Producto.Descripciones = dr.GetString("Descripciones");
                                Producto.Stock = dr.GetInt32(dr.GetOrdinal("Stock"));
                                Producto.IdUsuario = dr.GetInt64(dr.GetOrdinal("IdUsuario"));
                                decimal costoDecimal = dr.GetDecimal(dr.GetOrdinal("Costo"));
                                Producto.Costo = Convert.ToDouble(costoDecimal);
                                decimal precioDecimal = dr.GetDecimal(dr.GetOrdinal("PrecioVenta"));
                                Producto.PrecioVenta = Convert.ToDouble(precioDecimal);



                                listaProductos.Add(Producto);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay datos disponibles.");
                        }
                    }
                }
            }

            return listaProductos;
        }


    }
}

