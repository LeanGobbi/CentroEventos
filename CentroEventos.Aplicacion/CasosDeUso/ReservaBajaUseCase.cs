namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class ReservaBajaUseCase (IRepositorioReserva repo, ReservaValidador validadorR, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar (int idReserva, int idUsuario)
    {
       string mensajeError;
       IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.ReservaBaja;
       if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación.";
            throw new FalloAutorizacionException(mensajeError);
        }

        repo.EliminarReserva(idReserva);
    }
}



