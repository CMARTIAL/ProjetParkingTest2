﻿using Services;
using System;
using System.Collections.Generic;
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
        public List<EvenementViewModel> GetAll()
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (BiblioContext context = new BiblioContext())
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
        public List<EvenementViewModel> GetNotPassed()
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (BiblioContext context = new BiblioContext())
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
        public List<EvenementViewModel> GetByTheme(String theme)
        {
            List<EvenementViewModel> listEvenements = new List<EvenementViewModel>();
            //listLivres = Dal.Get

            using (BiblioContext context = new BiblioContext())
            {
                List<Evenement> evenements = ServiceEvenement.GetByTheme(theme);
                foreach (Evenement evenement in evenements)
                {
                    listEvenements.Add(new EvenementViewModel(evenement));
                }
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
                ServiceEvenement.Insert(this.Metier);
            }
            else
            {
                ServiceEvenement.Update(this.Metier);
            }
        }
    }
}