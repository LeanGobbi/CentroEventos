namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ListarEventosConCupoDisponibleUseCase (IRepositorioEventoDeportivo repo) {
    public List <EventoDeportivo> Ejecutar ()
    {
       return repo.ListarEventosConCupoDisponible();
    }
}
