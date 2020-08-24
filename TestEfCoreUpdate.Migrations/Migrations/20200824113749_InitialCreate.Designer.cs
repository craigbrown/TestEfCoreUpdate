﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEfCoreUpdate.Models;

namespace TestEfCoreUpdate.Migrations.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200824113749_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEfCoreUpdate.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyName = "ABC Corp"
                        });
                });

            modelBuilder.Entity("TestEfCoreUpdate.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Flagship"
                        });
                });

            modelBuilder.Entity("TestEfCoreUpdate.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("VariantId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("CompanyId", "ProductId")
                        .IsUnique();

                    b.HasIndex("ProductId", "VariantId");

                    b.ToTable("Subscription");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 1,
                            CompanyId = 1,
                            ProductId = 1,
                            VariantId = 1
                        });
                });

            modelBuilder.Entity("TestEfCoreUpdate.Models.Variant", b =>
                {
                    b.Property<int>("VariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("VariantId");

                    b.ToTable("Variant");

                    b.HasData(
                        new
                        {
                            VariantId = 1,
                            Name = "Beta",
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("TestEfCoreUpdate.Models.Subscription", b =>
                {
                    b.HasOne("TestEfCoreUpdate.Models.Company", "Company")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestEfCoreUpdate.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestEfCoreUpdate.Models.Variant", "Variant")
                        .WithMany()
                        .HasForeignKey("ProductId", "VariantId")
                        .HasPrincipalKey("ProductId", "VariantId");
                });

            modelBuilder.Entity("TestEfCoreUpdate.Models.Variant", b =>
                {
                    b.HasOne("TestEfCoreUpdate.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
