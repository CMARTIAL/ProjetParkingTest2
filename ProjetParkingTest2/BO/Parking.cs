using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Parking : IEntityIdentifiable
    {
        public Parking(Guid id, string titre, Adresse adressePark, int nBPlaceTotal, int nBPlaceLibre, int tarif, TimeSpan heureOuverture, TimeSpan heureFermeture, string statut)
        {
            Id = id;
            Titre = titre;
            AdressePark = adressePark;



            NBPlaceTotal = nBPlaceTotal;
            NBPlaceLibre = nBPlaceLibre;
            Tarif = tarif;
            HeureOuverture = heureOuverture;
            HeureFermeture = heureFermeture;
            Statut = statut;
        }

        public Parking(Guid id, string titre, Adresse adressePark, int nBPlaceTotal, int nBPlaceLibre, int tarif, TimeSpan heureOuverture, TimeSpan heureFermeture, string statut, double coordonee0, double coordonee1) : this(id, titre, adressePark, nBPlaceTotal, nBPlaceLibre, tarif, heureOuverture, heureFermeture, statut) 
        {
            Coordonee0 = coordonee0;
            Coordonee1 = coordonee1;
        }

        public Parking() { }

        public Guid Id { get; set; }
        public string Titre { get; set; }
        public Adresse AdressePark { get; set; }
        public int NBPlaceTotal { get; set; }
        public int NBPlaceLibre { get; set; }
        public int Tarif { get; set; }
        public TimeSpan HeureOuverture { get; set; }
        public TimeSpan HeureFermeture { get; set; }
        public string Statut { get; set; }

        public double Coordonee0 { get; set; }
        public double Coordonee1 { get; set; }

    }
}
