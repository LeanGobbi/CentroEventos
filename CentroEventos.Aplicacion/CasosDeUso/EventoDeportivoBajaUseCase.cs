namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class EventoDeportivoBajaUseCase (IRepositorioEventoDeportivo repo, EventoDeportivoValidador validadorE, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar (int idEvento, int idUsuario)
    {
        string mensajeError;
        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.EventoBaja;
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación.";
            throw new FalloAutorizacionException(mensajeError);
        }

        if (!validadorE.ValidarReservasAsociadas(idEvento, out mensajeError))
        {
            throw new OperacionInvalidaException(mensajeError);
        }

        repo.EliminarEventoDeportivo(idEvento);
    }
}




