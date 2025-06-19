using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;
public class ImplementacionSesionUsuario : ISesionUsuario
{
    private Usuario? _usuarioActual;
    public Usuario? UsuarioActual => _usuarioActual;
    public bool UsuarioLogueado => _usuarioActual != null;
    public void IniciarSesion(Usuario usuario)
   {
       _usuarioActual = usuario;

   }
   public void CerrarSesion()
   {
       _usuarioActual = null;

   }

}
