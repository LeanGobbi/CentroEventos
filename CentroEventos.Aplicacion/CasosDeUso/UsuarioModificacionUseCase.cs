namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class UsuarioModificacionUseCase(IRepositorioUsuario repo, UsuarioValidador validadorU, IServicioAutorizacion servicioAutorizacion, ISesionUsuario sesionUsuario)
{
    public void Ejecutar(Usuario datosUsuario, int idUsuario)
    {
        string mensajeError;

        IServicioAutorizacion.Permisos permiso = IServicioAutorizacion.Permisos.UsuarioModificacion;

        if (datosUsuario.Id != sesionUsuario.UsuarioActual?.Id)
        {
            if (!servicioAutorizacion.PoseeElPermiso(idUsuario, permiso))
            {
                mensajeError = "ERROR: El usuario no tiene permiso para realizar esta operación. \n";
                throw new FalloAutorizacionException(mensajeError);
            }
        }
        
        if (!validadorU.ValidarFormatoCampos(datosUsuario, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!validadorU.ValidarDuplicacionCampos(datosUsuario, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }
        
        repo.ModificarUsuario(datosUsuario);
    }
}

