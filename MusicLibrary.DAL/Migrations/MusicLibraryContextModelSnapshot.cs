﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrary.DAL;

namespace MusicLibrary.DAL.Migrations
{
    [DbContext(typeof(MusicLibraryContext))]
    partial class MusicLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MusicLibrary.DAL.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicLibrary.DAL.Entities.MusicUsers", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("MusicUsers");
                });

            modelBuilder.Entity("MusicLibrary.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MusicLibrary.DAL.Entities.MusicUsers", b =>
                {
                    b.HasOne("MusicLibrary.DAL.Entities.Album", "Album")
                        .WithMany("MusicUsers")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrary.DAL.Entities.User", "User")
                        .WithMany("MusicUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicLibrary.DAL.Entities.Album", b =>
                {
                    b.Navigation("MusicUsers");
                });

            modelBuilder.Entity("MusicLibrary.DAL.Entities.User", b =>
                {
                    b.Navigation("MusicUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
