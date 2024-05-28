﻿// <auto-generated />
using System;
using Foodway.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Foodway.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240527182853_AddClient")]
    partial class AddClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Foodway.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("last_modified_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Foodway.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("last_modified_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Foodway.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("LastModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("last_modified_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("CategoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Foodway.Domain.Entities.Product", b =>
                {
                    b.HasOne("Foodway.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_category_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Foodway.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
