namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ListarAsistenciaAEventoUseCase (IRepositorioUsuario repo) {
    public List<Usuario> Ejecutar(int idEvento)
    {

       return repo.ListarAsistenciaAEvento(idEvento);
    }
}