namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repo, EventoDeportivoValidador validadorE, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(EventoDeportivo datosEvento, int idUsuario)
    {
        string mensajeError;

        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.EventoAlta;
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación. \n";
            throw new FalloAutorizacionException(mensajeError);
        }

        if (!validadorE.ValidarFormatoCampos(datosEvento, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        if (!validadorE.ValidarIdResponsable(datosEvento.ResponsableId, out mensajeError))
        {
            throw new EntidadNotFoundException(mensajeError);
        }
 
        repo.AgregarEventoDeportivo(datosEvento);
    }
}

