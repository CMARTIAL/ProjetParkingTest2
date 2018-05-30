using BO;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// retourne la liste de tout les parkingviewmodel
        /// </summary>
        /// <returns></returns>
        public List<ParkingViewModel> GetAll()
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



    }
}