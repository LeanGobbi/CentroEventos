namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class RepositorioUsuario : IRepositorioUsuario
{
    public void AgregarUsuario(Usuario datosUsuario)
    {
        using var context = new CentroEventosContext();
        context.Add(datosUsuario);
        context.SaveChanges();
    }

    public void EliminarUsuario(int idUsuario)
    {
        using var context = new CentroEventosContext();
        var usuario = new Usuario { Id = idUsuario };
        context.Remove(usuario);
        context.SaveChanges();
    }

    public void ModificarUsuario(Usuario datosUsuario)
    {
        using var context = new CentroEventosContext();
        context.Update(datosUsuario);
        context.SaveChanges();
    }

    public List<Usuario> ListarUsuarios()
    {
        using var context = new CentroEventosContext();

        // Solo traemos las columnas existentes y no la lista Permisos directamente
        var usuarios = context.Usuarios
            .Select(u => new Usuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Contraseña = u.Contraseña,
                PermisosSerializados = u.PermisosSerializados
            })
            .ToList();

        // Reconstruir la lista de Permisos en memoria
        foreach (var usuario in usuarios)
        {
            usuario.Permisos = string.IsNullOrEmpty(usuario.PermisosSerializados)
                ? new List<IServicioAutorizacion.Permisos>()
                : usuario.PermisosSerializados.Split(',')
                    .Select(s => Enum.Parse<IServicioAutorizacion.Permisos>(s))
                    .ToList();
        }

        return usuarios;
    }
    public List<Usuario> ListarAsistenciaAEvento(int idEvento)
    {
        return null;
    }
}
