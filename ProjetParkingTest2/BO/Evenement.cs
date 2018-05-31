﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Evenement : IEntityIdentifiable
    {
        public Evenement(Guid id, string titre, Adresse adresseEvenement, int duree, string theme, int tarif, string description, ICollection<Image> images, DateTime dateEvenement)
        {
            Id = id;
            Titre = titre;
            AdresseEvenement = adresseEvenement;
            Duree = duree;
            Theme = theme;
            Tarif = tarif;
            Description = description;
            Images = images;
            DateEvenement = dateEvenement;
        }

        public Evenement() { }

        public Guid Id { get; set; }
        public string Titre { get; set; }
        public Adresse AdresseEvenement { get; set; }
        public int Duree { get; set; }
        public string Theme { get; set; }
        public int Tarif { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public DateTime DateEvenement { get; set; }

    }
}
