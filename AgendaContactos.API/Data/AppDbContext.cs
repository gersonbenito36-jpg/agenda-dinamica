using Microsoft.EntityFrameworkCore;
using AgendaContacto.API.Models;

namespace AgendaContacto.API.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contacto> Contactos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>().ToTable("contactos");
        }
    }
}