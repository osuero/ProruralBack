﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240427184223_adminnistrator")]
    partial class adminnistrator
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Beneficiary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForeign")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OtherPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("Data.Entities.Fund", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Funds");
                });

            modelBuilder.Entity("Data.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PresidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PresidentId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductiveActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Rnc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("PresidentId1");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SectionId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Data.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Data.Entities.ProductionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductionCategories");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ApprovedFirstDisbursement")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FundAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Data.Geographical.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Data.Geographical.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Data.Geographical.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Data.Geographical.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Data.Geographical.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Data.Entities.Beneficiary", b =>
                {
                    b.HasOne("Data.Entities.Organization", null)
                        .WithMany("Beneficiaries")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Data.Entities.Fund", b =>
                {
                    b.HasOne("Data.Entities.Project", "Project")
                        .WithMany("Funds")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.Organization", b =>
                {
                    b.HasOne("Data.Entities.ProductionCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Data.Geographical.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("Data.Entities.Beneficiary", "President")
                        .WithMany()
                        .HasForeignKey("PresidentId1");

                    b.HasOne("Data.Geographical.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.HasOne("Data.Geographical.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("Data.Geographical.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.Navigation("Category");

                    b.Navigation("Place");

                    b.Navigation("President");

                    b.Navigation("Province");

                    b.Navigation("Region");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.HasOne("Data.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.RolePermission", b =>
                {
                    b.HasOne("Data.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Entities.UserRole", b =>
                {
                    b.HasOne("Data.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Geographical.Municipality", b =>
                {
                    b.HasOne("Data.Geographical.Province", null)
                        .WithMany("Municipalities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Geographical.Place", b =>
                {
                    b.HasOne("Data.Geographical.Section", null)
                        .WithMany("Places")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Geographical.Province", b =>
                {
                    b.HasOne("Data.Geographical.Region", null)
                        .WithMany("Provinces")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Geographical.Section", b =>
                {
                    b.HasOne("Data.Geographical.Municipality", null)
                        .WithMany("Sections")
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Organization", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("Data.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.Navigation("Funds");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Data.Geographical.Municipality", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Data.Geographical.Province", b =>
                {
                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("Data.Geographical.Region", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("Data.Geographical.Section", b =>
                {
                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
