using System;
using System.Collections.Generic;
using System.Data.Entity;
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
       
        public DbSet<Client> Clients { get; set; }
        public DbSet<CoordonneeC> CoordonneeCs { get; set; }
        public DbSet<CoordonneeP> CoordonneePs { get; set; }
        public DbSet<Prestataire> Prestataires { get; set; }
        public DbSet<Prestation> Prestations { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
        
    }
}
