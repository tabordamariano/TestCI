using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TestNinja.API.Data;
using TestNinja.API.Models;

namespace TestNinja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly DemoContext _context;

        public PersonasController(DemoContext context)
        {
            _context = context;
        }

        // GET: Personas
        [HttpGet(Name = "Personas")]

        public async Task<IResult> GetPersonas([FromQuery] int? id)
        {
            if (id == null)
            {
                var result = await _context.Personas.ToListAsync();
                return Results.Ok(result);
            }
            else {
                var result = await _context.Personas.Include(p => p.Domicilios).Where(p => p.Id.Equals(id)).FirstAsync();
                return Results.Ok(result);
            }
        }

        [HttpPost("Update")]
        //[Route("api/UpdatePersona")]
        //[ValidateAntiForgeryToken]
        public async Task<IResult> EditPersona([FromBody] Persona persona)
        {
            try
            {
                _context.Update(persona);
                await _context.SaveChangesAsync();
                return Results.Ok(persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Results.NotFound();           
            }
               
        }



        //// GET: Personas
        //[HttpGet(Name = "GetPersonas")]

        //public async Task<IResult> GetPersonas()
        //{
        //    var result = await _context.Personas.ToListAsync();
        //    return Results.Ok(result);
        //}

        //// GET: Personas
        //[HttpGet(Name = "GetPersona")]
        //public async Task<IResult> GetPersona([FromQuery] int idPersona)
        //{
        //    var result = await _context.Personas.Where(p => p.Id.Equals(idPersona)).FirstAsync();
        //    return Results.Ok(result);
        //}

        //// GET: Personas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var persona = await _context.Personas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(persona);
        //}

        // GET: Personas/Create
        //public IResult Create()
        //{
        //    return View();
        //}

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost(Name = "CreatePersona")]
        //[ValidateAntiForgeryToken]
        public async Task<IResult> Create([Bind("Nombre,Apellido")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                var response = await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Results.Ok(response);
            }
            return Results.Problem("Error al crear la persona.");
        }

            //// GET: Personas/Edit/5
            //public async Task<IActionResult> Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var persona = await _context.Personas.FindAsync(id);
            //    if (persona == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(persona);
            //}

            //// POST: Personas/Edit/5
            //// To protect from overposting attacks, enable the specific properties you want to bind to.
            //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] Persona persona)
            //{
            //    if (id != persona.Id)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(persona);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!PersonaExists(persona.Id))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(persona);
            //}

            //// GET: Personas/Delete/5
            //public async Task<IActionResult> Delete(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var persona = await _context.Personas
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (persona == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(persona);
            //}

            //// POST: Personas/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(int id)
            //{
            //    var persona = await _context.Personas.FindAsync(id);
            //    if (persona != null)
            //    {
            //        _context.Personas.Remove(persona);
            //    }

            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //private bool PersonaExists(int id)
            //{
            //    return _context.Personas.Any(e => e.Id == id);
            //}
        }
}
