using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
                context.Adresses.Add(e);
                context.SaveChanges();
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
    }
}
