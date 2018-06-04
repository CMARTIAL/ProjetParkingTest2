﻿using BO;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetParkingTest2.Models
{
    public class EvenementParkingViewModel
    {
        public List<Parking> Parkings { get; set; }
        public Evenement Evenement { get; set; }
        public  string AdresseConvive { get; set; }  // l'adresse du convive est un string pour pouvoir faire une rechcerche directement
        public EvenementParkingViewModel()
        {

        }

        public EvenementParkingViewModel(List<Parking> parkings, Evenement evenement, string adresseConvive)
        {
            Parkings = parkings;
            Evenement = evenement;
            AdresseConvive = adresseConvive;
        }

        public static EvenementParkingViewModel Get3ParkingByEvent(Guid id,string adresseConvive)
        {
            EvenementParkingViewModel epvm = new EvenementParkingViewModel();
            //listLivres = Dal.Get

            using (ParkingContext context = new ParkingContext())
            {
                epvm.Evenement = ServiceEvenement.GetByGuid(id);
                epvm.Parkings = ServiceParking.Get3(id); // recupere les 3 parkings par evenements
                epvm.AdresseConvive = adresseConvive;
            }
            return epvm;
        }
    }
}