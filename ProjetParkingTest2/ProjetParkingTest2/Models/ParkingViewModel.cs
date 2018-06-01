using BO;
using DAL;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
        [Display(Name = "Longitude ?")]
        public double Coordonee1
        {
            get { return Metier.Coordonee1; }
            set { Metier.Coordonee1 = value; }
        }



       /* public static void AddtoBase()
        {
            List<Parking> parkingToAdd = new List<Parking>();
            //recupere les parkings
            using (ParkingContext context = new ParkingContext())
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("http://data.citedia.com/r1/parks/");
                    dynamic data = JsonConvert.DeserializeObject<RootObject>(json);
                    foreach (Park park in data.parks)
                    {
                        Parking parking = new Parking(Guid.NewGuid(),
                                                      park.parkInformation.name,
                                                      null,
                                                      park.parkInformation.max,
                                                      park.parkInformation.free,
                                                      0, new TimeSpan(0, 0, 0),
                                                      new TimeSpan(0, 0, 0),
                                                      park.parkInformation.status
                                                      );
                        foreach (Feature feature in data.features.features)
                        {
                            if (feature.id == park.id)
                            {
                                parking.Coordonee0 = feature.geometry.coordinates[0];
                                parking.Coordonee1 = feature.geometry.coordinates[1];
                            }
                        }
                        parkingToAdd.Add(parking);
                    }
                }
                context.Parkings.AddRange(parkingToAdd);
                context.SaveChanges();
            }
        }*/

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