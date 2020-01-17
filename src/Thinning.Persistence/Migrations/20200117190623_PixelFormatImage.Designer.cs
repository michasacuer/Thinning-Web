﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thinning.Persistence;

namespace Thinning.Persistence.Migrations
{
    [DbContext(typeof(ThinningDbContext))]
    [Migration("20200117190623_PixelFormatImage")]
    partial class PixelFormatImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Thinning.Domain.Algorithm", b =>
                {
                    b.Property<int>("AlgorithmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlgorithmId");

                    b.ToTable("Algorithms");
                });

            modelBuilder.Entity("Thinning.Domain.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlgorithmId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("OriginalBpp")
                        .HasColumnType("int");

                    b.Property<int>("OriginalHeight")
                        .HasColumnType("int");

                    b.Property<int>("OriginalWidth")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<bool>("TestImage")
                        .HasColumnType("bit");

                    b.Property<int?>("TestLineId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("AlgorithmId");

                    b.HasIndex("TestId");

                    b.HasIndex("TestLineId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Thinning.Domain.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivationStatusCode")
                        .HasColumnType("int");

                    b.Property<string>("ActivationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Sent")
                        .HasColumnType("datetime2");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Thinning.Domain.TestLine", b =>
                {
                    b.Property<int>("TestLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlgorithmId")
                        .HasColumnType("int");

                    b.Property<double>("AvgExecutionTime")
                        .HasColumnType("float");

                    b.Property<int>("Iterations")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("TestLineId");

                    b.HasIndex("AlgorithmId");

                    b.HasIndex("TestId");

                    b.ToTable("TestLines");
                });

            modelBuilder.Entity("Thinning.Domain.TestPcInfo", b =>
                {
                    b.Property<int>("TestPcInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("TestPcInfoId");

                    b.HasIndex("TestId");

                    b.ToTable("TestPcInfos");
                });

            modelBuilder.Entity("Thinning.Domain.TestRun", b =>
                {
                    b.Property<int>("TestRunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RunCount")
                        .HasColumnType("int");

                    b.Property<int>("TestLinesId")
                        .HasColumnType("int");

                    b.Property<double>("Time")
                        .HasColumnType("float");

                    b.HasKey("TestRunId");

                    b.HasIndex("TestLinesId");

                    b.ToTable("TestRuns");
                });

            modelBuilder.Entity("Thinning.Domain.Image", b =>
                {
                    b.HasOne("Thinning.Domain.Algorithm", "Algorithm")
                        .WithMany("Images")
                        .HasForeignKey("AlgorithmId");

                    b.HasOne("Thinning.Domain.Test", "Test")
                        .WithMany("Images")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Thinning.Domain.TestLine", "TestLine")
                        .WithMany("Images")
                        .HasForeignKey("TestLineId");
                });

            modelBuilder.Entity("Thinning.Domain.TestLine", b =>
                {
                    b.HasOne("Thinning.Domain.Algorithm", "Algorithm")
                        .WithMany()
                        .HasForeignKey("AlgorithmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Thinning.Domain.Test", "Test")
                        .WithMany("TestLines")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Thinning.Domain.TestPcInfo", b =>
                {
                    b.HasOne("Thinning.Domain.Test", "Test")
                        .WithMany("TestPcInfos")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Thinning.Domain.TestRun", b =>
                {
                    b.HasOne("Thinning.Domain.TestLine", "TestLines")
                        .WithMany("TestRuns")
                        .HasForeignKey("TestLinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
