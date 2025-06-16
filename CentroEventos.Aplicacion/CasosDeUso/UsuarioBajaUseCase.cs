namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class UsuarioBajaUseCase(IRepositorioUsuario repo, UsuarioValidador validadorU, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuarioo, int idUsuario)
    {
        string mensajeError;
        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.UsuarioBaja;
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
        {
            mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación.";
            throw new FalloAutorizacionException(mensajeError);
        }
        
        if (!validadorU.ValidarEventosYReservasAsociadas(idUsuarioo, out mensajeError))
        {
            throw new OperacionInvalidaException(mensajeError);
        }
        
        repo.EliminarUsuario(idUsuarioo);
    }
}

