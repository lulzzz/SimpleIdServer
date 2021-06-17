﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleIdServer.Scim.Persistence.EF;

namespace SimpleIdServer.Scim.SqlServer.Startup.Migrations
{
    [DbContext(typeof(SCIMDbContext))]
    partial class SCIMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMAttributeMappingModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SourceAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAttributeSelector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceValueAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SCIMAttributeMappingLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RepresentationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchemaAttributeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("RepresentationId");

                    b.HasIndex("SchemaAttributeId");

                    b.ToTable("SCIMRepresentationAttributeLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeValueModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SCIMRepresentationAttributeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("ValueBoolean")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ValueByte")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ValueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ValueDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ValueInteger")
                        .HasColumnType("int");

                    b.Property<string>("ValueReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SCIMRepresentationAttributeId");

                    b.ToTable("SCIMRepresentationAttributeValueLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SCIMRepresentationLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationSchemaModel", b =>
                {
                    b.Property<string>("SCIMSchemaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SCIMRepresentationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SCIMSchemaId", "SCIMRepresentationId");

                    b.HasIndex("SCIMRepresentationId");

                    b.ToTable("SCIMRepresentationSchemaLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaAttributeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CanonicalValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CaseExact")
                        .HasColumnType("bit");

                    b.Property<string>("DefaultValueInt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultValueString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MultiValued")
                        .HasColumnType("bit");

                    b.Property<int>("Mutability")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReferenceTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<int>("Returned")
                        .HasColumnType("int");

                    b.Property<string>("SchemaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Uniqueness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SchemaId");

                    b.ToTable("SCIMSchemaAttributeModel");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaExtensionModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<string>("SCIMSchemaModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Schema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SCIMSchemaModelId");

                    b.ToTable("SCIMSchemaExtensionModel");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRootSchema")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SCIMSchemaLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeModel", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeModel", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationModel", "Representation")
                        .WithMany("Attributes")
                        .HasForeignKey("RepresentationId");

                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaAttributeModel", "SchemaAttribute")
                        .WithMany("RepresentationAttributes")
                        .HasForeignKey("SchemaAttributeId");

                    b.Navigation("Parent");

                    b.Navigation("Representation");

                    b.Navigation("SchemaAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeValueModel", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeModel", "RepresentationAttribute")
                        .WithMany("Values")
                        .HasForeignKey("SCIMRepresentationAttributeId");

                    b.Navigation("RepresentationAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationSchemaModel", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationModel", "Representation")
                        .WithMany("Schemas")
                        .HasForeignKey("SCIMRepresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaModel", "Schema")
                        .WithMany("Representations")
                        .HasForeignKey("SCIMSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representation");

                    b.Navigation("Schema");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaAttributeModel", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaAttributeModel", "ParentAttribute")
                        .WithMany("SubAttributes")
                        .HasForeignKey("ParentId");

                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaModel", "Schema")
                        .WithMany("Attributes")
                        .HasForeignKey("SchemaId");

                    b.Navigation("ParentAttribute");

                    b.Navigation("Schema");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaExtensionModel", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaModel", null)
                        .WithMany("SchemaExtensions")
                        .HasForeignKey("SCIMSchemaModelId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationAttributeModel", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Values");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMRepresentationModel", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Schemas");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaAttributeModel", b =>
                {
                    b.Navigation("RepresentationAttributes");

                    b.Navigation("SubAttributes");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Persistence.EF.Models.SCIMSchemaModel", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Representations");

                    b.Navigation("SchemaExtensions");
                });
#pragma warning restore 612, 618
        }
    }
}
