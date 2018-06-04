using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceImage
    {
        public static void Insert(Image e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Images.Add(e);
                context.SaveChanges();
            }
        }

        public static void Insert(Image e, ParkingContext context)
        {
            context.Images.Add(e);
        }

        public static void Delete(Image e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                context.Images.Remove(context.Images.FirstOrDefault(Image => Image.Id == e.Id));
                context.SaveChanges();
            }
        }

        public static void Update(Image e)
        {
            using (ParkingContext context = new ParkingContext())
            {
                Image oldImage = context.Images.FirstOrDefault(Image => Image.Id == e.Id);
                oldImage.Id = e.Id;
                oldImage.Titre = e.Titre;
                oldImage.Path = e.Path;
                context.SaveChanges();
            }
        }

        public static List<Image> GetAll()
        {
            List<Image> listImages = new List<Image>();
            using (ParkingContext context = new ParkingContext())
            {
                listImages = context.Images.ToList();
            }
            return listImages;
        }


        public static Image GetByGuid(Guid id)
        {
            Image listImages = new Image();
            using (ParkingContext context = new ParkingContext())
            {
                listImages = context.Images.Where(ev => ev.Id == id).FirstOrDefault();
            }
            return listImages;
        }
    }
}
