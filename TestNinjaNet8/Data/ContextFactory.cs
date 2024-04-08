using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<TestNinjaDbContext>
    {
        public TestNinjaDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TestNinjaDbContext> builder = new();
            builder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=tests;user id=sa ;pwd=Password123!;TrustServerCertificate=true;");
            return new TestNinjaDbContext(builder.Options);
        }
    }
}
