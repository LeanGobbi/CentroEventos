namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;

public class CerrarSesionUseCase(ISesionUsuario repoSesion)
{
    public void Ejecutar()
    {

        repoSesion.CerrarSesion();
    }


}