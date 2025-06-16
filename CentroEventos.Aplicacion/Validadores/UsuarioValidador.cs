namespace CentroEventos.Aplicacion.Validadores;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioValidador(IRepositorioUsuario repoUsuario, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{
    public bool ValidarFormatoCampos(Usuario datosUsuario, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(datosUsuario.Nombre) || string.IsNullOrWhiteSpace(datosUsuario.Apellido) || string.IsNullOrWhiteSpace(datosUsuario.Email))
        {
            mensajeError = "ERROR: Los campos nombre, apellido y email son obligatorios y deben completarse. Intente nuevamente. \n";
        }

        if (!datosUsuario.Nombre.All(char.IsLetter))
        {
            mensajeError += "ERROR: El nombre de usuario ingresado es invalido. Intente nuevamente. \n";
        }

        if (!datosUsuario.Apellido.All(char.IsLetter))
        {
            mensajeError += "ERROR: El apellido del usuario ingresado es invalido. Intente nuevamente. \n";
        }

        if (!datosUsuario.Email.Contains("@") || (!datosUsuario.Email.Contains(".")))
        {
            mensajeError += "ERROR: El email ingresado es invalido. Intente nuevamente. \n";
        }
        return mensajeError == "";
    }
    
     public bool ValidarDuplicacionCampos(Usuario datosUsuario, out string mensajeError)
    {
        mensajeError = "";
        var listarUsuarios = new ListarUsuariosUseCase(repoUsuario);
        var listaU = listarUsuarios.Ejecutar();
        foreach (Usuario u in listaU)
        {
            if (u.Email == datosUsuario.Email)
            {
                if (u.Id != datosUsuario.Id)
                {
                    mensajeError += "ERROR: El email ingresado ya se encuentra en uso en el sistema. Debe ser único. \n";
                }
            }
        }
        return mensajeError == "";
    }
    
    public bool ValidarEventosYReservasAsociadas(int idUsuario, out string mensajeError)
    {
        mensajeError = "";
        var listaEventos = repoEvento.ListarEventosDeportivos();
        foreach (EventoDeportivo e in listaEventos)
        {
            if (e.ResponsableId == idUsuario)
            {
                mensajeError = "ERROR: No es posible eliminar la persona ya que existen eventos deportivos asociadas a ella. Intente nuevamente. \n";
            }
        }

        var listaReservas = repoReserva.ListarReservas();
        foreach (Reserva r in listaReservas)
        {
            if (r.PersonaId == idUsuario)
            {
                mensajeError += "ERROR: No es posible eliminar la persona ya que existen reservas a eventos deportivos asociadas a ella. Intente nuevamente. \n";
            }
        }
        return mensajeError == "";
    }
}