﻿// <auto-generated />
using System;
using Branch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Branch.Data.Migrations
{
    [DbContext(typeof(BranchContext))]
    [Migration("20190618060258_Branch.Data.BranchContextSeed")]
    partial class BranchDataBranchContextSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Branch.Data.Core.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long>("Modifiedby");

                    b.Property<string>("Password");

                    b.Property<string>("Remarks");

                    b.Property<int>("Status");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 13L,
                            DOB = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uncle.bob@gmail.com",
                            FirstName = "Uncle",
                            IsActive = true,
                            LastName = "Bob",
                            Mobile = "0443434",
                            ModifiedDate = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modifiedby = 1213L,
                            Password = "1233",
                            Remarks = "dsadsd",
                            Status = 12,
                            UserName = "asdsa"
                        },
                        new
                        {
                            Id = 11L,
                            DOB = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uncle.bfdsfdob@gmail.com",
                            FirstName = "fdsfdsf",
                            IsActive = true,
                            LastName = "Bofdsfdsb",
                            Mobile = "0443434",
                            ModifiedDate = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Modifiedby = 1213L,
                            Password = "1233",
                            Remarks = "dsadsd",
                            Status = 12,
                            UserName = "asdsa"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
