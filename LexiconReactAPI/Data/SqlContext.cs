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

            modelBuilder.Entity<PersonEntity>()
            .HasOne<CityEntity>(c => c.City)
            .WithMany(p => p.People)
            .HasForeignKey(s => s.CurrentCityId);

            modelBuilder.Entity<CityEntity>().HasData(new CityEntity { CityId = 007, CityName = "Bangkok" });
            modelBuilder.Entity<CityEntity>().HasData(new CityEntity { CityId = 008, CityName = "Berlin" });
            modelBuilder.Entity<CityEntity>().HasData(new CityEntity { CityId = 009, CityName = "Bangalore" });

            modelBuilder.Entity<CountryEntity>().HasData(new CountryEntity { CountryId = 117, CountryName = "Bangladesh" });
            modelBuilder.Entity<CountryEntity>().HasData(new CountryEntity { CountryId = 118, CountryName = "Baharain" });
            modelBuilder.Entity<CountryEntity>().HasData(new CountryEntity { CountryId = 119, CountryName = "Spain" });


            modelBuilder.Entity<PersonEntity>().HasData(new PersonEntity { Id = 666, Name = "Doggy Dog", PhoneNumber = "12345-7899", CurrentCityId = 007 });
            modelBuilder.Entity<PersonEntity>().HasData(new PersonEntity { Id = 999, Name = "Kalle Kanin", PhoneNumber = "12345-7585", CurrentCityId = 008 });
            modelBuilder.Entity<PersonEntity>().HasData(new PersonEntity { Id = 123, Name = "Hasse Hare", PhoneNumber = "12345-8522", CurrentCityId = 009 });

            modelBuilder.Entity<LanguageEntity>().HasData(new LanguageEntity { LanguageId = 123, LanguageName = "Chinese" });
            modelBuilder.Entity<LanguageEntity>().HasData(new LanguageEntity { LanguageId = 124, LanguageName = "Portuguese" });
            modelBuilder.Entity<LanguageEntity>().HasData(new LanguageEntity { LanguageId = 125, LanguageName = "Spanish" });
            modelBuilder.Entity<LanguageEntity>().HasData(new LanguageEntity { LanguageId = 126, LanguageName = "Finnish" });
            modelBuilder.Entity<LanguageEntity>().HasData(new LanguageEntity { LanguageId = 127, LanguageName = "Esperanto" });



        }

        public virtual DbSet<PersonEntity> People { get; set; }
        public virtual DbSet<CityEntity> Cities { get; set; }
        public virtual DbSet<CountryEntity> Countries { get; set; }
        public virtual DbSet<PersonLanguageEntity> PersonLanguages { get; set; }
        public virtual DbSet<LanguageEntity> Languages { get; set; }
    }
}
