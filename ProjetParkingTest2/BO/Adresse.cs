using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Adresse : IEntityIdentifiable
    {
        public Adresse(Guid id, string rue, int numero, int codePostal, string ville, string pays)
        {
            Id = id;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
        }

        public Adresse() { }

        public Guid Id { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}
