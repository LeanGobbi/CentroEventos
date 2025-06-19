namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;

public class UsuarioLogueadoUseCase(ISesionUsuario repoSesion)
{
    public bool Ejecutar()
    {

       return repoSesion.UsuarioLogueado;
    }


}