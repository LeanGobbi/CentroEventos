namespace CentroEventos.Aplicacion.Validadores;

using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;

public class ReservaValidador(IRepositorioUsuario repoUsuario, IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{

    public bool ValidarPersonaYEventoAsociados(Reserva datosReserva, out string mensajeError)
    {
        mensajeError = "";
        bool encontro = false;
        var listarUsuarios = new ListarUsuariosUseCase(repoUsuario);
        var listaU = listarUsuarios.Ejecutar();
        foreach (Usuario u in listaU)
        {
            if (datosReserva.PersonaId == u.Id)
            {
                encontro = true;
                break;
            }
        }
        if (!encontro)
        {
            mensajeError = "ERROR: El id de la persona asociada a la reserva no existe en el sistema. Intente nuevamente. \n";
        }

        encontro = false;
        var listarEventos = new ListarEventosDeportivosUseCase(repoEvento);
        var listaE = listarEventos.Ejecutar();
        foreach (EventoDeportivo e in listaE)
        {
            if (datosReserva.EventoDeportivoId == e.Id)
            {
                encontro = true;
                break;
            }
        }
        if (!encontro)
        {
            mensajeError += "ERROR: El id del evento deportivo asociado a la reserva no existe en el sistema. Intente nuevamente. \n";
        }

        return mensajeError == "";
    }

    public bool ValidarDuplicacionReserva (Reserva datosReserva, out string mensajeError)
    {
        mensajeError = "";
        bool encontro = false;
        var listarReservas = new ListarReservasUseCase(repoReserva);
        var listaR = listarReservas.Ejecutar();
        foreach (Reserva r in listaR)
        {
            if ((datosReserva.EventoDeportivoId == r.EventoDeportivoId) && (datosReserva.PersonaId == r.PersonaId))
            {
                if (datosReserva.Id != r.Id)
                {
                    encontro = true;
                    break;
                }
            }
        }
        if (encontro)
        {
            mensajeError = "ERROR: La reserva ya se encuentra realizada para la misma persona y mismo evento deportivo. Intente nuevamente. \n";
        }
    return mensajeError == "";
    }
    
    public bool ValidarCupoMaximoReserva (Reserva datosReserva, out string mensajeError)
    {
        mensajeError = "";
        int cantidadReservas = 0;
        int cupoMaximoEvento = 0;
        var listarEventos = new ListarEventosDeportivosUseCase(repoEvento);
        var listaE = listarEventos.Ejecutar();
        foreach (EventoDeportivo e in listaE)
        {
            if (datosReserva.EventoDeportivoId == e.Id)
            {
                cupoMaximoEvento = e.CupoMaximo;
                break;
            }
        }
        var listarReservas = new ListarReservasUseCase(repoReserva);
        var listaR = listarReservas.Ejecutar();
        foreach (Reserva r in listaR)
        {
            if (datosReserva.EventoDeportivoId == r.EventoDeportivoId)
            {
                if (datosReserva.Id != r.Id)
                {
                    cantidadReservas++;
                }
            }
        }

        if (cantidadReservas == cupoMaximoEvento)
        {
            mensajeError = "ERROR: El evento deportivo asociado a la reserva llego al cupo máximo de personas inscriptas. Intente nuevamente. \n";
        }
    return mensajeError == ""; 
    }

}