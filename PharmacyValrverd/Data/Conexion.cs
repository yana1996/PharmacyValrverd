using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Models;
using PharmacyValrverd.Models.TableViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PharmacyValrverd.Data
{
    public class Conexion
    {

        private readonly string conexion = "";

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

        public List<ProvinciaViewModel> ObtenerProvincias()
        {
            List<ProvinciaViewModel> listaProvincias = new List<ProvinciaViewModel>();

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerProvincias", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProvinciaViewModel prov = new ProvinciaViewModel();
                            prov.CodigoProvincia = reader.GetInt32(0);
                            prov.NumeroProvincia = reader.GetString(1);
                            prov.NombreProvincia = reader.GetString(2);

                            listaProvincias.Add(prov);
                        }
                    }
                    reader.Close();
                }
            }

            return listaProvincias;
        }

		public List<CantonViewModel> ObtenerCantones(int provincia)
		{
			List<CantonViewModel> listaCantones = new List<CantonViewModel>();

			using (SqlConnection sql = new SqlConnection(conexion))
			{

				using (SqlCommand cmd = new SqlCommand("ObtenerCantones", sql))
				{

					cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@provincia", provincia);
					sql.Open();

					SqlDataReader reader = cmd.ExecuteReader();

					if (reader.HasRows)
					{
						while (reader.Read())
						{
                            CantonViewModel cant = new CantonViewModel();
                            cant.CodigoCanton = reader.GetInt32(0);
                            cant.CodigoProvincia = reader.GetInt32(1);
                            cant.NumeroCanton = reader.GetString(2);
                            cant.NombreCanton = reader.GetString(3);

                            listaCantones.Add(cant);
						}
					}
					reader.Close();
				}
			}

			return listaCantones;
		}

        public List<DistritoViewModel> ObtenerDistritos(int canton)
        {
            List<DistritoViewModel> listaDistritos = new List<DistritoViewModel>();

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerDistrito", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@canton", canton);
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DistritoViewModel dist = new DistritoViewModel();
                            dist.CodigoDistrito = reader.GetInt32(0);
                            dist.CodigoCanton = reader.GetInt32(1);
                            dist.NumeroDistrito = reader.GetString(2);
                            dist.NombreDistrito = reader.GetString(3);

                            listaDistritos.Add(dist);
                        }
                    }
                    reader.Close();
                }
            }

            return listaDistritos;
        }

        public List<PacienteTableViewModel> ObtenerPacientes() 
        {
            List<PacienteTableViewModel> listaPacientes = new List<PacienteTableViewModel>(); 

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerPacientes", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listaPacientes.Add(ArmarObjPaciente(reader));
                        }
                    }
                    reader.Close();
                }
            }

            return listaPacientes;
        }

        private PacienteTableViewModel ArmarObjPaciente(SqlDataReader reader)
        {
            PacienteTableViewModel paciente = new PacienteTableViewModel();
            paciente.id = (int)reader["id"];
            paciente.tipoId = reader["tipoId"].ToString();
            paciente.cedula = reader["cedula"].ToString();
            paciente.nombre = reader["nombre"].ToString();
            paciente.primerApellido = reader["primerApellido"].ToString();
            paciente.segundoApellido = reader["segundoApellido"].ToString();
            paciente.sexo = reader["sexo"].ToString();
            paciente.fechaNacimiento = (DateTime)reader["fechaNacimiento"];
            paciente.correo = reader["correo"].ToString();
            paciente.celular = (int)reader["celular"];
            paciente.telefono = (int)reader["telefono"];
            paciente.oficina = (int)reader["telOficina"];
            paciente.ocupacion = reader["correo"].ToString();
            paciente.lugarTrabajo = reader["correo"].ToString();
            paciente.provincia = reader["provincia"].ToString();
            paciente.canton = reader["canton"].ToString();
            paciente.distrito = reader["distrito"].ToString();
            paciente.direccion = reader["direccion"].ToString();
            paciente.observacionGeneral = reader["observacionGeneral"].ToString();
            paciente.observacionEspecifica = reader["observacionEspecifica"].ToString();

            return paciente;
        }

    }


}
