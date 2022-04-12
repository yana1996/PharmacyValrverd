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


            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        public ActionResult RegistrarPaciente(PacienteViewModel model)
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

            if (registrado == "1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: MedicoController/Edit/5
        public ActionResult Edit(int id)
        {

            EditPacienteViewModel model = new EditPacienteViewModel();

            EditPacienteViewModel paciente = con.ObtenerPacientesId(id);

            model.Id = paciente.Id;
            model.TipoId = paciente.TipoId;
            model.Cedula = paciente.Cedula;
            model.Nombre = paciente.Nombre;
            model.PrimerApellido = paciente.PrimerApellido;
            model.SegundoApellido = paciente.SegundoApellido;
            model.Sexo = paciente.Sexo;
            model.FechaNacimiento = paciente.FechaNacimiento;
            model.Correo = paciente.Correo;
            model.Celular = paciente.Celular;
            model.Telefono = paciente.Telefono;
            model.Provincia = paciente.Provincia;
            model.Canton = paciente.Canton;
            model.Distrito = paciente.Distrito;
            model.Direccion = paciente.Direccion;
            model.Ocupacion = paciente.Ocupacion;
            model.LugarTrabajo = paciente.LugarTrabajo;
            model.Oficina = paciente.Oficina;

            var listProv = con.ObtenerProvincias();

            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var prov in listProv)
            {
                lst.Add(new SelectListItem() { Text = prov.NombreProvincia, Value = prov.NumeroProvincia });
            }

            ViewBag.Provincias = lst;

            var listCant = con.ObtenerCantones(model.Provincia);

            List<SelectListItem> lstC = new List<SelectListItem>();

            foreach (var cant in listCant)
            {
                lstC.Add(new SelectListItem() { Text = cant.NombreCanton, Value = cant.CodigoCanton.ToString() });
            }

            ViewBag.Cantones = lstC;

            var listDist = con.ObtenerDistritos(model.Canton);

            List<SelectListItem> lstD = new List<SelectListItem>();

            foreach (var dist in listDist)
            {
                lstD.Add(new SelectListItem() { Text = dist.NombreDistrito, Value = dist.CodigoDistrito.ToString() });
            }

            ViewBag.Distritos = lstD;

            return View(model);
        }

        // POST: PacienteController/Edit
        [HttpPost]
        public ActionResult Edit(EditPacienteViewModel model)    
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            EditPacienteViewModel paciente = new EditPacienteViewModel
            {
                Id = model.Id,
                TipoId = model.TipoId,
                Cedula = model.Cedula,
                Nombre = model.Nombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Sexo = model.Sexo,
                FechaNacimiento = model.FechaNacimiento,
                Correo = model.Correo,
                Celular = model.Celular,
                Telefono = model.Telefono,
                Provincia = Convert.ToInt32(model.Provincia),
                Canton = Convert.ToInt32(model.Canton),
                Distrito = Convert.ToInt32(model.Distrito),
                Direccion = model.Direccion,
                Ocupacion = model.Ocupacion,
                LugarTrabajo = model.LugarTrabajo,
                Oficina = model.Oficina
            };

            string modificado = con.ModificarPacientes(paciente);

            if (modificado == "1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
