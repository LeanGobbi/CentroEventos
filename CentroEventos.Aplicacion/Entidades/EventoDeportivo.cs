namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
  public int Id { get; set; }
  public string Nombre { get; set; } = "";
  public string Descripcion { get; set; } = "";
  public DateTime FechaHoraInicio { get; set; }
  public double DuracionHoras { get; set; }
  public int CupoMaximo { get; set; }
  public int ResponsableId { get; set; }
  public override string ToString()
  {
    return $"El evento deportivo con nombre {Nombre} se encuentra registrado en el sistema con descripción {Descripcion}, Id {Id}, su fecha de inicio es {FechaHoraInicio}, dura {DuracionHoras} horas, el cupo máximo es de {CupoMaximo} personas y el id de la persona responsable es {ResponsableId}\n";
  }

}
