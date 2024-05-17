﻿// <auto-generated />
using System;
using Maxsociety.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace maxsociety.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Maxsociety.Models.VisitorLogs", b =>
                {
                    b.Property<long>("VisitorLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitorLogId"));

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitStatus")
                        .HasColumnType("int");

                    b.Property<long?>("VisitorId")
                        .HasColumnType("bigint");

                    b.HasKey("VisitorLogId");

                    b.HasIndex("VisitorId");

                    b.ToTable("VisitorLogs");
                });

            modelBuilder.Entity("Maxsociety.Models.Visitors", b =>
                {
                    b.Property<long>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VisitorId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FlatNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("ResidentName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisitPurpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Maxsociety.Models.VisitorLogs", b =>
                {
                    b.HasOne("Maxsociety.Models.Visitors", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId");

                    b.Navigation("Visitor");
                });
#pragma warning restore 612, 618
        }
    }
}
