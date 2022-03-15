﻿// <auto-generated />
using System;
using LexiconReactAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LexiconReactAPI.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20220314145533_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.CityEntity", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryEntityCountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryEntityCountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 7,
                            CityName = "Bangkok"
                        },
                        new
                        {
                            CityId = 8,
                            CityName = "Berlin"
                        },
                        new
                        {
                            CityId = 9,
                            CityName = "Bangalore"
                        });
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.CountryEntity", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 117,
                            CountryName = "Bangladesh"
                        },
                        new
                        {
                            CountryId = 118,
                            CountryName = "Baharain"
                        },
                        new
                        {
                            CountryId = 119,
                            CountryName = "Spain"
                        });
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.LanguageEntity", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 123,
                            LanguageName = "Chinese"
                        },
                        new
                        {
                            LanguageId = 124,
                            LanguageName = "Portuguese"
                        },
                        new
                        {
                            LanguageId = 125,
                            LanguageName = "Spanish"
                        },
                        new
                        {
                            LanguageId = 126,
                            LanguageName = "Finnish"
                        },
                        new
                        {
                            LanguageId = 127,
                            LanguageName = "Esperanto"
                        });
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 666,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 7,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Doggy Dog",
                            PhoneNumber = "12345-7899"
                        },
                        new
                        {
                            Id = 999,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 8,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalle Kanin",
                            PhoneNumber = "12345-7585"
                        },
                        new
                        {
                            Id = 123,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CurrentCityId = 9,
                            Edited = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hasse Hare",
                            PhoneNumber = "12345-8522"
                        });
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.PersonLanguageEntity", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.CityEntity", b =>
                {
                    b.HasOne("LexiconReactAPI.Models.Entities.CountryEntity", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryEntityCountryId");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.PersonEntity", b =>
                {
                    b.HasOne("LexiconReactAPI.Models.Entities.CityEntity", "City")
                        .WithMany("People")
                        .HasForeignKey("CurrentCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.PersonLanguageEntity", b =>
                {
                    b.HasOne("LexiconReactAPI.Models.Entities.LanguageEntity", "Language")
                        .WithMany("People")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconReactAPI.Models.Entities.PersonEntity", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.CityEntity", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.CountryEntity", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.LanguageEntity", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("LexiconReactAPI.Models.Entities.PersonEntity", b =>
                {
                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}
