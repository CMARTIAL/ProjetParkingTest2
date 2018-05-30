using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BO;
    using DAL;
    using System;
    using System.Data.Entity;
    using System.Linq;
    public class ParkingContext : IdentityDbContext<ApplicationUser>
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « BiblioContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « MLV.DAL.BiblioContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « BiblioContext » dans le fichier de configuration de l'application.
        public ParkingContext()
            : base("name=ParkingContext")
        {
            //Database.SetInitializer<BiblioContext>(new BiblioContextInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ParkingContext, DAL.Migrations.Configuration>());
        }

        public static ParkingContext Create()
        {
            return new ParkingContext();
        }
        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Evenement> Evenements { get; set; }
        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Image> Images { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}