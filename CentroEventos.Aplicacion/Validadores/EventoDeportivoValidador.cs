namespace CentroEventos.Aplicacion.Validadores;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoValidador(IRepositorioUsuario repoUsuario, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{
    public bool ValidarFormatoCampos(EventoDeportivo datosEvento, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(datosEvento.Nombre) || string.IsNullOrWhiteSpace(datosEvento.Descripcion))
        {
            mensajeError = "ERROR: Los campos nombre y descripción son obligatorios y deben completarse. Intente nuevamente. \n";
        }

        if (datosEvento.FechaHoraInicio < DateTime.Now)
        {
            mensajeError += "ERROR: La fecha ingresada es invalida. Intente nuevamente. \n";
        }

        if (datosEvento.CupoMaximo <= 0)
        {
            mensajeError += "ERROR: El cupo máximo ingresado es invalido. Intente nuevamente. \n";
        }

        if (datosEvento.DuracionHoras <= 0)
        {
            mensajeError += "ERROR: La duración en horas ingresada es invalida. Intente nuevamente. \n";
        }

        return mensajeError == "";
    }

    public bool ValidarIdResponsable(int responsableId, out string mensajeError)
    {
        mensajeError = "";
        bool encontro = false;
        var listarUsuarios = new ListarUsuariosUseCase(repoUsuario);
        var listaU = listarUsuarios.Ejecutar();
        foreach (Usuario u in listaU)
        {
            if (responsableId == u.Id)
            {
                encontro = true;
                break;
            }
        }
        if (!encontro)
        {
            mensajeError = "ERROR: El id del responsable ingresado no existe en el sistema. Intente nuevamente. \n";
        }
        return mensajeError == "";
    }

    public bool ValidarReservasAsociadas(int idEvento, out string mensajeError)
    {
        mensajeError = "";
        var listaReservas = repoReserva.ListarReservas();
        foreach (Reserva r in listaReservas)
        {
            if (r.EventoDeportivoId == idEvento)
            {
                mensajeError = "ERROR: No es posible eliminar el evento deportivo ya que existen reservas asociadas a el mismo. Intente nuevamente. \n";
                break;
            }

        }
        return mensajeError == "";
    }

    public bool ValidarFechaPasadaEvento(int idEvento, out string mensajeError)
    {
        mensajeError = "";
        DateTime fecha = DateTime.MinValue;
        var listarEventos = new ListarEventosDeportivosUseCase(repoEvento);
        var listaE = listarEventos.Ejecutar();
        foreach (EventoDeportivo e in listaE)
        {
            if (e.Id == idEvento)
            {
                fecha = e.FechaHoraInicio;
                break;
            }
        }

        if (fecha < DateTime.Now)
        {
            mensajeError = "ERROR: La fecha de realización del evento es pasada y no es posible modificarlo. Intente nuevamente. \n";
        }

        return mensajeError == "";
    }

}

