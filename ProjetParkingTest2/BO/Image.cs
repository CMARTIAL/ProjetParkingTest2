using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Image : IEntityIdentifiable
    {
        public Image(Guid id, string titre, string path)
        {
            Id = id;
            Titre = titre;
            Path = path;
        }
        
        public Image() { }

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Titre { get; set; }
        public string Path { get; set; }
    }
}
