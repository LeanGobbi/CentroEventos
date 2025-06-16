
namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ListarUsuariosUseCase (IRepositorioUsuario repo) {
    public List <Usuario> Ejecutar ()
    {
       return repo.ListarUsuarios();
    }
}