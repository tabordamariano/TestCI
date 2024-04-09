using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TestNinja.API.Data;
using TestNinja.API.Models;
using TestNinja.API.Services;

namespace TestNinja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ServicePersonas _service;

        public PersonasController(ServicePersonas service)
        {
            _service = service;
        }

        // GET: Personas
        [HttpGet(Name = "Personas")]

        public async Task<IResult> GetPersonas([FromQuery] int? id)
        {
            return Results.Ok(await _service.GetPersonas(id));

        }

        [HttpPost("Update")]
        //[Route("api/UpdatePersona")]
        //[ValidateAntiForgeryToken]
        public async Task<IResult> EditPersona([FromBody] Persona persona)
        {
            try
            {
                bool response = await _service.UpdatePersona(persona);
                if (response == true)
                    return Results.Ok(response);
                else
                    return Results.Problem("Error al modificar la persona.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return Results.NotFound();           
            }               
        }


        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost(Name = "CreatePersona")]
        //[ValidateAntiForgeryToken]
        public async Task<IResult> Create([Bind("Nombre,Apellido")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                bool response = await _service.InsertPersona(persona);
                if (response == true)
                    return Results.Ok(response);
                else
                    return Results.Problem("Error al crear la persona.");
            }
            return Results.Problem("Error al crear la persona.");
        }

          
    }
}
