using Competition.App.Domain.Entities;
using System.Data.Entity;

namespace Competition.App.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=CompetitonsConnString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Competitions> Competitions { get; set; }

        public DbSet<Teams> Teams { get; set; }

        public DbSet<Matches> Matches { get; set; }

    }
}
