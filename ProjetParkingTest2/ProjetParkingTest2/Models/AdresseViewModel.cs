using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetParkingTest2.Models
{
    public class AdresseViewModel : ViewModel<Adresse>
    {
        public AdresseViewModel()
        {
            this.Metier = new Adresse();
        }
        public AdresseViewModel(Adresse parking)
        {
            this.Metier = parking;
        }
    }
}