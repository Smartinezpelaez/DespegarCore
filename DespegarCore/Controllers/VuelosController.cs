using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DespegarCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DespegarCore.Controllers
{
    public class VuelosController : Controller
    {
        public ActionResult Index()
        {

            List<Vuelos> Vuelo = new List<Vuelos>();

            var Vuelo1 = Services.VuelosServices.GetAviancaVuelos();          

            var Vuelo2 = Services.VuelosServices.GetLatamVuelos();

            var Vuelo3 = Services.VuelosServices.GetSatenaVuelos();           

            if (Vuelo1 != null)

                Vuelo.AddRange(Vuelo1);

            if (Vuelo2 != null)
              Vuelo.AddRange(Vuelo2);

            if (Vuelo3 != null)
                Vuelo.AddRange(Vuelo3);

            return View(Vuelo);        

        }


        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuartos/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuartos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuartos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuartos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuartos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}