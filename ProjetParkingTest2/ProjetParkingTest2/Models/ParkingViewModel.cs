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

            using (BiblioContext context = new BiblioContext())
            {
                List<Parking> parkings = ServiceParking.GetNotPassed();
                foreach (Parking parking in parkings)
                {
                    listParkings.Add(new EvenementViewModel(parking));
                }
            }
            return listParkings;
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