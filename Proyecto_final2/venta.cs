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
    internal class venta
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioTotalVenta { get; set; }
        public List<venta> Ventas { get; set; }

        public venta()

        {
            Ventas = new List<venta>();
        }
        public List<venta> ListarVentas()
        {

            string connectionString = @"Server=WCX-DEV-0059;Database=CoderHouse;Trusted_Connection=True;";
            var query = "Select Id,Descripcion,Cantidad,PrecioVenta,PrecioCompra,PrecioTotalVenta FROM Venta";
            var listaVentas = new List<venta>();
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

                                var Venta = new venta();

                                Venta.Id = dr.GetInt64(dr.GetOrdinal("Id"));
                                Venta.Descripcion = dr.GetString("Descripcion");
                                Venta.Cantidad = dr.GetInt32(dr.GetOrdinal("Cantidad"));
                                decimal pv = dr.GetDecimal(dr.GetOrdinal("PrecioVenta"));
                                Venta.PrecioVenta = Convert.ToDouble(pv);
                                decimal pcompra = dr.GetDecimal(dr.GetOrdinal("PrecioCompra"));
                                Venta.PrecioCompra = Convert.ToDouble(pcompra);
                                decimal pventa = dr.GetDecimal(dr.GetOrdinal("PrecioTotalVenta"));
                                Venta.PrecioTotalVenta = Convert.ToDouble(pventa);


                                listaVentas.Add(Venta);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay datos disponibles.");
                        }
                    }
                }
            }

            return listaVentas;
        }


    }
}
