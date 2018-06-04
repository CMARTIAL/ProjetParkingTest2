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
            //ParkingViewModel.AddtoBase();
            return View();
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
            return View();
        }

        // Edit? adresseConvive = sdsdsds & Id = da5f6d63 - 40e9 - 4fdd-9ac8-621edb427ecd
        // GET: Evenement/Edit/5
        public ActionResult Maps(String adresseConvive, Guid Id)
        {
            List<ParkingViewModel> listParking = ParkingViewModel.Get3();
            EvenementViewModel eVM = EvenementViewModel.GetByGuid(Id);
            adresseConvive = adresseConvive.Replace(" ", "+");
            string query = "https://maps.googleapis.com/maps/api/geocode/json?address="+adresseConvive+"&key=AIzaSyCyoqbqJVd_MtZRT_0DmYmznxxJWRfMjQI";

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(query);
                RootObjectGoogle item = JsonConvert.DeserializeObject<RootObjectGoogle>(json);
            }
            

            return View();
        }

    }
}