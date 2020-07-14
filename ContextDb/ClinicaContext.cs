using ApiPronutrir.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPronutrir.ContextDb
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios {get; set;}
        public DbSet<Medicamentos> Medicamentos {get; set;}
        public DbSet<Categorias> categorias {get; set;}

    }
}