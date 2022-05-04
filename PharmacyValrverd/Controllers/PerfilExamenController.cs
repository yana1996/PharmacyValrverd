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
    public class PerfilExamenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Conexion con;

        public PerfilExamenController(IConfiguration config)
        {
            _config = config;
            con = new Conexion(_config);
        }
        // GET: PerfilExamenController
        public ActionResult Index()
        {

            List<PerfilExamenTableViewModel> list = null;

            list = con.ObtenerPerfiles();

            return View(list);
        }

        // GET: PerfilExamenController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilExamenController/RegistrarPerfilExamen
        [HttpPost]
        public ActionResult RegistrarPerfilExamen(PerfilExamenViewModel model)
        {

            PerfilExamenTableViewModel perfil = new PerfilExamenTableViewModel
            {
                numero = model.Numero,
                tipo = model.Tipo,
                descripcion = model.Descripcion,
                porcentaje = model.Porcentaje
            };

            string registrado = con.RegistrarPerfiles(perfil);

            if (registrado == "1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: PerfilExamenController/Edit/5
        public ActionResult Edit(int id)
        {
            EditPerfilExamenViewModel model = new EditPerfilExamenViewModel();

            EditPerfilExamenViewModel perfil = con.ObtenerPerfilId(id);

            model.Id = perfil.Id;
            model.Numero = perfil.Numero;
            model.Tipo = perfil.Tipo;
            model.Descripcion = perfil.Descripcion;
            model.Porcentaje = perfil.Porcentaje;

            return View(model);
        }

        // POST: PerfilExamenController/Edit
        [HttpPost]
        public ActionResult Edit(EditPerfilExamenViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            EditPerfilExamenViewModel perfil = new EditPerfilExamenViewModel
            {
                Id = model.Id,
                Numero = model.Numero,
                Tipo = model.Tipo,
                Descripcion = model.Descripcion,
                Porcentaje = model.Porcentaje
            };

            string modificado = con.ModificarPerfil(perfil);

            if (modificado == "1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: PerfilExamenController/Delete/5
        public ActionResult Delete(int id)
        {
            string resultado = con.EliminarPerfil(id);

            return Content(resultado);
        }
    }
}
