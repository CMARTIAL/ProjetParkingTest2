using BO;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceAdresse
    {

        public static void Insert(Adresse e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                Insert(e, context);
                /*
                context.Adresses.Add(e);
                */
                context.SaveChanges();
            }
        }

        public static void Insert(Adresse e, ParkingContext context)
        {

            using (WebClient wc = new WebClient())
            {
                try
                {
                     string querypark = "https://maps.googleapis.com/maps/api/geocode/json?address=" + e.ToString() + "&key=AIzaSyCyoqbqJVd_MtZRT_0DmYmznxxJWRfMjQI";
                     var json2 = wc.DownloadString(querypark);
                     RootObjectGoogle item = JsonConvert.DeserializeObject<RootObjectGoogle>(json2);
                    if (item.results.Count != 0)
                    {
                        e.lat = item.results.FirstOrDefault().geometry.location.lat;
                        e.lng = item.results.FirstOrDefault().geometry.location.lng;
                    }

                }
                catch (Exception)
                {
                    context.Adresses.Add(e); //meme si il y a une erreur on ajoute l'adresse sans latitude ni longitude
                    throw;
                }
                context.Adresses.Add(e);
            }
        }

        public static void Delete(Adresse e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Adresses.Remove(context.Adresses.FirstOrDefault(Adresse => Adresse.Id == e.Id));
                context.SaveChanges();
            }
        }

        public static void Update(Adresse e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                Adresse oldAdresse = context.Adresses.FirstOrDefault(Adresse => Adresse.Id == e.Id);
                oldAdresse.Id = e.Id;
                oldAdresse.Rue = e.Rue;
                oldAdresse.Numero = e.Numero;
                oldAdresse.CodePostal = e.CodePostal;
                oldAdresse.Pays = e.Pays;
                oldAdresse.Ville = e.Ville;
                context.SaveChanges();
            }
        }

        public static List<Adresse> GetAll()
        {
            List<Adresse> listAdresses = new List<Adresse>();
            using (ParkingContext context = new ParkingContext())
            {
                listAdresses = context.Adresses.ToList();
            }
            return listAdresses;
        }

        public static Adresse GetByGuid(Guid id)
        {
            Adresse listAdresses = new Adresse();
            using (ParkingContext context = new ParkingContext())
            {
                listAdresses = context.Adresses.Where(ev => ev.Id == id).FirstOrDefault();
            }
            return listAdresses;
        }

        public static void DeleteParking()
        {
            using (ParkingContext context = new ParkingContext())
            {
                foreach (Adresse item in GetAll())
                {
                    if(item.IsParking == true)
                    {
                        Delete(item);
                    }
                }
            }
        }
    }
}
