namespace CentroEventos.Aplicacion.Interfaces;

public class ImplementacionServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso (int IdUsuario, IServicioAutorizacion.Permisos Permiso)
    {
        if (IdUsuario == 1)
        {
            return true;
        }
        else
            return false;
    }

}

