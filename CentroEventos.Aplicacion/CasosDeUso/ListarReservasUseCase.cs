
namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ListarReservasUseCase (IRepositorioReserva repo) {
    public List <Reserva> Ejecutar ()
    {
       return repo.ListarReservas();
    }
}

