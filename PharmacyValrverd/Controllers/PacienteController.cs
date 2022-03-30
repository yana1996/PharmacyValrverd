﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Data;
using PharmacyValrverd.Models.TableViewModels;
using System.Collections.Generic;

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

            foreach(var prov in listProv)
            {
                lst.Add(new SelectListItem() { Text = prov.NombreProvincia, Value = prov.NumeroProvincia });
            }

            ViewBag.Provincias = lst;

            //var listCant = con.ObtenerProvincias();

            //List<SelectListItem> lst = new List<SelectListItem>();

            //foreach (var prov in listProv)
            //{
            //    lst.Add(new SelectListItem() { Text = prov.NombreProvincia, Value = prov.NumeroProvincia });
            //}

            //ViewBag.Provincias = lst;

            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
