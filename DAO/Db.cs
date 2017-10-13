using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class Db : DbContext
    {
        public Db() : base("TpCars")
        {

        }

        //public DbSet<Client> Clients { get; set; }
        



    }
}
