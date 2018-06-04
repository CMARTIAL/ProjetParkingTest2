using ProjetParkingTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetParkingTest2.Controllers
{
    public class ParkingController : Controller
    {
        // GET: Parking
        public ActionResult Index()
        {
            return View(ParkingViewModel.GetAll());
        }

        // GET: Parking/Details/5
        public ActionResult Details(Guid id)
        {
            return View(ParkingViewModel.GetById(id));
        }

        // GET: Parking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
        [HttpPost]
        public ActionResult Create(ParkingViewModel Parking)
        {
            try
            {
                Parking.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parking/Edit/5
        public ActionResult Edit(Guid id)
        {

            return View(ParkingViewModel.GetById(id));
        }

        // POST: Parking/Edit/5
        [HttpPost]
        public ActionResult Edit(ParkingViewModel rVM)
        {
            try
            {
                rVM.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(ParkingViewModel.GetById(id));
        }

        // POST: Parking/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, ParkingViewModel Parking)
        {
            try
            {
                Parking.Delete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Synchro()
        {

            try
            {
                ParkingViewModel.AddtoBase();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

    }
}