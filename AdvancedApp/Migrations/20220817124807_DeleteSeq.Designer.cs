// <auto-generated />
using System;
using AdvancedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdvancedApp.Migrations
{
    [DbContext(typeof(AdvancedContext))]
    [Migration("20220817124807_DeleteSeq")]
    partial class DeleteSeq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvancedApp.Models.Employee", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FamilyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(8,2)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("SSN", "FirstName", "FamilyName");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AdvancedApp.Models.SecondaryIdentity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("InActiveUse")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PrimaryFamilyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimaryFirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimarySSN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PrimarySSN", "PrimaryFirstName", "PrimaryFamilyName")
                        .IsUnique()
                        .HasFilter("[PrimarySSN] IS NOT NULL AND [PrimaryFirstName] IS NOT NULL AND [PrimaryFamilyName] IS NOT NULL");

                    b.ToTable("SecondaryIdentity");
                });

            modelBuilder.Entity("AdvancedApp.Models.SecondaryIdentity", b =>
                {
                    b.HasOne("AdvancedApp.Models.Employee", "PrimaryIdentity")
                        .WithOne("OtherIdentity")
                        .HasForeignKey("AdvancedApp.Models.SecondaryIdentity", "PrimarySSN", "PrimaryFirstName", "PrimaryFamilyName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("PrimaryIdentity");
                });

            modelBuilder.Entity("AdvancedApp.Models.Employee", b =>
                {
                    b.Navigation("OtherIdentity");
                });
#pragma warning restore 612, 618
        }
    }
}
