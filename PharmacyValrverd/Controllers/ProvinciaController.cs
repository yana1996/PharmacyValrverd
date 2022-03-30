using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PharmacyValrverd.Data;

namespace PharmacyValrverd.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IConfiguration _config;
        private readonly Conexion con;

        public ProvinciaController (IConfiguration config)
        {
            _config = config;
            con = new Conexion(_config);
        }

        // GET: ProvinciaController
        public ActionResult Index()
        {            

            return View();
        }

        // GET: ProvinciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvinciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinciaController/Create
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

        // GET: ProvinciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvinciaController/Edit/5
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

        // GET: ProvinciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvinciaController/Delete/5
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
