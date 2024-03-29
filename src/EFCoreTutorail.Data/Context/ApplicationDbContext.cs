﻿using EFCoreTutorail.Data.Models;
using EFCoreTutorial.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorail.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConstants.DbConnectionString);
            }


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Number).HasColumnName("number");
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
                entity.Property(i => i.AddressId).HasColumnName("address_id");

                entity.HasMany(i => i.Books)
                .WithOne(i => i.Student)
                .HasForeignKey(i => i.StudentId)
                .HasConstraintName("student_book_id_fk");



            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.IsActive).HasColumnName("is_active");
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.ToTable("student_addresses");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(i => i.City).HasColumnName("city").HasMaxLength(50);
                entity.Property(i => i.District).HasColumnName("district").HasMaxLength(100);
                entity.Property(i => i.Country).HasColumnName("country").HasMaxLength(50);
                entity.Property(i => i.FullAddress).HasColumnName("full_address").HasMaxLength(1000);

                entity.HasOne(i => i.Student)
                .WithOne(i => i.Address)
                .HasForeignKey<Student>(i => i.AddressId)
                .HasConstraintName("student_address_student_id_fk");


            });






            base.OnModelCreating(modelBuilder);
        }
    }
}
