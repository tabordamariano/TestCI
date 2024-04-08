using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Data;
using TestNinja.Fundamentals;
using TestNinja.Models;

namespace TestNinja.UnitTests
{
    [TestFixture]

    public class CountryDBTests
    {


        [Test]
        public void GetCountrys_WhenCalled_ReturnEmptyListResult()
        {
            var connectionstring = "Server=localhost,1433;Database=tests;User Id=sa;Password=Password123!;Encrypt=False;";

            var optionsBuilder = new DbContextOptionsBuilder<TestNinjaDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);


            TestNinjaDbContext dbContext = new TestNinjaDbContext(optionsBuilder.Options);

            // Or you can also instantiate inside using

            using (TestNinjaDbContext context = new TestNinjaDbContext(optionsBuilder.Options))
            {
                context.Database.Migrate();

                var result = context.Countrys.ToList<Country>();

                Assert.That(Is.Equals(result.Count, 0));
            }


        }

    }
}
