using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Data;
using PharmacyValrverd.Models;
using PharmacyValrverd.Models.TableViewModels;
using PharmacyValrverd.Models.ViewModels;
using System.Collections.Generic;

namespace PharmacyValrverd.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Conexion con;

        public FacturaController(IConfiguration config)
        {
            _config = config;
            con = new Conexion(_config);
        }
        public ActionResult Index()
        {

            return View();
        }


        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel model)
        {

            FacturaTableViewModel factura = new FacturaTableViewModel
            {
                numFactura = model.NumFactura,
                idPaciente = model.IdPaciente,
                idMedico = model.IdMedico,
                tipoFactura = model.TipoFactura,
                totalFactura = model.TotalFactura,
                impuesto = model.Impuesto,
                totaldeduccion = model.Deduccion,
                porcentaje = model.Porcentaje,
                obsGeneral = model.ObsGeneral,
                obsEspecifico = model.ObsEspecifico

            };

            DetalleTableViewModel detalle = new DetalleTableViewModel
            {
                idPerfilExamen = model.IdPerfilExamen,
                //cantidad = 
            };

            //string registrado = con.RegistrarPerfiles(perfil);

            //if (registrado == "1")
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
                return View();
            //}
        }

        //// GET: FacturaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: FacturaController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: FacturaController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: FacturaController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: FacturaController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: FacturaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: FacturaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
