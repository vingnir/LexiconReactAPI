using LexiconReactAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LexiconReactAPI.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
                
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Recommend on the first line inside method.


            modelBuilder.Entity<PersonLanguageEntity>().HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguageEntity>()
            .HasOne<PersonEntity>(pl => pl.Person)
            .WithMany(p => p.Languages)
            .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguageEntity>()
            .HasOne<LanguageEntity>(pl => pl.Language)
            .WithMany(p => p.People)
            .HasForeignKey(pl => pl.LanguageId);

            

           



        }

        
        public virtual DbSet<CityEntity> Cities { get; set; }
        public virtual DbSet<CountryEntity> Countries { get; set; }
        public virtual DbSet<PersonLanguageEntity> PersonLanguages { get; set; }
        public virtual DbSet<LanguageEntity> Languages { get; set; }
        public virtual DbSet<PersonEntity> People { get; set; }
    }
}
