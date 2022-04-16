﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourismWebsite.Data;

namespace TourismWebsite.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220414223226_Tourism1")]
    partial class Tourism1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TourismWebsite.Models.Agency", b =>
                {
                    b.Property<int>("AgencyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyContact")
                        .HasColumnType("int");

                    b.Property<string>("AgencyHeadOffice")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("AgencyRatings")
                        .HasColumnType("int");

                    b.HasKey("AgencyID");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("TourismWebsite.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyID")
                        .HasColumnType("int");

                    b.Property<int>("DestinationID")
                        .HasColumnType("int");

                    b.Property<int>("GuideID")
                        .HasColumnType("int");

                    b.Property<int>("TouristID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("AgencyID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("GuideID");

                    b.HasIndex("TouristID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("TourismWebsite.Models.Destination", b =>
                {
                    b.Property<int>("DestinationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DestinationLocation")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DestinationPackage")
                        .HasColumnType("int");

                    b.HasKey("DestinationID");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("TourismWebsite.Models.Guide", b =>
                {
                    b.Property<int>("GuideID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuideContact")
                        .HasColumnType("int");

                    b.Property<string>("GuideGender")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("GuideName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GuidingExperience")
                        .HasColumnType("int");

                    b.HasKey("GuideID");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("TourismWebsite.Models.Tourist", b =>
                {
                    b.Property<int>("TouristID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TouristAge")
                        .HasColumnType("int");

                    b.Property<int>("TouristContact")
                        .HasColumnType("int");

                    b.Property<string>("TouristGender")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("TouristName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("TouristID");

                    b.ToTable("Tourist");
                });

            modelBuilder.Entity("TourismWebsite.Models.Booking", b =>
                {
                    b.HasOne("TourismWebsite.Models.Agency", "Agency")
                        .WithMany("Bookings")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourismWebsite.Models.Destination", "Destination")
                        .WithMany("Bookings")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourismWebsite.Models.Guide", "Guide")
                        .WithMany("Bookings")
                        .HasForeignKey("GuideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourismWebsite.Models.Tourist", "Tourist")
                        .WithMany("Bookings")
                        .HasForeignKey("TouristID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Destination");

                    b.Navigation("Guide");

                    b.Navigation("Tourist");
                });

            modelBuilder.Entity("TourismWebsite.Models.Agency", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TourismWebsite.Models.Destination", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TourismWebsite.Models.Guide", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TourismWebsite.Models.Tourist", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}