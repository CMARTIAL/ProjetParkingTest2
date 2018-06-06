using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Parking : IEntityIdentifiable
    {
        public Parking(Guid id, string titre, Adresse adressePark, int nBPlaceTotal, int nBPlaceLibre, string tarif, string horraire, string statut)
        {
            Id = id;
            Titre = titre;
            AdressePark = adressePark;
            NBPlaceTotal = nBPlaceTotal;
            NBPlaceLibre = nBPlaceLibre;
            Tarif = tarif;
            Horraire = horraire;
            Statut = statut;
        }

        public Parking() { }
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public Adresse AdressePark { get; set; }
        public int NBPlaceTotal { get; set; }
        public int NBPlaceLibre { get; set; }
        public string Tarif { get; set; }
        public string Horraire { get; set; }
        public string Statut { get; set; }

        [NotMapped]
        public double Distance { get; set; }
        [NotMapped]
        public double TarifEstime { get; set; }
    }
}
