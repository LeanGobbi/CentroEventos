namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo datosEvento);
    void EliminarEventoDeportivo(int idEvento);
    void ModificarEventoDeportivo(EventoDeportivo datosEvento);
    List<EventoDeportivo> ListarEventosDeportivos();
    List<EventoDeportivo> ListarEventosConCupoDisponible();

}
