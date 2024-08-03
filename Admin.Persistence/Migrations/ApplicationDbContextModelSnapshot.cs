﻿// <auto-generated />
using System;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admin.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Admin.Domain.Entities.Hardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("HardwareModel")
                        .HasColumnType("smallint");

                    b.Property<string>("Ipv4")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Hardware");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Snmp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnOrder(3);

                    b.Property<string>("Community")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("HardwareId")
                        .HasColumnType("int");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("HardwareId")
                        .IsUnique();

                    b.ToTable("Snmp");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Telnet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int>("HardwareId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("HardwareId")
                        .IsUnique();

                    b.ToTable("Telnet");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Snmp", b =>
                {
                    b.HasOne("Admin.Domain.Entities.Hardware", "Hardware")
                        .WithOne("Snmp")
                        .HasForeignKey("Admin.Domain.Entities.Snmp", "HardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hardware");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Telnet", b =>
                {
                    b.HasOne("Admin.Domain.Entities.Hardware", "Hardware")
                        .WithOne("Telnet")
                        .HasForeignKey("Admin.Domain.Entities.Telnet", "HardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hardware");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Hardware", b =>
                {
                    b.Navigation("Snmp")
                        .IsRequired();

                    b.Navigation("Telnet")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
