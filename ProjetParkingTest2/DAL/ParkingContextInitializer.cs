using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BO;

namespace DAL
{
    class ParkingContextInitializer : DropCreateDatabaseIfModelChanges<ParkingContext>
        {
            protected override void Seed(ParkingContext contexte)
            {
                
            }
        
    }
}
