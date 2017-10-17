using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.modeles
{
    public class Db : DbContext
    {
        public Db() : base("TpCarsDb")
        {

        }
       
        public DbSet<Adresse> Adresses { get; set; }        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coordonnee> Coordonnees { get; set; }
        public DbSet<Prestataire> Prestataires { get; set; }
        public DbSet<Prestation> Prestations { get; set; }
        public DbSet<Voiture> Voitures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasRequired(d => d.Coordonnee)
                .WithMany()
                .HasForeignKey(d => d.IdCoordonnee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prestataire>()
                .HasRequired(d => d.Coordonnee)
                .WithMany()
                .HasForeignKey(d => d.IdCoordonnee)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
