namespace CentroEventos.Aplicacion.Interfaces;

public class ImplementacionServicioAutorizacion(IRepositorioUsuario repoUsuario) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, IServicioAutorizacion.Permisos Permiso)
    {
        var usuario = repoUsuario.ListarUsuarios().FirstOrDefault(u => u.Id == IdUsuario);

        return usuario.Permisos.Contains(Permiso);

    }

}

