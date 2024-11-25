﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Infrastructure;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125210008_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WebApplication1.Domain.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Name = "Laptop",
                            Price = 1500.00m
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Name = "Phone",
                            Price = 900.00m
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = false,
                            Name = "Headphones",
                            Price = 45.00m
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Name = "Mouse",
                            Price = 25.00m
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Name = "Monitor",
                            Price = 200.00m
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            Name = "Keyboard",
                            Price = 80.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
