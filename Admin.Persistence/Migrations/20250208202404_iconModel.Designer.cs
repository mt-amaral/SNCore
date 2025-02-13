﻿// <auto-generated />
using System;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admin.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250208202404_iconModel")]
    partial class iconModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Admin.Domain.Entities.Host", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Ipv4")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ModelId");

                    b.ToTable("Host");
                });

            modelBuilder.Entity("Admin.Domain.Entities.HostGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("HostGroup");
                });

            modelBuilder.Entity("Admin.Domain.Entities.HostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SrcIcon")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("HostModel");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<long?>("OidId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("OidId")
                        .IsUnique()
                        .HasFilter("[OidId] IS NOT NULL");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Admin.Domain.Entities.OidDiscovery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("DiscoveryOriginId")
                        .HasColumnType("bigint");

                    b.Property<string>("OidDiscoveryIndex")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("DiscoveryOriginId")
                        .IsUnique()
                        .HasFilter("[DiscoveryOriginId] IS NOT NULL");

                    b.ToTable("OidDiscovery");
                });

            modelBuilder.Entity("Admin.Domain.Entities.OidList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Oid")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("OidList");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Snmp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Community")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<short>("SnmpVersion")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HostId")
                        .IsUnique();

                    b.ToTable("Snmp");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Telnet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("HostId")
                        .IsUnique();

                    b.ToTable("Telnet");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Host", b =>
                {
                    b.HasOne("Admin.Domain.Entities.HostGroup", "HostGroup")
                        .WithMany("Hosts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Admin.Domain.Entities.HostModel", "HostModel")
                        .WithMany("Hosts")
                        .HasForeignKey("ModelId");

                    b.Navigation("HostGroup");

                    b.Navigation("HostModel");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Item", b =>
                {
                    b.HasOne("Admin.Domain.Entities.HostModel", "HostModel")
                        .WithMany("Items")
                        .HasForeignKey("ModelId");

                    b.HasOne("Admin.Domain.Entities.OidList", "OidList")
                        .WithOne("Item")
                        .HasForeignKey("Admin.Domain.Entities.Item", "OidId");

                    b.Navigation("HostModel");

                    b.Navigation("OidList");
                });

            modelBuilder.Entity("Admin.Domain.Entities.OidDiscovery", b =>
                {
                    b.HasOne("Admin.Domain.Entities.OidList", "DiscoveryOrigin")
                        .WithOne("OidDiscovery")
                        .HasForeignKey("Admin.Domain.Entities.OidDiscovery", "DiscoveryOriginId");

                    b.Navigation("DiscoveryOrigin");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Snmp", b =>
                {
                    b.HasOne("Admin.Domain.Entities.Host", "Host")
                        .WithOne("Snmp")
                        .HasForeignKey("Admin.Domain.Entities.Snmp", "HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Telnet", b =>
                {
                    b.HasOne("Admin.Domain.Entities.Host", "Host")
                        .WithOne("Telnet")
                        .HasForeignKey("Admin.Domain.Entities.Telnet", "HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Admin.Domain.Entities.Host", b =>
                {
                    b.Navigation("Snmp");

                    b.Navigation("Telnet");
                });

            modelBuilder.Entity("Admin.Domain.Entities.HostGroup", b =>
                {
                    b.Navigation("Hosts");
                });

            modelBuilder.Entity("Admin.Domain.Entities.HostModel", b =>
                {
                    b.Navigation("Hosts");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Admin.Domain.Entities.OidList", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();

                    b.Navigation("OidDiscovery");
                });
#pragma warning restore 612, 618
        }
    }
}
