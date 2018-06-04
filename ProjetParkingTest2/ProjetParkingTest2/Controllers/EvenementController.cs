using ProjetParkingTest2.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetParkingTest2.Controllers
{
    public class EvenementController : Controller
    {
   
        // GET: Evenement
        public ActionResult Index()
        {
            return View(EvenementViewModel.GetAll());
        }

        // GET: Evenement/Details/5
        public ActionResult Details(Guid id)
        {
            return View(EvenementViewModel.GetByGuid(id));
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(EvenementViewModel evenement)
        {
            try
            {

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        file.SaveAs(path);
                    }
                }
            



                evenement.Save();
                return RedirectToAction("Index");
            }
            catch
            {
             return View();
            }
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(Guid id)
        {

            return View(EvenementViewModel.GetByGuid(id));
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(EvenementViewModel rVM)
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

        // GET: Evenement/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(EvenementViewModel.GetByGuid(id));
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, EvenementViewModel evenement)
        {
            try
            {
                evenement.Delete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}