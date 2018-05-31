using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceEvenement
    {
        public static void Insert(Evenement e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Evenements.Add(e);
                context.SaveChanges();
            }
        }

        public static void Delete(Evenement e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Evenements.Remove(context.Evenements.FirstOrDefault(Evenement => Evenement.Id == e.Id));
                context.SaveChanges();
            }
        }

        public static void Update(Evenement e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                Evenement oldEvenement = context.Evenements.FirstOrDefault(Evenement => Evenement.Id == e.Id);// on n'appel pas la methode car il s'agit de 2 cotext differents GetById(l.Id);
                //Evenement oldEvenement = GetById(p.Id, context);  // on passe le context a la surcharge
                oldEvenement.Id = e.Id;
                oldEvenement.Titre = e.Titre;
                oldEvenement.AdresseEvenement = e.AdresseEvenement;
                oldEvenement.Duree = e.Duree;
                oldEvenement.Theme = e.Theme;
                oldEvenement.Tarif = e.Tarif;
                oldEvenement.Description = e.Description;
                oldEvenement.Images = e.Images;
                oldEvenement.DateEvenement = e.DateEvenement;
                context.SaveChanges();
            }
        }

        public static List<Evenement> GetAll()
        {
            List<Evenement> listEvenements = new List<Evenement>();
            using (ParkingContext context = new ParkingContext())
            {
                listEvenements = context.Evenements.ToList();
            }
            return listEvenements;
        }

        public static List<Evenement> GetNotPassed()
        {
            List<Evenement> listEvenements = new List<Evenement>();
            using (ParkingContext context = new ParkingContext())
            {
                listEvenements = context.Evenements.Where(ev => ev.DateEvenement > DateTime.Now).ToList();
            }
            return listEvenements;
        }

        public static List<Evenement> GetByTheme(string theme)
        {
            List<Evenement> listEvenements = new List<Evenement>();
            using (ParkingContext context = new ParkingContext())
            {
                listEvenements = context.Evenements.Where(ev => ev.Theme == theme).ToList();
            }
            return listEvenements;
        }

        public static Evenement GetByGuid(Guid id)
        {
            Evenement listEvenements = new Evenement();
            using (ParkingContext context = new ParkingContext())
            {
                listEvenements = context.Evenements.Where(ev => ev.Id == id).FirstOrDefault();
            }
            return listEvenements;
        }
    }
}
