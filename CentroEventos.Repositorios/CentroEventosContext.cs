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
        // Ignorar la propiedad Permisos para que EF no intente mapearla a columna
        modelBuilder.Entity<Usuario>().Ignore(u => u.Permisos);

        // No es estrictamente necesario mapear PermisosSerializados si coincide con la propiedad
        // y la columna, pero si querés podés definirlo explícitamente
        // modelBuilder.Entity<Usuario>().Property(u => u.PermisosSerializados).HasColumnName("PermisosSerializados");
    }
}