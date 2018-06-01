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
    public class EvenementViewModel : ViewModel<Evenement>
    {
        public EvenementViewModel()
        {
            this.Metier = new Evenement();
        }
        public EvenementViewModel(Evenement parking)
        {
            this.Metier = parking;
        }

        /// <summary>
        /// Recupere tout les evenementsviewmodel
        /// </summary>
        /// <returns></returns>
        public static List<EvenementViewModel> GetAll()
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Evenement> evenements = ServiceEvenement.GetAll();
                foreach (Evenement evenement in evenements)
                {
                    listEvenements.Add(new EvenementViewModel(evenement));
                }
            }
            return listEvenements;
        }

        /// <summary>
        /// Retourne la liste des EvenemntViewModel qui ne sont pas encore passé
        /// </summary>
        /// <returns></returns>
        public static List<EvenementViewModel> GetNotPassed()
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Evenement> evenements = ServiceEvenement.GetNotPassed();
                foreach (Evenement evenement in evenements)
                {
                    listEvenements.Add(new EvenementViewModel(evenement));
                }
            }
            return listEvenements;
        }

        /// <summary>
        /// Recupere tout les evenementviewmodel par theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static List<EvenementViewModel> GetByTheme(String theme)
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                List<Evenement> evenements = ServiceEvenement.GetByTheme(theme);
                foreach (Evenement evenement in evenements)
                {
                    listEvenements.Add(new EvenementViewModel(evenement));
                }
            }
            return listEvenements;
        }


        public static EvenementViewModel GetByGuid(Guid id)
        {
            EvenementViewModel listEvenements = new EvenementViewModel();
            using (ParkingContext context = new ParkingContext())
            {
                Evenement evenements = ServiceEvenement.GetByGuid(id);
                listEvenements = new EvenementViewModel(evenements);
            }
            return listEvenements;
        }

        /// <summary>
        /// Enregistre ou met a jour un evenement 
        /// </summary>
        public void Save()
        {
            if (this.Id == Guid.Empty)
            {
                
                this.Metier.Id = Guid.NewGuid();
                this.Metier.AdresseEvenement.Id = Guid.NewGuid();
                using (ParkingContext context = new ParkingContext())
                {
                    ServiceAdresse.Insert(this.Metier.AdresseEvenement, context);
                    ServiceEvenement.Insert(this.Metier, context);
                    context.SaveChanges();
                }
               

            }
            else
            {
                ServiceEvenement.Update(this.Metier);
            }
        }

        /// <summary>
        /// Supprime un evenement 
        /// </summary>
        public void Delete()
        {
            if (this.Id != Guid.Empty)
            {
                ServiceEvenement.Delete(this.Metier);
            }
        }

        [Display(Name = "Nom de l'évènement")]
        public string Titre
        {
            get
            { return Metier.Titre; }
            set
            { Metier.Titre = value; }
        }

        public Guid Id
        {
            get
            { return Metier.Id; }
            set
            { Metier.Id = value; }
        }
        [Display(Name = "Emplacement")]
        public Adresse AdresseEvenement
        {
            get
            { return Metier.AdresseEvenement; }
            set
            { Metier.AdresseEvenement = value; }
        }
        [Display(Name = "Durée de l'évènement")]
        public int Duree
        {
            get
            { return Metier.Duree; }
            set
            { Metier.Duree = value; }
        }
        [Display(Name = "Thème'évènement")]
        public string Theme
            {
            get
            { return Metier.Theme; }
            set
            { Metier.Theme = value; }
        }

        [Display(Name = "^Prix de l'évènement")]
        public int Tarif
        {
            get
            { return Metier.Tarif; }
            set
            { Metier.Tarif = value; }
        }
        public string Description
        {
            get
            { return Metier.Description; }
            set
            { Metier.Description = value; }
        }
        public virtual ICollection<Image> Images
        {
            get
            { return Metier.Images; }
            set
            { Metier.Images = value; }
        }

        [Display(Name = "Date de l'évènement")]
        public DateTime DateEvenement
        {
            get
            { return Metier.DateEvenement; }
            set
            { Metier.DateEvenement = value; }
        }
    }
}