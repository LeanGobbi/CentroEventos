using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void AgregarUsuario(Usuario datosUsuario);
    void EliminarUsuario(int idUsuario);
    void ModificarUsuario(Usuario datosUsuario);
    List<Usuario> ListarUsuarios();
    List<Usuario> ListarAsistenciaAEvento(int idEvento);
    bool PrimerUsuario();
}
