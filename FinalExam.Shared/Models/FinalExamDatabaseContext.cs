﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalExam.Shared.Models
{
    public partial class FinalExamDatabaseContext : DbContext
    {
        public FinalExamDatabaseContext()
        {
        }

        public FinalExamDatabaseContext(DbContextOptions<FinalExamDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentMark> StudentMark { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=FinalExam.Database;Integrated Security=true");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}