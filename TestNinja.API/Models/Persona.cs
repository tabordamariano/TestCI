using Microsoft.AspNetCore.Mvc;

namespace TestNinja.API.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ICollection<Domicilio> Domicilios { get; set; }

       
    }
}

