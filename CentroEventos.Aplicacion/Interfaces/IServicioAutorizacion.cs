namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
public enum Permisos {EventoAlta, EventoModificacion, EventoBaja, ReservaAlta, ReservaModificacion, ReservaBaja, UsuarioAlta, UsuarioModificacion, UsuarioBaja};
bool PoseeElPermiso(int IdUsuario, Permisos permiso);
}