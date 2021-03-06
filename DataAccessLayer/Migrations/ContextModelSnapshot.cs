﻿// <auto-generated />
using System;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Answer");

                    b.Property<DateTime>("DateInsert");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Text");

                    b.Property<string>("WrongAnswer1");

                    b.Property<string>("WrongAnswer2");

                    b.Property<string>("WrongAnswer3");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
