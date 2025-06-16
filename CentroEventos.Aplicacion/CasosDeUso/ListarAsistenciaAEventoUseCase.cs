namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;

public class ListarAsistenciaAEventoUseCase (IRepositorioUsuario repo, EventoDeportivoValidador validadorE) {
    public List<Usuario> Ejecutar(int idEvento)
    {
        string mensajeError;
        
        if (!validadorE.ValidarFechaFuturaEvento(idEvento, out mensajeError))
        {
            throw new OperacionInvalidaException(mensajeError);
        }

       return repo.ListarAsistenciaAEvento(idEvento);
    }
}