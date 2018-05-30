using ProjetParkingTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetParkingTest2.Controllers
{
    public class EvenementController : Controller
    {
        private List<EvenementViewModel> liste = null;

        public EvenementController()
        {
            //liste = RepositoryData.ListeVM;
        }

        // GET: Evenement
        public ActionResult Index()
        {
            return View(liste);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            EvenementViewModel rVM = liste.FirstOrDefault(r => r.Id == id);
            return View(rVM);
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(Guid? id)
        {

            return View();
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(EvenementViewModel rVM)
        {
           
                return View();
            
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}