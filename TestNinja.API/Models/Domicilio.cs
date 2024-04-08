using System.ComponentModel;

namespace TestNinja.API.Models
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int TipoDomicilioId { get; set; }
        public TipoDomicilio TipoDomicilio { get; set; }


    }
}