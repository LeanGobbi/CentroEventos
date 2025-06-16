namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class ReservaAltaUseCase (IRepositorioReserva repo, ReservaValidador validadorR, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar (Reserva datosReserva, int idUsuario)
    {
        string mensajeError;
        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.ReservaAlta;
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación.";
            throw new FalloAutorizacionException(mensajeError);
        }

        if (!validadorR.ValidarPersonaYEventoAsociados(datosReserva, out mensajeError))
        {
            throw new EntidadNotFoundException(mensajeError);
        }

        if (!validadorR.ValidarDuplicacionReserva(datosReserva, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        if (!validadorR.ValidarCupoMaximoReserva(datosReserva, out mensajeError))
        {
            throw new CupoExcedidoException(mensajeError);
        }
        
        repo.AgregarReserva(datosReserva);
    }
}

