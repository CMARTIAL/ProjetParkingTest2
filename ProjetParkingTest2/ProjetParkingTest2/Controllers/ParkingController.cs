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
        private List<ParkingViewModel> liste = null;

        public ParkingController()
        {
            //liste = RepositoryData.ListeVM;
        }

        // GET: Parking
        public ActionResult Index()
        {
            return View(liste);
        }

        // GET: Parking/Details/5
        public ActionResult Details(Guid id)
        {
            ParkingViewModel rVM = liste.FirstOrDefault(r => r.Id == id);
            return View(rVM);
        }

        // GET: Parking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
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

        // GET: Parking/Edit/5
        public ActionResult Edit(Guid? id)
        {

            return View();
        }

        // POST: Parking/Edit/5
        [HttpPost]
        public ActionResult Edit(ParkingViewModel rVM)
        {
            /*try
            {
                if (rVM.Id == Guid.Empty)
                {
                    //Création
                    rVM.Id = Guid.NewGuid();
                    //RepositoryData.ListeBO.Add(rVM.Metier);
                    //RepositoryData.ListeVM.Add(rVM);
                }
                else
                {
                    //Update
                    ParkingViewModel rExistant = liste.FirstOrDefault(r => r.Id == rVM.Id);
                    rExistant.Titre = rVM.Titre;
                    rExistant.Resume = rVM.Resume;
                    rExistant.NbPages = rVM.NbPages;
                }

                return RedirectToAction("Index");
            }
            catch
            {*/
                return View();
            //}
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parking/Delete/5
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