using BO;
using DAL;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjetParkingTest2.Models
{
    public class ParkingViewModel : ViewModel<Parking>
    {
        public ParkingViewModel()
        {
            this.Metier = new Parking();
        }
        public ParkingViewModel(Parking parking)
        {
            this.Metier = parking;
        }

        [Display(Name = "Nom du Parking")]
        public string Titre {
            get { return Metier.Titre; }
            set { Metier.Titre = value; }
        }
        [Display(Name = "Nombre de places totals")]
        public int NBPlaceTotal {
            get { return Metier.NBPlaceTotal; }
            set { Metier.NBPlaceTotal = value; }
        }
        [Display(Name = "Nombre de places libres")]
        public int NBPlaceLibre {
            get { return Metier.NBPlaceLibre; }
            set { Metier.NBPlaceLibre = value; }
        }
        [Display(Name = "Statut du parling")]
        public string Statut {
            get { return Metier.Statut; }
            set { Metier.Statut = value; }
        }

        [Display(Name = "Latittude ?")]
        public double Coordonee0 {
            get { return Metier.Coordonee0; }
            set { Metier.Coordonee0 = value; }
        }

        internal static List<ParkingViewModel> Get3(Guid id)
        {
            List<ParkingViewModel> listParkings = new List<ParkingViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Parking> parkings = ServiceParking.Get3(id);
                foreach (Parking parking in parkings)
                {
                    listParkings.Add(new ParkingViewModel(parking));
                }
            }
            return listParkings;
        }

        [Display(Name = "Longitude ?")]
        public double Coordonee1
        {
            get { return Metier.Coordonee1; }
            set { Metier.Coordonee1 = value; }
        }



        public static void AddtoBase()
        {

            List<Parking> parkingToAdd = new List<Parking>();
            //recupere les parkings
            using (ParkingContext context = new ParkingContext())
            {
                using (WebClient wc = new WebClient())
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://data.citedia.com/r1/parks/timetable-and-prices");

                    StreamReader reader;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        reader = new StreamReader(response.GetResponseStream());
                        List<string[]> csvfile = new List<string[]>();// = reader.ReadToEnd();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            csvfile.Add(Regex.Matches(line, @"[\""].+?[\""]|[^;]+").Cast<Match>().Select(m => m.Value).ToArray());
                        }
                        reader.Close();                        
                                            
                    var query = from ligne in csvfile
                                select new
                                {
                                    Parking = ligne[0],Horaires = ligne[1],Tarifs = ligne[2],Adresse = ligne[3],Capacite = ligne[4],Seuil_Complet = ligne[5]
                                };

                        int count = 0;
                    foreach (string[] stringtab in csvfile)
                    {
                            if (count == 0)
                            {

                            }
                            else
                            {
                    var json = wc.DownloadString("http://data.citedia.com/r1/parks/"+stringtab[0]);
                    dynamic data = JsonConvert.DeserializeObject<ParkInformation>(json);

                        Parking parking = new Parking(Guid.NewGuid(),data.name,null,data.max,data.free,0, new TimeSpan(0, 0, 0),new TimeSpan(0, 0, 0),data.status);

                                
                                Adresse adresse = new Adresse(Guid.NewGuid(), stringtab[3],0, 35000, "rennes", "france");
                                /*
                                    string querypark = "https://maps.googleapis.com/maps/api/geocode/json?address=" + stringtab[3] + "&key=AIzaSyCyoqbqJVd_MtZRT_0DmYmznxxJWRfMjQI";
                                        var json2 = wc.DownloadString(querypark);
                                        RootObjectGoogle item = JsonConvert.DeserializeObject<RootObjectGoogle>(json2);
                                        if (item.results.Count != 0)
                                        {
                                            parking.Coordonee0 = item.results.FirstOrDefault().geometry.location.lat;
                                            parking.Coordonee1 = item.results.FirstOrDefault().geometry.location.lng;
                                        }
                                        */
                                    ServiceAdresse.Insert(adresse,context);
                                parking.AdressePark = adresse;

                                //ServiceParking.DeleteAll();
                                ServiceParking.Insert(parking,context);
                                context.SaveChanges();

                                
                                    
                        parkingToAdd.Add(parking);
                                }
                                count++;
                    }
                    }
                context.Parkings.AddRange(parkingToAdd);
                context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// retourne la liste de tout les parkingviewmodel
        /// </summary>
        /// <returns></returns>
        public static List<ParkingViewModel> GetAll()
        {
            List<ParkingViewModel> listParkings = new List<ParkingViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Parking> parkings = ServiceParking.GetAll();
                foreach (Parking parking in parkings)
                {
                    listParkings.Add(new ParkingViewModel(parking));
                }
            }
            return listParkings;
        }

        /// <summary>
        /// Recupere un parking par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Parking GetById(Guid id)
        {
            Parking parking = null;
            using (ParkingContext context = new ParkingContext())
            {
                parking = ServiceParking.GetById(id, context);
                //Parking = context.Parkings.FirstOrDefault(l => l.Id == id);
            }
            return parking;
        }


        /// <summary>
        /// Enregistre ou met a jour un parking
        /// </summary>
        public void Save()
        {
            if (this.Id == Guid.Empty)
            {
                this.Metier.Id = Guid.NewGuid();
                ServiceParking.Insert(this.Metier);
            }
            else
            {
                ServiceParking.Update(this.Metier);
            }
        }
        /// <summary>
        /// Supprime un parking
        /// </summary>
        public void Delete()
        {
            if (this.Id != Guid.Empty)
            {
                ServiceParking.Delete(this.Metier);
            }
        }



    }
}