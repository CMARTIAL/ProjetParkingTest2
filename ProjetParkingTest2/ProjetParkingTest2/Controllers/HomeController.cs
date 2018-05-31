using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjetParkingTest2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //recupere les parkings
            using (WebClient wc = new WebClient())
            {
               var json = wc.DownloadString("http://data.citedia.com/r1/parks/");
            }
            
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
    }
}