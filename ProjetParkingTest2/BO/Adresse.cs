using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Adresse : IEntityIdentifiable
    {
        public Adresse(Guid id, string rue, int numero, int codePostal, string ville, string pays, bool parking)
        {
            Id = id;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            IsParking = parking;
        }

        public Adresse(Guid id, string rue, int numero, int codePostal, string ville, string pays)
        {
            Id = id;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            IsParking = false;
        }

        public Adresse() { }

        public Guid Id { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
        public bool IsParking { get; set; }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Pays);
            str.Append(" ");
            if (Numero > 0)
            {
                str.Append(Numero);
                str.Append(" ");
            }
            str.Append(Rue);
            str.Append(" ");
            str.Append(Ville);
            str.Append(" ");
            if (CodePostal > 0)
            {
                str.Append(CodePostal);
            }
            //string result = Numero + " " + Rue + " " + CodePostal + " " + Ville + " " + Pays;
            return RemoveDiacritics(str.ToString());
        }
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
