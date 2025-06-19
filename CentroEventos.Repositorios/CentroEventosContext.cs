namespace CentroEventos.Repositorios;

using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;

public class CentroEventosContext : DbContext
{
  public DbSet<Usuario> Usuarios { get; set; }
  public DbSet<Reserva> Reservas { get; set; }
  public DbSet<EventoDeportivo> Eventos { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=CentroEventos.db");
  }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().Ignore(u => u.Permisos); //ignora la columna permisos
    }
}