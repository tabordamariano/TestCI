using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using TestNinja.API.Data;
using TestNinja.API.Models;
using TestNinja.API.Services;




//using TestNinja.API.Data;
//using TestNinja.API.Models;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Integration
{
    [TestFixture]

    public class PersonasTests
    {


        [Test]
        public async Task GetPersonas_FromService_ReturnListWithPersonas()
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=localhost,1433;Database=tests;User Id=sa;Password=Password123!;Encrypt=False;";
            }

            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            DemoContext dbContext = new DemoContext(optionsBuilder.Options);

            ServicePersonas service = new ServicePersonas(dbContext);
                        
            List<Persona> personas = (List<Persona>)await service.GetPersonas(null);

            var cnt = personas.Count;
            //Verifico que no haya personas
            Assert.That(Is.Equals(personas.Count, cnt));
                        

        }

        [Test]
        public async Task AddPersona_FromService_ReturnListWithNewPersona()
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=localhost,1433;Database=tests;User Id=sa;Password=Password123!;Encrypt=False;";
            }

            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            DemoContext dbContext = new DemoContext(optionsBuilder.Options);

            ServicePersonas service = new ServicePersonas(dbContext);

            List<Persona> personas = (List<Persona>)await service.GetPersonas(null);

            var cnt = personas.Count;
            //Verifico que no haya personas
            Assert.That(Is.Equals(personas.Count, cnt));

            Persona persona = new Persona { Nombre = "Mariano", Apellido = "Taborda", Domicilios = new List<Domicilio>() };

            await service.InsertPersona(persona);

            personas = (List<Persona>)await service.GetPersonas(null);

            //Verifico que haya 1 persona
            Assert.That(Is.Equals(personas.Count, cnt + 1));
        }

        [Test]
        public void GetPersonas_FromEndpoint_ReturnListWithNewPersona()
        {
            string baseurl = Environment.GetEnvironmentVariable("BASE_URL");
            if (baseurl == null)
            {
                baseurl = "http://localhost:8095/";
            }

            int cnt = 0;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "TestNinja");

            //Llamo al servicio para obtener las personas
            var response = client.GetAsync("api/Personas").Result;
            using var contentStream = response.Content.ReadAsStreamAsync().Result;
            var personas = JsonSerializer.DeserializeAsync<List<Persona>>(contentStream).Result;

            cnt = personas.Count;

            //Verifico que no haya personas
            Assert.That(Is.Equals(personas.Count, cnt));

            Persona persona = new Persona { Nombre = "Mariano", Apellido = "Taborda", Domicilios = new List<Domicilio>() };

            //como envio persona en el contenido a la llamada post?
            string? personaJson = JsonSerializer.Serialize(persona);
            var buffer = System.Text.Encoding.UTF8.GetBytes(personaJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Llamo al servicio para ingresar una persona
            response = client.PostAsync("api/Personas", byteContent).Result;


            //vuelvo a buscar las personas y ver que haya 1
            response = client.GetAsync("api/Personas").Result;
            using var contentStream1 = response.Content.ReadAsStreamAsync().Result;
            personas = JsonSerializer.DeserializeAsync<List<Persona>>(contentStream1).Result;

            //Verifico que haya 1 persona
            Assert.That(Is.Equals(personas.Count, cnt + 1));

        }

    }
}
