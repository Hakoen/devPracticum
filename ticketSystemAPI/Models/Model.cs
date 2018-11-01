using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ticketSystemAPI_Models
{
    public class ticketSystemContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; } 
        public DbSet<Company> Company { get; set; } 
        public DbSet<Task> Task { get; set; } 
        public DbSet<EmployeeTask> EmployeeTask { get; set; } 

        public ticketSystemContext(DbContextOptions<ticketSystemContext> options): base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=localhost;Password=;Port=5432;Database=TicketSystem;Userid=postgres");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(t => new {t.EmployeeID, t.TaskID});
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(e => e.Employee)
                .WithMany(t => t.Tasks);
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(t => t.Task)
                .WithMany(e => e.Employees);
        }
    }

    public class Employee
    {
        public int ID { get; set; } 
        public string SSN { get; set; } 
        public string Name { get; set; } 
        
        public List<EmployeeTask> Tasks { get; set; } 
        public int CompanyID { get; set; }

        public Employee (string SSN, string Name, int CompanyID)
        {
            this.SSN = SSN;
            this.Name = Name;
            this.CompanyID = CompanyID;
        }
    }

    public class Company
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public string Address { get; set; } 
        public List<Employee> Employees { get; set; } 
    }

    public class Task
    {
        public int ID { get; set; } 
        public string Description { get; set; } 
        public List<EmployeeTask> Employees { get; set; } 
    }

    public class EmployeeTask
    {
        public Employee Employee { get; set; } 
        public int EmployeeID { get; set; } 
        public Task Task { get; set; } 
        public int TaskID { get; set; } 
    }
}