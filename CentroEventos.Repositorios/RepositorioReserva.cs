namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioReserva : IRepositorioReserva
{
    public void AgregarReserva(Reserva datosReserva)
    {
        using var context = new CentroEventosContext();
        context.Add(datosReserva);
        context.SaveChanges();
    }

    public void EliminarReserva(int idReserva)
    {
      using var context = new CentroEventosContext();
      var reserva = new Reserva { Id = idReserva };
      context.Remove(reserva);
      context.SaveChanges();
    }

    public void ModificarReserva(Reserva datosReserva)
    {
      using var context = new CentroEventosContext();
      context.Update(datosReserva);
      context.SaveChanges();
    }
    
    public List<Reserva> ListarReservas()
    {
        using var context = new CentroEventosContext();
        return context.Reservas.ToList();
    }

}
