
using Microsoft.EntityFrameworkCore;

namespace TestNinja.API.Data
{
    public class DemoContext : DbContext
    {
        public DbSet<Models.Persona> Personas { get; set; }
        public DbSet<Models.Domicilio> Domicilios { get; set; }
        public DbSet<Models.TipoDomicilio> TipoDomicilios { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DemoEF;User Id=sa;Password=Password123!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            //schema
            modelBuilder.HasDefaultSchema("demo");

            //Ignoro esta propiedad que no debe ir a la base, es solo la imputacion de los asientos que se debe pedir
            //modelBuilder.Entity<TesoreriaMov>().Ignore(c => c.asientos);


        }
    }
        
}
