﻿// <auto-generated />
using System;
using CreateAnAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CreateAnAPI.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    partial class TodoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CreateAnAPI.Data.Todo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDone");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("CreateAnAPI.Models.TodoList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ListTitle");

                    b.Property<int?>("TodoesID");

                    b.HasKey("ID");

                    b.HasIndex("TodoesID");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("CreateAnAPI.Models.TodoList", b =>
                {
                    b.HasOne("CreateAnAPI.Data.Todo", "Todoes")
                        .WithMany()
                        .HasForeignKey("TodoesID");
                });
#pragma warning restore 612, 618
        }
    }
}
