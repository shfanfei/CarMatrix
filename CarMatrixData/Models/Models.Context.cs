﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarMatrixData.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelsContainer : DbContext
    {
        public ModelsContainer()
            : base("name=CMDatabaseConnectionString")
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(c => c.Brands).WithRequired(b => b.Company);
            modelBuilder.Entity<Company>().HasMany(c => c.Car).WithRequired(c => c.Company);
            modelBuilder.Entity<Company>().HasMany(c => c.CarModel).WithRequired(c => c.Company);
            modelBuilder.Entity<Brands>().HasMany(b => b.Car).WithRequired(c => c.Brands);
            modelBuilder.Entity<CarModel>().HasMany(c => c.Car).WithRequired(c => c.CarModel);
            modelBuilder.Entity<Order>().HasRequired(o => o.Car).WithMany().HasForeignKey(o => o.CarId);
            modelBuilder.Entity<Person>().HasMany(p => p.Order).WithRequired(o => o.Person);
        }

        public DbSet<Company> CompanySet { get; set; }
        public DbSet<Brands> BrandsSet { get; set; }
        public DbSet<CarModel> CarModelSet { get; set; }
        public DbSet<Car> CarSet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
        public DbSet<Person> PersonSet { get; set; }
        public DbSet<Record> RecordSet { get; set; }
    }
}
