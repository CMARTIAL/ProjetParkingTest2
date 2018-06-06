using BO;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Recupere tout les Adressesviewmodel
        /// </summary>
        /// <returns></returns>
        public static List<AdresseViewModel> GetAll()
        {
            List<AdresseViewModel> listAdresses = new List<AdresseViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Adresse> Adresses = ServiceAdresse.GetAll();
                foreach (Adresse Adresse in Adresses)
                {
                    listAdresses.Add(new AdresseViewModel(Adresse));
                }
            }
            return listAdresses;
        }

        public static AdresseViewModel GetByGuid(Guid id)
        {
            AdresseViewModel listAdresses = new AdresseViewModel();
            using (ParkingContext context = new ParkingContext())
            {
                Adresse Adresses = ServiceAdresse.GetByGuid(id);
                listAdresses = new AdresseViewModel(Adresses);
            }
            return listAdresses;
        }

        /// <summary>
        /// Enregistre ou met a jour un Adresse 
        /// </summary>
        public void Save()
        {
            if (this.Id == Guid.Empty)
            {
                this.Metier.Id = Guid.NewGuid();
                ServiceAdresse.Insert(this.Metier);
            }
            else
            {
                ServiceAdresse.Update(this.Metier);
            }
        }

        /// <summary>
        /// Enregistre ou met a jour un Adresse 
        /// </summary>
        public void Delete()
        {
            if (this.Id != Guid.Empty)
            {
                ServiceAdresse.Delete(this.Metier);
            }
        }


        [Display(Name = "Référence de l'adresse")]
        public Guid Id
        {
            get
            { return Metier.Id; }
            set
            { Metier.Id = value; }
        }
        [Display(Name = "Nom de rue")]
        public string Rue
        {
            get
            { return Metier.Rue; }
            set
            { Metier.Rue = value; }
        }
        public int Numero
        {
            get
            { return Metier.Numero; }
            set
            { Metier.Numero = value; }
        }
        [Display(Name = "Code postal")]
        public int CodePostal
        {
            get
            { return Metier.CodePostal; }
            set
            { Metier.CodePostal = value; }
        }
        public string Ville
        {
            get
            { return Metier.Ville; }
            set
            { Metier.Ville = value; }
        }
        public string Pays
        {
            get
            { return Metier.Pays; }
            set
            { Metier.Pays = value; }
        }

     
        public bool IsParking
        {
            get { return Metier.IsParking; }
            set { Metier.IsParking = value; }
        }
    }
}