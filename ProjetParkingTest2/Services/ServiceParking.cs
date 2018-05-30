using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                listParking = context.Parkings.ToList();
            }
            return listParking;
        }
    }
}
