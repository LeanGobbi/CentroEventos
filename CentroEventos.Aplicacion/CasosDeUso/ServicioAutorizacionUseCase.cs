namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;

public class ServicioAutorizacionUseCase (IServicioAutorizacion repo) {
    public void Ejecutar (int idUsuario, IServicioAutorizacion.Permisos Permiso)
    {
        repo.PoseeElPermiso(idUsuario, Permiso);
    }
}

