﻿// <auto-generated />
using System;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190523203446_Questions")]
    partial class Questions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("DataAccessLayer.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<bool>("IsHealthy");

                    b.Property<bool>("IsInGame");

                    b.Property<string>("Name");

                    b.Property<int>("Salary");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateInsert");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}