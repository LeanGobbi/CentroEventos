namespace CentroEventos.Aplicacion.CasosDeUso;

using CentroEventos.Aplicacion.Interfaces;

public class PrimerUsuarioUseCase(IRepositorioUsuario repo)
{
    public bool Ejecutar()
    {
        return repo.PrimerUsuario();
    }
}

