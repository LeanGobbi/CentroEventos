using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva datosReserva);
    void EliminarReserva(int idReserva);
    void ModificarReserva(Reserva datosReserva);
    List<Reserva> ListarReservas();
}
