﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StrukturaDrzewiasta.App.Models.DbModels;

#nullable disable

namespace StrukturaDrzewiasta.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230524102835_Custom_Sort")]
    partial class Custom_Sort
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("StrukturaDrzewiasta.App.Models.DbModels.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomSortId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentNodeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentNodeId");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("StrukturaDrzewiasta.App.Models.DbModels.Node", b =>
                {
                    b.HasOne("StrukturaDrzewiasta.App.Models.DbModels.Node", "ParentNode")
                        .WithMany("Nodes")
                        .HasForeignKey("ParentNodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentNode");
                });

            modelBuilder.Entity("StrukturaDrzewiasta.App.Models.DbModels.Node", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}