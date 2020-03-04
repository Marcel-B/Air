﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using com.b_velop.Stack.Air.Data;

namespace com.b_velop.Stack.Air.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.Sensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ValueTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.Time", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.Value", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("MeasureValue")
                        .HasColumnType("float");

                    b.Property<long>("SensorId")
                        .HasColumnType("bigint");

                    b.Property<long>("TimestampId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.HasIndex("TimestampId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.ValueType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Display")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ValueTypes");
                });

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.Sensor", b =>
                {
                    b.HasOne("com.b_velop.Stack.Air.Data.Models.ValueType", "ValueType")
                        .WithMany()
                        .HasForeignKey("ValueTypeId");
                });

            modelBuilder.Entity("com.b_velop.Stack.Air.Data.Models.Value", b =>
                {
                    b.HasOne("com.b_velop.Stack.Air.Data.Models.Sensor", "Sensor")
                        .WithMany("Values")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("com.b_velop.Stack.Air.Data.Models.Time", "Timestamp")
                        .WithMany("Values")
                        .HasForeignKey("TimestampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
