﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CustomerCatalogueContext))]
    partial class CustomerCatalogueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomersEntity", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SecurityKey")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddressTypesEntity", b =>
                {
                    b.Property<int>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressTypeId"));

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressType");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddressesEntity", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressId");

                    b.HasIndex("AddressTypeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerAddressesEntity", b =>
                {
                    b.Property<Guid>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerDetailsEntity", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddressesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.AddressTypesEntity", "AddressType")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressType");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerAddressesEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.AddressesEntity", "AddressEntity")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomersEntity", "CustomersEntity")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressEntity");

                    b.Navigation("CustomersEntity");
                });

            modelBuilder.Entity("Infrastructure.Entities.CustomerDetailsEntity", b =>
                {
                    b.HasOne("CustomersEntity", "Customers")
                        .WithOne("CustomerDetails")
                        .HasForeignKey("Infrastructure.Entities.CustomerDetailsEntity", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("CustomersEntity", b =>
                {
                    b.Navigation("CustomerAddresses");

                    b.Navigation("CustomerDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Entities.AddressTypesEntity", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddressesEntity", b =>
                {
                    b.Navigation("CustomerAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
