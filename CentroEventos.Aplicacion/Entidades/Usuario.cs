namespace CentroEventos.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations.Schema;
using CentroEventos.Aplicacion.Interfaces;

public class Usuario
{
  public int Id { get; set; }
  public string Nombre { get; set; } = "";
  public string Apellido { get; set; } = "";
  public string Email { get; set; } = "";
  public string Contraseña { get; set; } = "";

  [NotMapped]
  public List<IServicioAutorizacion.Permisos> Permisos { get; set; } = new();

  public string PermisosSerializados //guardo como strings los permisos en la bd
  {
    get => string.Join(",", Permisos.Select(p => p.ToString()));
    set => Permisos = string.IsNullOrEmpty(value)
        ? new List<IServicioAutorizacion.Permisos>()
        : value.Split(',').Select(s => Enum.Parse<IServicioAutorizacion.Permisos>(s)).ToList();
  }


  public override string ToString()
  {
    return $"El usuario con Id {Id} , {Nombre} {Apellido} se encuentra registrado/a en el sistema con email {Email} y contraseña {Contraseña}";
  }

}