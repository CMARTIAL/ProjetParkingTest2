using BO;
using DAL;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        public string Titre
        {
            get { return Metier.Titre; }
            set { Metier.Titre = value; }
        }
        [Display(Name = "Nombre de places totals")]
        public int NBPlaceTotal
        {
            get { return Metier.NBPlaceTotal; }
            set { Metier.NBPlaceTotal = value; }
        }
        [Display(Name = "Nombre de places libres")]
        public int NBPlaceLibre
        {
            get { return Metier.NBPlaceLibre; }
            set { Metier.NBPlaceLibre = value; }
        }
        [Display(Name = "Statut du parling")]
        public string Statut
        {
            get { return Metier.Statut; }
            set { Metier.Statut = value; }
        }
        [Display(Name = "Tarification")]
        public string Tarif
        {
            get { return Metier.Tarif; }
            set { Metier.Tarif = value; }
        }

        [Display(Name = "Horraires")]
        public string Horraire
        {
            get { return Metier.Horraire; }
            set { Metier.Horraire = value; }
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



        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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

                    
                        int count = 0;
                        foreach (string[] stringtab in csvfile)
                        {
                            if (count != 0)
                            {
                                
                                var json = wc.DownloadString("http://data.citedia.com/r1/parks/" + stringtab[0]);
                                dynamic data = JsonConvert.DeserializeObject<ParkInformation>(json);

                                Adresse adresse = new Adresse(Guid.NewGuid(), stringtab[3], 0, 35000, "rennes", "france", true);
                                Parking parking = new Parking(Guid.NewGuid(), RemoveDiacritics(stringtab[0]), adresse, data.max, data.free, RemoveDiacritics(stringtab[2]), RemoveDiacritics(stringtab[1]), data.status);

                                ServiceAdresse.Insert(adresse, context);
                                ServiceParking.Insert(parking, context);

                                //Suppression des anciennes données
                                ServiceParking.DeleteAll();
                                ServiceAdresse.DeleteParking();

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