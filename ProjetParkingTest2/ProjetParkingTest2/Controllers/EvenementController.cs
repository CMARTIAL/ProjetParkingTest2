using ProjetParkingTest2.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;

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
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        Image img = new Image();
                        var fileI = Request.Files[i];
                        if (fileI != null && fileI.ContentLength > 0)
                        {
                            String timeStamp = GetTimestamp(DateTime.Now);
                            var fileName = timeStamp + "_" + Path.GetFileName(fileI.FileName);
                            var partPath = "/Images/" + fileName;
                            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            
                            if (!System.IO.File.Exists(path))
                            {
                                fileI.SaveAs(path);
                                img.Titre = fileName;
                                img.Path = partPath;
                                evenement.ImageEvenement = img;
                            }
                        }
                    }
                }

                evenement.Save();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            { 
             return View();
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
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