﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LargeDataSetMvc.Model
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentDeptEmp> CurrentDeptEmps { get; set; } = null!;
        public virtual DbSet<CurrentEmployee> CurrentEmployees { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DeptEmp> DeptEmps { get; set; } = null!;
        public virtual DbSet<DeptEmpLatestDate> DeptEmpLatestDates { get; set; } = null!;
        public virtual DbSet<DeptManager> DeptManagers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("username=LeeTrent;password=qbcp4Po0@he$;host=127.0.0.1;port=3306;database=employees;pooling=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.38-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<CurrentDeptEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("current_dept_emp");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .HasColumnName("dept_no")
                    .IsFixedLength();

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");
            });

            modelBuilder.Entity<CurrentEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("current_employees");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(14)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PRIMARY");

                entity.ToTable("departments");

                entity.HasIndex(e => e.DeptName, "dept_name")
                    .IsUnique();

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .HasColumnName("dept_no")
                    .IsFixedLength();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(40)
                    .HasColumnName("dept_name");
            });

            modelBuilder.Entity<DeptEmp>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("dept_emp");

                entity.HasIndex(e => e.DeptNo, "dept_no");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .HasColumnName("dept_no")
                    .IsFixedLength();

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_emp_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_emp_ibfk_1");
            });

            modelBuilder.Entity<DeptEmpLatestDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("dept_emp_latest_date");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("dept_manager");

                entity.HasIndex(e => e.DeptNo, "dept_no");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .HasColumnName("dept_no")
                    .IsFixedLength();

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_manager_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_manager_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PRIMARY");

                entity.ToTable("employees");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("emp_no");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(14)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasColumnType("enum('M','F')")
                    .HasColumnName("gender");

                entity.Property(e => e.HireDate).HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("salaries");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.Salary1)
                    .HasColumnType("int(11)")
                    .HasColumnName("salary");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("salaries_ibfk_1");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.Title1, e.FromDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("titles");

                entity.Property(e => e.EmpNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("emp_no");

                entity.Property(e => e.Title1)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("titles_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
