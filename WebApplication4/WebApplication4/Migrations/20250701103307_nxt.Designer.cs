﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Model;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(Apicontext))]
    [Migration("20250701103307_nxt")]
    partial class nxt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication4.Model.Category", b =>
                {
                    b.Property<int>("CateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CateID"));

                    b.Property<string>("CateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CateID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApplication4.Model.Customer", b =>
                {
                    b.Property<int>("CusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CusID"));

                    b.Property<string>("CusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CusID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApplication4.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication4.Model.Product", b =>
                {
                    b.Property<int>("Proid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Proid"));

                    b.Property<int>("CateID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryCateID")
                        .HasColumnType("int");

                    b.Property<string>("Prodesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Proid");

                    b.HasIndex("CategoryCateID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApplication4.Model.Order", b =>
                {
                    b.HasOne("WebApplication4.Model.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication4.Model.Product", b =>
                {
                    b.HasOne("WebApplication4.Model.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryCateID");
                });

            modelBuilder.Entity("WebApplication4.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebApplication4.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
