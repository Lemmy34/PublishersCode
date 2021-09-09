using ADMpublishers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data
{
    public class ADMpublishersContext : DbContext
    {


        public ADMpublishersContext() : base("ADMpublishersContext")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
