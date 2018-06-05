using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services
{
    public class ServiceParking
    {

        public static void Insert(Parking p)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Parkings.Add(p);
                context.SaveChanges();
            }
        }

        public static void Update(Parking p)
        {
            using (ParkingContext context = new ParkingContext())
            {
                Parking oldParking = context.Parkings.FirstOrDefault(Parking => Parking.Id == p.Id);// on n'appel pas la methode car il s'agit de 2 cotext differents GetById(l.Id);
                //Parking oldParking = GetById(p.Id, context);  // on passe le context a la surcharge
                oldParking.Titre = p.Titre;
                oldParking.AdressePark = p.AdressePark;
                oldParking.NBPlaceTotal = p.NBPlaceTotal;
                oldParking.NBPlaceLibre = p.NBPlaceLibre;
                oldParking.Tarif = p.Tarif;
                oldParking.HeureOuverture = p.HeureFermeture;
                oldParking.HeureFermeture = p.HeureFermeture;
                oldParking.Statut = p.Statut;

                context.SaveChanges();
            }
        }

        public static Parking GetById(Guid? id, ParkingContext context)
        {
            Parking parking = null;
            parking = (from p in context.Parkings
                       where p.Id == id
                       select p).FirstOrDefault();

            return parking;
            //return = context.Parkings.FirstOrDefault(l => l.Id == id);
        }

        public static List<Parking> GetAll()
        {
            List<Parking> listParking = new List<Parking>();
            using (ParkingContext context = new ParkingContext())
            {
                listParking = context.Parkings.Include("AdressePark").ToList();
            }
            return listParking;
        }

        /// <summary>
        /// Ne pas utiliser en cours d'ecriture
        /// </summary>
        /// <param name="adresse"></param>
        /// <returns></returns>
        public static List<Parking> Get3(Guid eventID)
        {
            List<Parking> listParking = new List<Parking>();
            Evenement evenement = new Evenement();
            using (ParkingContext context = new ParkingContext())
            {
                listParking = context.Parkings.Include("AdressePark").Where(p =>p.NBPlaceLibre>0).ToList();
                evenement = context.Evenements.Include("AdresseEvenement").Where(e => e.Id == eventID).FirstOrDefault();
            }

            Parking closestPark = new Parking();
            double closestDistance = double.MaxValue;
            for (int i = 0; i < listParking.Count(); i++)
            {
                Parking parking = listParking[i];
                double distance = closestAddress((double)evenement.AdresseEvenement.lat, (double)evenement.AdresseEvenement.lng, parking);
                if (i == 0)
                {
                    closestDistance = distance;
                    closestPark = parking;
                }
                else if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPark = parking;
                }
            }
            listParking.Add(closestPark); // a Modifier pour ne prendre que les 3 plus proches

            return listParking;
        }

        private static double closestAddress(double ULongitude, double ULatitude, Parking parking)
        {
            double ALongitude = parking.Coordonee0;
            double ALatitude = parking.Coordonee1;

            double distance = findDistance(ULongitude, ULatitude, ALongitude, ALatitude);
            return distance;
        }

        private static double findDistance(double Ulong, double Ulat, double ALong, double ALat)
        {
            double x = (ALong - Ulong) * Math.Cos((Ulat + ALat) / 2);
            double y = (ALat - Ulat);
            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            return d;
        }


        public static void Delete(Parking e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Parkings.Remove(context.Parkings.Include("AdressePark").FirstOrDefault(Parking => Parking.Id == e.Id));
                context.SaveChanges();
            }
        }

        public static void DeleteAll()
        {
            using (ParkingContext context = new ParkingContext())
            {
                foreach (Parking item in GetAll())
                {
                    Delete(item);
                }
            }
        }
    }
}
