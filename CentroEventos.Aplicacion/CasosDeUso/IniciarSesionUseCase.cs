namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class IniciarSesionUseCase(ISesionUsuario repoSesion)
{
    public void Ejecutar(Usuario datosUsuario)
    {

        repoSesion.IniciarSesion(datosUsuario);
    }


}