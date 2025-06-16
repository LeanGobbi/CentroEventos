namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
  public int Id { get; set; }
  public int PersonaId {get; set;}
  public int EventoDeportivoId {get; set;}
  public DateTime FechaAltaReserva {get; set;}
  public enum Estados {Pendiente, Presente, Ausente};

  public Estados EstadoAsistencia {get; set;}

  public override string ToString()
  {
    return $"La reserva con id {Id} se encuentra registrada en el sistema, el id de la persona asociada es {PersonaId}, el id del evento deportivo asociado es {EventoDeportivoId}, la fecha de alta es {FechaAltaReserva}, y el estado de la reserva es {EstadoAsistencia}\n";
  }
}
