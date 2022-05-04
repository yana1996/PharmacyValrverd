using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Models;
using PharmacyValrverd.Models.TableViewModels;
using PharmacyValrverd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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

        /*LISTAS*/

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

        public List<MedicoTableViewModel> ObtenerMedicos()
        {
            List<MedicoTableViewModel> listaMedicos = new List<MedicoTableViewModel>();

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerMedicos", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listaMedicos.Add(ArmarObjMedico(reader));
                        }
                    }
                    reader.Close();
                }
            }

            return listaMedicos;
        }

        public List<PerfilExamenTableViewModel> ObtenerPerfiles()
        {
            List<PerfilExamenTableViewModel> listaMedicos = new List<PerfilExamenTableViewModel>();

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerPerfiles", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listaMedicos.Add(ArmarObjPerfil(reader));
                        }
                    }
                    reader.Close();
                }
            }

            return listaMedicos;
        }

        public string ObtenerConsecutivoFactura()
        {
            string numero = ""; 

            using (SqlConnection sql = new SqlConnection(conexion))
            {

                using (SqlCommand cmd = new SqlCommand("ObtenerConsecutivoFactura", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            numero = (reader.GetInt32(0) + 1).ToString();
                        }
                    }
                    else
                    {
                        numero = "1";
                    }
                    reader.Close();
                }
            }

            return numero;
        }

        /*LISTAS POR ID*/

        public EditPacienteViewModel ObtenerPacientesId(int id)
        {
            EditPacienteViewModel paciente = new EditPacienteViewModel();

            using (SqlConnection sql = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerPacientesId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            paciente = ArmarObjPacienteEdit(reader);
                        }
                    }
                    reader.Close();
                }
            }

            return paciente;
        }

        public EditMedicoViewModel ObtenerMedicosId(int id)
        {
            EditMedicoViewModel medico = new EditMedicoViewModel();

            using (SqlConnection sql = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerMedicosId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            medico = ArmarObjMedicoEdit(reader);
                        }
                    }
                    reader.Close();
                }
            }

            return medico;
        }

        public EditPerfilExamenViewModel ObtenerPerfilId(int id)
        {
            EditPerfilExamenViewModel perfil = new EditPerfilExamenViewModel();

            using (SqlConnection sql = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerPerfilId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    sql.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            perfil = ArmarObjPerfilEdit(reader);
                        }
                    }
                    reader.Close();
                }
            }

            return perfil;
        }

        /*LISTAS POR CEDULA / NOMBRE*/

        public PacienteTableViewModel ObtenerPacientesCedula(string descripcion)
        {
            PacienteTableViewModel paciente = new PacienteTableViewModel();

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerPacientesCedula", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                paciente = ArmarObjPaciente(reader);
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                
            }
            
            return paciente;
        }

        public PacienteTableViewModel ObtenerPacientesNombre(string nombre)
        {
            PacienteTableViewModel paciente = new PacienteTableViewModel();

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerPacientesNombre", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descripcion", nombre));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                paciente = ArmarObjPaciente(reader);
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return paciente;
        }

        /*ARMAR OBJETOS*/

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
            paciente.celular = reader["celular"].ToString();
            paciente.telefono = reader["telefono"].ToString();
            paciente.oficina = reader["telOficina"].ToString();
            paciente.ocupacion = reader["ocupacion"].ToString();
            paciente.lugarTrabajo = reader["lugarTrabajo"].ToString();
            paciente.nomProvincia = reader["provincia"].ToString();
            paciente.nomCanton = reader["canton"].ToString();
            paciente.nomDistrito = reader["distrito"].ToString();
            paciente.direccion = reader["direccion"].ToString();

            return paciente;
        }

        private MedicoTableViewModel ArmarObjMedico(SqlDataReader reader)
        {
            MedicoTableViewModel medicos = new MedicoTableViewModel();
            medicos.id = (int)reader["id"];
            medicos.cedula = reader["cedMedico"].ToString();
            medicos.numero = reader["numMedico"].ToString();
            medicos.nombre = reader["nombre"].ToString();
            medicos.primerApellido = reader["primerApellido"].ToString();
            medicos.segundoApellido = reader["segundoApellido"].ToString();
            medicos.sexo = reader["sexo"].ToString();
            medicos.correo = reader["correo"].ToString();
            medicos.celular = reader["celular"].ToString();
            medicos.telefono = reader["telefono"].ToString();
            medicos.oficina = reader["telOficina"].ToString();

            return medicos;
        }

        private PerfilExamenTableViewModel ArmarObjPerfil(SqlDataReader reader)
        {
            PerfilExamenTableViewModel perfiles = new PerfilExamenTableViewModel();
            perfiles.id = (int)reader["id"];
            perfiles.numero = reader["numero"].ToString();
            perfiles.tipo = reader["tipo"].ToString();
            perfiles.descripcion = reader["descripcion"].ToString();
            perfiles.porcentaje = (decimal)reader["precio"];

            return perfiles;
        }

        /*ARMAR OBJETOS EDIT*/

        private EditPacienteViewModel ArmarObjPacienteEdit(SqlDataReader reader)
        {
            EditPacienteViewModel paciente = new EditPacienteViewModel();
            paciente.Id = (int)reader["id"];
            paciente.TipoId = reader["tipoId"].ToString();
            paciente.Cedula = reader["cedula"].ToString();
            paciente.Nombre = reader["nombre"].ToString();
            paciente.PrimerApellido = reader["primerApellido"].ToString();
            paciente.SegundoApellido = reader["segundoApellido"].ToString();
            paciente.Sexo = reader["sexo"].ToString();
            paciente.FechaNacimiento = (DateTime)reader["fechaNacimiento"];
            paciente.Correo = reader["correo"].ToString();
            paciente.Celular = reader["celular"].ToString();
            paciente.Telefono = reader["telefono"].ToString();
            paciente.Oficina = reader["telOficina"].ToString();
            paciente.Ocupacion = reader["ocupacion"].ToString();
            paciente.LugarTrabajo = reader["lugarTrabajo"].ToString();
            paciente.Provincia = (int)reader["provincia"];
            paciente.Canton = (int)reader["canton"];
            paciente.Distrito = (int)reader["distrito"];
            paciente.Direccion = reader["direccion"].ToString();

            return paciente;
        }

        private EditMedicoViewModel ArmarObjMedicoEdit(SqlDataReader reader)
        {
            EditMedicoViewModel medico = new EditMedicoViewModel();
            medico.Id = (int)reader["id"];
            medico.Cedula = reader["cedMedico"].ToString();
            medico.Numero = reader["numMedico"].ToString();
            medico.Nombre = reader["nombre"].ToString();
            medico.PrimerApellido = reader["primerApellido"].ToString();
            medico.SegundoApellido = reader["segundoApellido"].ToString();
            medico.Sexo = reader["sexo"].ToString();
            medico.Correo = reader["correo"].ToString();
            medico.Celular = reader["celular"].ToString();
            medico.Telefono = reader["telefono"].ToString();
            medico.Oficina = reader["telOficina"].ToString();

            return medico;
        }

        private EditPerfilExamenViewModel ArmarObjPerfilEdit(SqlDataReader reader)
        {
            EditPerfilExamenViewModel perfiles = new EditPerfilExamenViewModel();
            perfiles.Id = (int)reader["id"];
            perfiles.Numero = reader["numero"].ToString();
            perfiles.Tipo = reader["tipo"].ToString();
            perfiles.Descripcion = reader["descripcion"].ToString();
            perfiles.Porcentaje = (decimal)reader["precio"];

            return perfiles;
        }

        /*REGISTRAR*/

        public string RegistrarPacientes(PacienteTableViewModel paciente)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarPacientes", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@tipoId", paciente.tipoId));
                        cmd.Parameters.Add(new SqlParameter("@cedula", paciente.cedula));
                        cmd.Parameters.Add(new SqlParameter("@nombre", paciente.nombre));
                        cmd.Parameters.Add(new SqlParameter("@primerApellido", paciente.primerApellido));
                        cmd.Parameters.Add(new SqlParameter("@segundoApellido", paciente.segundoApellido));
                        cmd.Parameters.Add(new SqlParameter("@sexo", paciente.sexo));
                        cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", paciente.fechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@correo", paciente.correo));
                        cmd.Parameters.Add(new SqlParameter("@celular", paciente.celular));
                        cmd.Parameters.Add(new SqlParameter("@telefono", paciente.telefono));
                        cmd.Parameters.Add(new SqlParameter("@telOficina", paciente.oficina));
                        cmd.Parameters.Add(new SqlParameter("@ocupacion", paciente.ocupacion));
                        cmd.Parameters.Add(new SqlParameter("@lugarTrabajo", paciente.lugarTrabajo));
                        cmd.Parameters.Add(new SqlParameter("@provincia", paciente.provincia));
                        cmd.Parameters.Add(new SqlParameter("@canton", paciente.canton));
                        cmd.Parameters.Add(new SqlParameter("@distrito", paciente.distrito));
                        cmd.Parameters.Add(new SqlParameter("@direccion", paciente.direccion));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string RegistrarMedicos(MedicoTableViewModel medico)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarMedicos", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cedula", medico.cedula));
                        cmd.Parameters.Add(new SqlParameter("@numero", medico.numero));
                        cmd.Parameters.Add(new SqlParameter("@nombre", medico.nombre));
                        cmd.Parameters.Add(new SqlParameter("@primerApellido", medico.primerApellido));
                        cmd.Parameters.Add(new SqlParameter("@segundoApellido", medico.segundoApellido));
                        cmd.Parameters.Add(new SqlParameter("@sexo", medico.sexo));
                        cmd.Parameters.Add(new SqlParameter("@correo", medico.correo));
                        cmd.Parameters.Add(new SqlParameter("@celular", medico.celular));
                        cmd.Parameters.Add(new SqlParameter("@telefono", medico.telefono));
                        cmd.Parameters.Add(new SqlParameter("@telOficina", medico.oficina));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string RegistrarPerfiles(PerfilExamenTableViewModel perfil)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarPerfiles", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@numero", perfil.numero));
                        cmd.Parameters.Add(new SqlParameter("@tipo", perfil.tipo));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", perfil.descripcion));
                        cmd.Parameters.Add(new SqlParameter("@precio", perfil.porcentaje));
                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string RegistrarFactura(FacturaTableViewModel factura)
        {
            string valor;

            var idFactura = 0;

            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            SqlTransaction sqlTan = con.BeginTransaction("GuardarFactura");

            try
            {
                using (SqlCommand cmd = new SqlCommand("RegistrarFacturaEncabezado", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Transaction = sqlTan;
                    cmd.Parameters.Add(new SqlParameter("@numFactura", factura.numFactura));
                    cmd.Parameters.Add(new SqlParameter("@idPaciente", factura.idPaciente));
                    cmd.Parameters.Add(new SqlParameter("@idMedico", factura.idMedico));
                    cmd.Parameters.Add(new SqlParameter("@tipoFactura", factura.tipoFactura));
                    cmd.Parameters.Add(new SqlParameter("@totalFactura", factura.totalFactura));
                    cmd.Parameters.Add(new SqlParameter("@impuesto", factura.impuesto));
                    cmd.Parameters.Add(new SqlParameter("@totalDeduccion", factura.totaldeduccion));
                    cmd.Parameters.Add(new SqlParameter("@porcentaje", factura.porcentaje));
                    cmd.Parameters.Add(new SqlParameter("@obsGeneral", factura.obsGeneral));
                    cmd.Parameters.Add(new SqlParameter("@obsEspecifico", factura.obsEspecifico));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idFactura = reader.GetInt32(0);
                        }
                    }
                }

                foreach (var detalle in factura.detalle)
                {

                    using (SqlCommand cmdC = new SqlCommand("RegistrarFacturaDetalle", con))
                    {
                        cmdC.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdC.Transaction = sqlTan;
                        cmdC.Parameters.Add(new SqlParameter("@idFactura", idFactura));
                        cmdC.Parameters.Add(new SqlParameter("@idPerfilExamen", detalle.idPerfilExamen));
                        cmdC.Parameters.Add(new SqlParameter("@cantidad", detalle.cantidad));
                        cmdC.Parameters.Add(new SqlParameter("@precioUnid", detalle.precioUni));
                        cmdC.Parameters.Add(new SqlParameter("@total", detalle.total));
                        cmdC.Parameters.Add(new SqlParameter("@entrega", detalle.entrega));

                        cmdC.ExecuteNonQuery();
                    }
                }

                valor = "1";
                con.Close();

                return valor;
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                con.Close();
                return valor;
            }
        }

        /*ELIMINAR*/
        public string EliminarPacientes(int id)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarPaciente", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }

        }

        public string EliminarMedicos(int id)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarMedico", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string EliminarPerfil(int id)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarPerfil", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        /*MODIFICAR*/
        public string ModificarPacientes(EditPacienteViewModel paciente)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("ModificarPacientes", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", paciente.Id));
                        cmd.Parameters.Add(new SqlParameter("@tipoId", paciente.TipoId));
                        cmd.Parameters.Add(new SqlParameter("@cedula", paciente.Cedula));
                        cmd.Parameters.Add(new SqlParameter("@nombre", paciente.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@primerApellido", paciente.PrimerApellido));
                        cmd.Parameters.Add(new SqlParameter("@segundoApellido", paciente.SegundoApellido));
                        cmd.Parameters.Add(new SqlParameter("@sexo", paciente.Sexo));
                        cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", paciente.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@correo", paciente.Correo));
                        cmd.Parameters.Add(new SqlParameter("@celular", paciente.Celular));
                        cmd.Parameters.Add(new SqlParameter("@telefono", paciente.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@telOficina", paciente.Oficina));
                        cmd.Parameters.Add(new SqlParameter("@ocupacion", paciente.Ocupacion));
                        cmd.Parameters.Add(new SqlParameter("@lugarTrabajo", paciente.LugarTrabajo));
                        cmd.Parameters.Add(new SqlParameter("@provincia", paciente.Provincia));
                        cmd.Parameters.Add(new SqlParameter("@canton", paciente.Canton));
                        cmd.Parameters.Add(new SqlParameter("@distrito", paciente.Distrito));
                        cmd.Parameters.Add(new SqlParameter("@direccion", paciente.Direccion));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string ModificarMedicos(EditMedicoViewModel medico)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("ModificarMedicos", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", medico.Id));
                        cmd.Parameters.Add(new SqlParameter("@cedula", medico.Cedula));
                        cmd.Parameters.Add(new SqlParameter("@numero", medico.Numero));
                        cmd.Parameters.Add(new SqlParameter("@nombre", medico.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@primerApellido", medico.PrimerApellido));
                        cmd.Parameters.Add(new SqlParameter("@segundoApellido", medico.SegundoApellido));
                        cmd.Parameters.Add(new SqlParameter("@sexo", medico.Sexo));
                        cmd.Parameters.Add(new SqlParameter("@correo", medico.Correo));
                        cmd.Parameters.Add(new SqlParameter("@celular", medico.Celular));
                        cmd.Parameters.Add(new SqlParameter("@telefono", medico.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@telOficina", medico.Oficina));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }

        public string ModificarPerfil(EditPerfilExamenViewModel perfil)
        {
            var valor = "0";

            try
            {
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("ModificarPerfil", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", perfil.Id));
                        cmd.Parameters.Add(new SqlParameter("@numero", perfil.Numero));
                        cmd.Parameters.Add(new SqlParameter("@tipo", perfil.Tipo));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", perfil.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@precio", perfil.Porcentaje));

                        sql.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                valor = reader.GetInt32(0).ToString();
                            }
                        }
                        reader.Close();

                        return valor;
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
                return valor;
            }
        }


    }

}
