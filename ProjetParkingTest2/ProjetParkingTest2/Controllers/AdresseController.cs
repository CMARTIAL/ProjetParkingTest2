using ProjetParkingTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetParkingTest2.Controllers
{
    public class AdresseController : Controller
    {
        // GET: Adresse
        public ActionResult Index()
        {
            return View(AdresseViewModel.GetAll());
        }

        // GET: Adresse/Details/5
        public ActionResult Details(Guid id)
        {
            return View(AdresseViewModel.GetByGuid(id));
        }

        // GET: Adresse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adresse/Create
        [HttpPost]
        public ActionResult Create(AdresseViewModel Adresse)
        {
            try
            {
                Adresse.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Adresse/Edit/5
        public ActionResult Edit(Guid id)
        {

            return View(AdresseViewModel.GetByGuid(id));
        }

        // POST: Adresse/Edit/5
        [HttpPost]
        public ActionResult Edit(AdresseViewModel rVM)
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

        // GET: Adresse/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(AdresseViewModel.GetByGuid(id));
        }

        // POST: Adresse/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, AdresseViewModel Adresse)
        {
            try
            {
                Adresse.Delete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}