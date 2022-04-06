using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PharmacyValrverd.Data;
using PharmacyValrverd.Models;
using PharmacyValrverd.Models.TableViewModels;
using System;
using System.Collections.Generic;
using System.Net;

namespace PharmacyValrverd.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Conexion con;

        public PacienteController(IConfiguration config)
        {
            _config = config;
            con = new Conexion(_config);
        }
        // GET: PacienteController
        public ActionResult Index()
        {
            List<PacienteTableViewModel> list = null;

            list = con.ObtenerPacientes();

            return View(list);
        }

        // GET: PacienteController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var listProv = con.ObtenerProvincias();

            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var prov in listProv)
            {
                lst.Add(new SelectListItem() { Text = prov.NombreProvincia, Value = prov.NumeroProvincia });
            }

            ViewBag.Provincias = lst;

            List<SelectListItem> cmbTipo = new List<SelectListItem>();

            cmbTipo.Add(new SelectListItem() { Text = "Nacional", Value = "N" });
            cmbTipo.Add(new SelectListItem() { Text = "Extranjero", Value = "E" });

            ViewBag.Tipo = cmbTipo;

            List<SelectListItem> cmbSexo = new List<SelectListItem>();

            cmbSexo.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
            cmbSexo.Add(new SelectListItem() { Text = "Femenino", Value = "F" });

            ViewBag.Sexo = cmbSexo;

            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        public JsonResult RegistrarPaciente(PacienteViewModel model)
        {

            PacienteTableViewModel paciente = new PacienteTableViewModel
            {
                tipoId = model.TipoId,
                cedula = model.Cedula,
                nombre = model.Nombre,
                primerApellido = model.PrimerApellido,
                segundoApellido = model.SegundoApellido,
                sexo = model.Sexo,
                fechaNacimiento = model.FechaNacimiento,
                correo = model.Correo,
                celular = model.Celular,
                telefono = model.Telefono,
                provincia = model.Provincia,
                canton = model.Canton,
                distrito = model.Distrito,
                direccion = model.Direccion,
                ocupacion = model.Ocupacion,
                lugarTrabajo = model.LugarTrabajo,
                oficina = model.Oficina
            };

            string registrado = con.RegistrarPacientes(paciente);


            return Json(registrado);

        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            EditPacienteViewModel model = new EditPacienteViewModel();

            PacienteTableViewModel paciente = new PacienteTableViewModel();

            paciente = con.ObtenerPacientesId(id);

            model.Cedula = paciente.cedula;
            model.Nombre = paciente.nombre;
            model.PrimerApellido = paciente.primerApellido;
            model.SegundoApellido = paciente.segundoApellido;
            model.Sexo = paciente.sexo;
            model.FechaNacimiento = paciente.fechaNacimiento;
            model.Correo = paciente.correo;
            model.Celular = paciente.celular;
            model.Telefono = paciente.telefono;

            return View(model);
        }


        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id)
        {

            string resultado = con.EliminarPacientes(id);

            return Content(resultado);
        }


        public IActionResult ObtenerCantones(int provincia)
        {
            var listCant = con.ObtenerCantones(provincia);

            var settings = new JsonSerializerSettings()
            {
                Converters =
        {
            new StringEnumConverter()
        }
            };

            return new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.OK,
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(listCant, settings)
            };

        }

        public IActionResult ObtenerDistritos(int canton)
        {
            var listDist = con.ObtenerDistritos(canton);

            var settings = new JsonSerializerSettings()
            {
                Converters =
        {
            new StringEnumConverter()
        }
            };

            return new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.OK,
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(listDist, settings)
            };

        }
    }
}
