﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stefanini.Order.Infra.Context;

namespace Stefanini.Order.Infra.Migrations
{
    [DbContext(typeof(EfCore))]
    [Migration("20240801153252_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderItemId")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId")
                        .UseIdentityColumn();

                    b.Property<string>("ProductName")
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.OrderItem", b =>
                {
                    b.HasOne("Stefanini.Order.Domain.Entites.Order", "Order")
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stefanini.Order.Domain.Entites.Product", "Product")
                        .WithOne("OrderItems")
                        .HasForeignKey("Stefanini.Order.Domain.Entites.OrderItem", "ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.Order", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("Stefanini.Order.Domain.Entites.Product", b =>
                {
                    b.Navigation("OrderItems")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
