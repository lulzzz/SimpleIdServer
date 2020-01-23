﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleIdServer.Scim.Persistence.EF;

namespace SimpleIdServer.Scim.Migrations.SqlServer.Migrations
{
    [DbContext(typeof(SCIMDbContext))]
    partial class SCIMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("ExternalId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("ResourceType");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("SCIMRepresentationLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentationAttribute", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ParentId");

                    b.Property<string>("SCIMRepresentationId");

                    b.Property<string>("SchemaAttributeId");

                    b.Property<string>("ValuesBoolean");

                    b.Property<string>("ValuesDateTime");

                    b.Property<string>("ValuesInteger");

                    b.Property<string>("ValuesReference");

                    b.Property<string>("ValuesString");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SCIMRepresentationId");

                    b.HasIndex("SchemaAttributeId");

                    b.ToTable("SCIMRepresentationAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchema", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsRootSchema");

                    b.Property<string>("Name");

                    b.Property<string>("ResourceType");

                    b.Property<string>("SCIMRepresentationId");

                    b.HasKey("Id");

                    b.HasIndex("SCIMRepresentationId");

                    b.ToTable("SCIMSchemaLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CanonicalValues");

                    b.Property<bool>("CaseExact");

                    b.Property<string>("DefaultValueInt");

                    b.Property<string>("DefaultValueString");

                    b.Property<string>("Description");

                    b.Property<bool>("MultiValued");

                    b.Property<int>("Mutability");

                    b.Property<string>("Name");

                    b.Property<string>("ReferenceTypes");

                    b.Property<bool>("Required");

                    b.Property<int>("Returned");

                    b.Property<string>("SCIMSchemaAttributeId");

                    b.Property<string>("SCIMSchemaId");

                    b.Property<int>("Type");

                    b.Property<int>("Uniqueness");

                    b.HasKey("Id");

                    b.HasIndex("SCIMSchemaAttributeId");

                    b.HasIndex("SCIMSchemaId");

                    b.ToTable("SCIMSchemaAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaExtension", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Required");

                    b.Property<string>("SCIMSchemaId");

                    b.Property<string>("Schema");

                    b.HasKey("Id");

                    b.HasIndex("SCIMSchemaId");

                    b.ToTable("SCIMSchemaExtension");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentationAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMRepresentationAttribute", "Parent")
                        .WithMany("Values")
                        .HasForeignKey("ParentId");

                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMRepresentation")
                        .WithMany("Attributes")
                        .HasForeignKey("SCIMRepresentationId");

                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", "SchemaAttribute")
                        .WithMany()
                        .HasForeignKey("SchemaAttributeId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchema", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMRepresentation")
                        .WithMany("Schemas")
                        .HasForeignKey("SCIMRepresentationId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute")
                        .WithMany("SubAttributes")
                        .HasForeignKey("SCIMSchemaAttributeId");

                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchema")
                        .WithMany("Attributes")
                        .HasForeignKey("SCIMSchemaId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaExtension", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchema")
                        .WithMany("SchemaExtensions")
                        .HasForeignKey("SCIMSchemaId");
                });
#pragma warning restore 612, 618
        }
    }
}
