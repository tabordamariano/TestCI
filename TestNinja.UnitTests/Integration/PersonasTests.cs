using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using TestNinja.API.Models;



//using TestNinja.API.Data;
//using TestNinja.API.Models;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Integration
{
    [TestFixture]

    public class PersonasTests
    {


        [Test]
        public void GetPersonas_WhenCalled_ReturnEmptyListResult()
        {
            string baseurl = Environment.GetEnvironmentVariable("BASE_URL");
            if (baseurl == null)
            {
                baseurl = "http://localhost:8095/";
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);  
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "TestNinja");

            
            var response = client.GetAsync("api/Personas").Result;

            using var contentStream = response.Content.ReadAsStreamAsync().Result;
            var personas = JsonSerializer.DeserializeAsync<List<Persona>>(contentStream).Result;

            
            Assert.That(Is.Equals(personas.Count, 0));

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
