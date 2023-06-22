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
    internal class usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
        public List<usuario> Usuarios { get; set; }

        public usuario()

        {
            Usuarios = new List<usuario>();
        }
        public List<usuario> ListarUsuarios()
        {

            string connectionString = @"Server=WCX-DEV-0059;Database=CoderHouse;Trusted_Connection=True;";
            var query = "Select Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario";
            var listaUsuarios = new List<usuario>();
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

                                var Usuario = new usuario();

                                Usuario.Id = dr.GetInt64(dr.GetOrdinal("Id"));
                                Usuario.Nombre = dr.GetString("Nombre");
                                Usuario.Apellido = dr.GetString("Apellido");
                                Usuario.NombreUsuario = dr.GetString("NombreUsuario");
                                Usuario.Contraseña = dr.GetString("Contraseña");
                                Usuario.Mail = dr.GetString("Mail");


                                listaUsuarios.Add(Usuario);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay datos disponibles.");
                        }
                    }
                }
            }

            return listaUsuarios;
        }


    }
}
