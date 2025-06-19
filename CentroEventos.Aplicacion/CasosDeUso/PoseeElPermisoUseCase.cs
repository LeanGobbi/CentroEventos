namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;

public class PoseeElPermisoUseCase (IServicioAutorizacion repo) {
    public bool Ejecutar (int idUsuario, IServicioAutorizacion.Permisos Permiso)
    {
       return repo.PoseeElPermiso(idUsuario, Permiso);
    }
}

