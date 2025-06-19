namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class UsuarioActualUseCase(ISesionUsuario repoSesion)
{
    public Usuario? Ejecutar()
    {

       return repoSesion.UsuarioActual;
    }


}