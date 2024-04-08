using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;
using TestNinja.Models;

namespace TestNinja.Data
{
    public class TestNinjaDbContext : DbContext
    {
        public DbSet<Country> Countrys { get; set; }

        public TestNinjaDbContext(DbContextOptions<TestNinjaDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            //schema
            //modelBuilder.HasDefaultSchema("tenencias");


        }
    }
}
