namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validadorE, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar(EventoDeportivo datosEvento, int idUsuario)
    {
        string mensajeError;

        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.EventoModificacion;
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación.";
            throw new FalloAutorizacionException(mensajeError);
        }

        if (!validadorE.ValidarFechaPasadaEvento(datosEvento.Id, out mensajeError))
        {
            throw new OperacionInvalidaException(mensajeError);
        }

        if (!validadorE.ValidarFormatoCampos(datosEvento, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        repo.ModificarEventoDeportivo(datosEvento);
    }
}

