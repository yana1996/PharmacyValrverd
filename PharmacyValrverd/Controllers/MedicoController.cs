using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Data;
using PharmacyValrverd.Models.TableViewModels;
using PharmacyValrverd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Conexion con;

        public MedicoController(IConfiguration config)
        {
            _config = config;
            con = new Conexion(_config);
        }
        // GET: MedicoController
        public ActionResult Index()
        {
            List<MedicoTableViewModel> list = null;

            list = con.ObtenerMedicos();

            return View(list);
        }

        // GET: PacienteController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicoController/Create
        [HttpPost]
        public ActionResult RegistrarMedico(MedicoViewModel model)
        {

            MedicoTableViewModel medico = new MedicoTableViewModel
            {
                cedula = model.Cedula,
                numero = model.Numero,
                nombre = model.Nombre,
                primerApellido = model.PrimerApellido,
                segundoApellido = model.SegundoApellido,
                sexo = model.Sexo,
                correo = model.Correo,
                celular = model.Celular,
                telefono = model.Telefono,
                oficina = model.Oficina
            };

            string registrado = con.RegistrarMedicos(medico);

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

            EditMedicoViewModel model = new EditMedicoViewModel();

            EditMedicoViewModel medico = con.ObtenerMedicosId(id);

            model.Id = medico.Id;
            model.Cedula = medico.Cedula;
            model.Numero = medico.Numero;
            model.Nombre = medico.Nombre;
            model.PrimerApellido = medico.PrimerApellido;
            model.SegundoApellido = medico.SegundoApellido;
            model.Sexo = medico.Sexo;
            model.Correo = medico.Correo;
            model.Celular = medico.Celular;
            model.Telefono = medico.Telefono;
            model.Oficina = medico.Oficina;

            return View(model);
        }

        // POST: PacienteController/Edit
        [HttpPost]
        public ActionResult Edit(EditMedicoViewModel model)
        {

            if (!ModelState.IsValid)
            {

                return View(model);
            }

            EditMedicoViewModel medico = new EditMedicoViewModel
            {
                Id = model.Id,
                Cedula = model.Cedula,
                Numero = model.Numero,
                Nombre = model.Nombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Sexo = model.Sexo,
                Correo = model.Correo,
                Celular = model.Celular,
                Telefono = model.Telefono,               
                Oficina = model.Oficina
            };

            string modificado = con.ModificarMedicos(medico);

            if (modificado == "1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: MedicoController/Delete/5
        public ActionResult Delete(int id)
        {
            string resultado = con.EliminarMedicos(id);

            return Content(resultado);
        }

    }
}
