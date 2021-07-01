using DotNet.CleanArchitecture.Model.Entity.General;
using Microsoft.EntityFrameworkCore;

namespace DotNet.CleanArchitecture.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region General DbSets
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<ValueList> ValueLists { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region General Foreign Keys
            #region City
            modelBuilder.Entity<City>()
                .HasOne(e => e.State)
                .WithMany()
                .HasForeignKey(e => e.StateCode);
            #endregion

            #region State
            modelBuilder.Entity<State>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryCode);
            #endregion
            #endregion
        }
    }
}