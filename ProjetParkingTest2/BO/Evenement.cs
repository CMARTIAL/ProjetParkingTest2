using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Evenement : IEntityIdentifiable
    {
        public Evenement(Guid id, string titre, Adresse adresseEvenement, int duree, string theme, int tarif, string description, Image ImageEvenement, DateTime dateEvenement)
        {
            Id = id;
            Titre = titre;   
            Duree = duree;
            Theme = theme;
            Tarif = tarif;
            Description = description;
            this.ImageEvenement = ImageEvenement;
            DateEvenement = dateEvenement;
            AdresseEvenement = adresseEvenement;
        }

        public Evenement() { }

        public Guid Id { get; set; }
        public string Titre { get; set; }
        public Adresse AdresseEvenement { get; set; }
        public int Duree { get; set; }
        public string Theme { get; set; }
        public int Tarif { get; set; }
        public string Description { get; set; }
        public virtual Image ImageEvenement { get; set; }
        public DateTime DateEvenement { get; set; }

    }
}
