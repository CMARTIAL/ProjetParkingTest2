using BO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetParkingTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProjetParkingTest2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("SexyView");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult GoogleMaps()
        {
            return View(EvenementViewModel.GetAll().FirstOrDefault());
        }

        // Edit? adresseConvive = sdsdsds & Id = da5f6d63 - 40e9 - 4fdd-9ac8-621edb427ecd
        // GET: Evenement/Edit/5
        public ActionResult Maps(String adresseConvive, Guid Id)
        {
            EvenementParkingViewModel EVMs = EvenementParkingViewModel.Get3ParkingByEvent(Id, adresseConvive);
            return View(EVMs);
        }

        [HttpGet]
        public ActionResult ChangeImage(Guid id)
        {
            //return View(EvenementViewModel.GetByGuid(id));
            return PartialView("ImagePartial", EvenementViewModel.GetByGuid(id));
        }

    }
}