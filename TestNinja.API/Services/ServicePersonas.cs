using Microsoft.EntityFrameworkCore;

using TestNinja.API.Data;
using TestNinja.API.Models;

namespace TestNinja.API.Services
{
    
    public class ServicePersonas
    {
        private readonly DemoContext _context;

        public ServicePersonas( DemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetPersonas(int? id)
        {
            if (id == null)
            {
                var result = await _context.Personas.ToListAsync();
                return result;
            }
            else
            {
                var result = await _context.Personas.Include(p => p.Domicilios).Where(p => p.Id.Equals(id)).FirstAsync();
                return (IEnumerable<Persona>)result;
            }
        }

        public async Task<bool> InsertPersona(Persona persona)
        {
            try
            {
                _context.Add(persona);
                var response = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
