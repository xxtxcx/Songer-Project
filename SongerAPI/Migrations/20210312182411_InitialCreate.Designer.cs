﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongerAPI.Models;

namespace SongerAPI.Migrations
{
    [DbContext(typeof(SongItemContext))]
    [Migration("20210312182411_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SongerAPI.Models.SongItem", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SongArtist")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SongBpm")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SongKey")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SongTitle")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SongId");

                    b.ToTable("SongItems");
                });
#pragma warning restore 612, 618
        }
    }
}
