using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface ISesionUsuario
{
    Usuario? UsuarioActual { get; }

    bool UsuarioLogueado { get; }

    void IniciarSesion(Usuario usuario);

    void CerrarSesion();

}