namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioEventoDeportivo(IRepositorioReserva repoReserva): IRepositorioEventoDeportivo 
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
       using var context = new CentroEventosContext();
      
       var listaEventosFuturos = context.Eventos.Where(e => e.FechaHoraInicio > DateTime.Now).ToList();

       var listaReservas = repoReserva.ListarReservas();

       var contadorReservas = new Dictionary<int, int>();
       
      foreach (Reserva r in listaReservas)
    {
      if (contadorReservas.ContainsKey(r.EventoDeportivoId))
      {
        contadorReservas[r.EventoDeportivoId]++;
      }
      else
      {
        contadorReservas[r.EventoDeportivoId] = 1;
      }
    }

        var listaEventosConCupo = new List<EventoDeportivo>();
        
        foreach (EventoDeportivo e in listaEventosFuturos)
    {
      contadorReservas.TryGetValue(e.Id, out int cantidadReservas);
      if (cantidadReservas < e.CupoMaximo)
      {
        listaEventosConCupo.Add(e);
      }

    }
        return listaEventosConCupo;
    }
  }
 
    

