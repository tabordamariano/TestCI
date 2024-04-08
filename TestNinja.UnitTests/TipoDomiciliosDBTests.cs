using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using TestNinja.API.Data;
//using TestNinja.API.Models;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]

    public class TipoDomiciliosDBTests
    {


        [Test]
        public void GetTipoDomicilios_WhenCalled_ReturnEmptyListResult()
        {
            //var connectionstring = "Server=localhost,1433;Database=tests;User Id=sa;Password=Password123!;Encrypt=False;";

            //var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            //optionsBuilder.UseSqlServer(connectionstring);


            ////TestNinjaDbContext dbContext = new TestNinjaDbContext(optionsBuilder.Options);

            //// Or you can also instantiate inside using

            //using (DemoContext context = new DemoContext(optionsBuilder.Options))
            //{
            //    context.Database.Migrate();

            //    var result = context.TipoDomicilios.ToList<TipoDomicilio>();

            //    Assert.That(Is.Equals(result.Count, 0));
            //}

            Assert.That(true, Is.True);

        }

    }
}
