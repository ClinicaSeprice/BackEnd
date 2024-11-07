using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    public class HorarioDisponibleController : Controller
    {
        // GET: HorariosDisponiblesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HorariosDisponiblesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HorariosDisponiblesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorariosDisponiblesController/Create
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

        // GET: HorariosDisponiblesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HorariosDisponiblesController/Edit/5
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

        // GET: HorariosDisponiblesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HorariosDisponiblesController/Delete/5
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
