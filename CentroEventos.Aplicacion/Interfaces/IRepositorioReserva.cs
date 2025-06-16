namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioReserva
{
    void AgregarReserva (Reserva datosReserva);
    void EliminarReserva (int idReserva);
    void ModificarReserva (Reserva datosReserva);
    List<Reserva> ListarReservas();
}
