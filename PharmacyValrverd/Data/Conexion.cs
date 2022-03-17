using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace PharmacyValrverd.Data
{
    public class Conexion
    {

        private string conexion;

        public Conexion(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("defaultConnection");

        }

        public void prueba()
        {

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * From Prueba;", sql);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(1));
                    }
                }
                reader.Close();
            }
        }

    }

    
}
