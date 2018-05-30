using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetParkingTest2.Models
{    public class ViewModel<T> where T : IEntityIdentifiable
    {
        public T Metier { get; protected set; }

        public Guid Id
        {
            get
            { return this.Metier.Id; }
        }

    }
}