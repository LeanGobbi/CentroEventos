namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo 
{

    public void AgregarEventoDeportivo(EventoDeportivo datosEvento)
    {
        using var context = new CentroEventosContext();
        context.Add(datosEvento);
        context.SaveChanges();
    }

    public void EliminarEventoDeportivo(int idEvento)
    {
      using var context = new CentroEventosContext();
      var evento = new EventoDeportivo { Id = idEvento };
      context.Remove(evento);
      context.SaveChanges();
    }

    public void ModificarEventoDeportivo(EventoDeportivo datosEvento)
    {
      using var context = new CentroEventosContext();
      context.Update(datosEvento);
      context.SaveChanges();
    }

    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using var context = new CentroEventosContext();
        return context.Eventos.ToList();
    }

    public List<EventoDeportivo> ListarEventosConCupoDisponible()
    {
        return null;
    }
 
    
}
